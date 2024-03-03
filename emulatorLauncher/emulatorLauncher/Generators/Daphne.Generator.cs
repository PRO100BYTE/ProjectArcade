﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using EmulatorLauncher.Common;
using EmulatorLauncher.Common.Lightguns;
using System.Windows.Forms;

namespace EmulatorLauncher
{
    partial class HypseusGenerator : DaphneGenerator
    {
        public HypseusGenerator() { _executableName = "hypseus"; DependsOnDesktopResolution = true; }

    }

    partial class DaphneGenerator : Generator
    {
        public DaphneGenerator()
        {
            _executableName = "daphne";
        }

		protected virtual void UpdateCommandline(List<string> commandArray)
        {
            if (SystemConfig.isOptSet("fastboot") && !SystemConfig.getOptBoolean("fastboot"))
                commandArray.Remove("-fastboot");

            if (_executableName == "daphne")
            {
                if (SystemConfig["ratio"] == "16/9")
                    commandArray.Add("-ignore_aspect_ratio");

                return;
            }

            // hypseus
            if (_executableName == "hypseus")
            {
                if (SystemConfig.isOptSet("smooth") && !SystemConfig.getOptBoolean("smooth"))
                    commandArray.Add("-nolinear_scale");

                if (SystemConfig["ratio"] == "16/9")
                    commandArray.Add("-ignore_aspect_ratio");
                else
                    commandArray.Add("-force_aspect_ratio");

                if (SystemConfig.isOptSet("hypseus_renderer") && SystemConfig["hypseus_renderer"] == "vulkan")
                {
                    commandArray.Remove("-opengl");
                    commandArray.Add("-vulkan");
                }

                return;
            }
        }

        protected string _executableName;
        private string _daphneHomedir;
        private string _symLink;

        static string FindFile(string dir, string pattern, Predicate<string> predicate)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir, pattern))
                    if (predicate(f))
                        return f;

                foreach (string d in Directory.GetDirectories(dir))
                {
                    string ret = FindFile(d, pattern, predicate);
                    if (ret != null)
                        return ret;
                }                
            }
            catch { }

            return null;
        }

        public override System.Diagnostics.ProcessStartInfo Generate(string system, string emulator, string core, string rom, string playersControllers, ScreenResolution resolution)
        {
            rom = this.TryUnZipGameIfNeeded(system, rom);

            string romName = Path.GetFileNameWithoutExtension(rom);

            // Special Treatment for actionmax games
            var ext = Path.GetExtension(rom).Replace(".", "").ToLower();
            if (ext == "actionmax")
            {
                string expectedSingeFile = Path.Combine(Path.GetDirectoryName(rom), ext, romName + ".singe");
                if (!File.Exists(expectedSingeFile))
                    return null;

                rom = Path.Combine(Path.GetDirectoryName(rom), ext);
            }

            string commandsFile = rom + "\\" + romName + ".commands";

            string singeFile = rom + "\\" + romName + ".singe";
            if (!File.Exists(singeFile))
                singeFile = FindFile(rom, "*.singe", f => Path.GetFileNameWithoutExtension(f).StartsWith(romName));

            string frameFile = rom + "\\" + romName + ".txt";
            if (File.Exists(singeFile))
            {
                _executableName = "hypseus";
                if (!File.Exists(frameFile))
                {
                    frameFile = FindFile(rom, "*.txt", f => Path.GetFileNameWithoutExtension(f).StartsWith(romName));
                    if (frameFile == null)
                        frameFile = FindFile(rom, "*.mp4", f => Path.GetFileNameWithoutExtension(f).StartsWith(romName));
                }
            }                        

            string emulatorPath = AppConfig.GetFullPath(_executableName);
            string exe = Path.Combine(emulatorPath, _executableName + ".exe");
            if (!File.Exists(exe))
            {
                ExitCode = ExitCodes.EmulatorNotInstalled;
                return null;
            }

            if (emulator == "hypseus")
                CreateControllerConfiguration(emulatorPath);

            List<string> commandArray = new List<string>();

            // extension used .daphne and the file to start the game is in the folder .daphne with the extension .txt
        
            string daphneDatadir = emulatorPath;
            _daphneHomedir = Path.GetDirectoryName(rom);

            if (File.Exists(singeFile) && _executableName == "hypseus")
            {
                _daphneHomedir = emulatorPath;

                commandArray.AddRange(new string[]                       
                   {                        
                        "singe", 
                        "vldp", 
                        "-retropath", // Requires the CreateSymbolicLink
                        "-framefile", frameFile, 
                        "-script", singeFile, 
                        "-manymouse", 
                        "-datadir", _daphneHomedir,
                        "-homedir", _daphneHomedir
                    });

                if (RawLightgun.GetRawLightguns().Any(gun => gun.Type == RawLighGunType.SindenLightgun))
                    commandArray.AddRange(new string[] { "-sinden", "2", "w" });

                string directoryName = Path.GetFileName(rom);

                if (directoryName == "actionmax")
                    directoryName = Path.ChangeExtension(directoryName, ".daphne");

                _symLink = Path.Combine(emulatorPath, directoryName);

                try
                {
                    if (Directory.Exists(_symLink))
                        Directory.Delete(_symLink);
                }
                catch { }

                FileTools.CreateSymlink(_symLink, rom, true);

                if (!Directory.Exists(_symLink))
                {
                    this.SetCustomError("Unable to create symbolic link. Please activate developer mode in Windows settings to allow this.");
                    ExitCode = ExitCodes.CustomError;
                    return null;                    
                }
            }
            else
            {
                if (emulator == "daphne")
                {
                    commandArray.AddRange(new string[]
                   {
                       romName,
                       "vldp",
                        "-framefile", frameFile,
                        "-useoverlaysb", "2",
                        "-homedir", _daphneHomedir
                   });
                }
                else                 {
                    commandArray.AddRange(new string[]
                   {
                       romName,
                       "vldp",
                        "-framefile", frameFile,
                        "-homedir", _daphneHomedir
                   });
                }
            }
            
            bool fullscreen = !IsEmulationStationWindowed() || SystemConfig.getOptBoolean("forcefullscreen");

            if (fullscreen)
                commandArray.Add("-fullscreen");

            commandArray.Add("-x");
            commandArray.Add((resolution == null ? Screen.PrimaryScreen.Bounds.Width : resolution.Width).ToString());

            commandArray.Add("-y");
            commandArray.Add((resolution == null ? Screen.PrimaryScreen.Bounds.Height : resolution.Height).ToString());

            commandArray.Add("-opengl");            
            commandArray.Add("-fastboot");

            if (SystemConfig.getOptBoolean("daphne_vsync") && emulator == "hypseus")
                commandArray.Add("-novsync");

            UpdateCommandline(commandArray);       
            
            // The folder may have a file with the game name and .commands with extra arguments to run the game.
            if (_executableName == "daphne" && File.Exists(commandsFile))
            {
                string[] file = File.ReadAllText(commandsFile).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < file.Length; i++)
                {
                    string s = file[i];

                    if (s == "singe" && commandArray[0] != "singe")
                    {
                        commandArray[0] = "singe";
                        continue;
                    }

                    if (s == romName || s == "singe" || s == "vdlp" || s == "-fullscreen" || 
                        s == "-opengl" || s == "-vulkan" || s == "-fastboot" || s == "-retropath" || s == "-manymouse")
                        continue;

                    if (s == "-x" || s == "-y" || s == "-framefile" || s == "-script" || s == "script" || s == "-useoverlaysb" || s == "-homedir" || s == "-datadir")
                    {
                        i++;
                        continue;
                    }

                    commandArray.Add(s);
                }
            }

            if (emulator == "daphne")
            {
                if (SystemConfig["ratio"] == "16/9")
                    SystemConfig["bezel"] = "none";

                ReshadeManager.Setup(ReshadeBezelType.opengl, ReshadeManager.GetPlatformFromFile(exe), system, rom, emulatorPath, resolution);
            }

            else if (emulator == "hypseus")
            {
                BezelFiles bezelFileInfo = BezelFiles.GetBezelFiles(system, rom, resolution);
                if (bezelFileInfo != null)
                {
                    string bezelFile = bezelFileInfo.PngFile;
                    string hypseusBezelFile = Path.Combine(AppConfig.GetFullPath("hypseus"), "bezels", "ProjectArcadeBezel.png");

                    if (bezelFile != null && File.Exists(bezelFile))
                    {
                        if (File.Exists(hypseusBezelFile))
                            File.Delete(hypseusBezelFile);

                        File.Copy(bezelFile, hypseusBezelFile);

                        string targetBezelFile = Path.GetFileName(hypseusBezelFile);

                        commandArray.Add("-bezel");
                        commandArray.Add("\"" + targetBezelFile + "\"");
                    }
                }

                if (SystemConfig["bezel"] == "default_unglazed")
                {
                    string hypseusBezelFile = Path.Combine(AppConfig.GetFullPath("hypseus"), "bezels", romName + ".png");

                    if (File.Exists(hypseusBezelFile))
                    {
                        string targetBezelFile = Path.GetFileName(hypseusBezelFile);
                        commandArray.Add("-bezel");
                        commandArray.Add("\"" + targetBezelFile + "\"");
                    }
                }
            }

            string args = string.Join(" ", commandArray);

            return new ProcessStartInfo()
            {
                FileName = exe,
                Arguments = args,
                WorkingDirectory = emulatorPath,
            };
        }

        public override void Cleanup()
        {
            base.Cleanup();

            try
            {
                if (!string.IsNullOrEmpty(_symLink) && Directory.Exists(_symLink))
                    Directory.Delete(_symLink);

                string ram = Path.Combine(_daphneHomedir, "ram");
                if (Directory.Exists(ram))
                    new DirectoryInfo(ram).Delete(true);

                string frameFile = Path.Combine(_daphneHomedir, "framefile");
                if (Directory.Exists(frameFile))
                    new DirectoryInfo(frameFile).Delete(true);     
            }
            catch { }
        }
    }
}