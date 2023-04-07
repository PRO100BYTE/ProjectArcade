﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Management;

namespace emulatorLauncher
{
    class RaineGenerator : Generator
    {
        public RaineGenerator()
        {
            DependsOnDesktopResolution = true;
        }

        public override int RunAndWait(ProcessStartInfo path)
        {
            FakeBezelFrm bezel = null;

            if (_bezelFileInfo != null)
                bezel = _bezelFileInfo.ShowFakeBezel(_resolution);

            int ret = base.RunAndWait(path);

            if (bezel != null)
                bezel.Dispose();

            return ret;
        }

        private string _path;
        private BezelFiles _bezelFileInfo;
        private ScreenResolution _resolution;

        public override System.Diagnostics.ProcessStartInfo Generate(string system, string emulator, string core, string rom, string playersControllers, ScreenResolution resolution)
        {

            _path = AppConfig.GetFullPath("raine");
            _resolution = resolution;

            string exe = Path.Combine(_path, "raine.exe");
            if (!File.Exists(exe) || !Environment.Is64BitOperatingSystem)
                exe = Path.Combine(_path, "raine32.exe");

            if (!File.Exists(exe))
                return null;

            if (Path.GetExtension(rom).ToLowerInvariant() == ".zip")
            {
                rom = Path.GetFileNameWithoutExtension(rom);
            }

            SetupSettings();

            if (SystemConfig["ratio"] == "ON")
                _bezelFileInfo = BezelFiles.GetBezelFiles(system, rom, resolution);

            _resolution = resolution;

            return new ProcessStartInfo()
            {
                FileName = exe,
                WorkingDirectory = _path,
                Arguments = "-n -fs 1 \"" + rom + "\"",
            };
        }

        private void SetupSettings()
        {
            string iniFile = Path.Combine(_path, "config", "raine32_sdl.cfg");

            try
            {
                using (var ini = new IniFile(iniFile))
                {
                    Uri relRoot = new Uri(_path, UriKind.Absolute);

                    string biosPath = AppConfig.GetFullPath("bios");
                    if (!string.IsNullOrEmpty(biosPath))
                    {
                        ini.WriteValue("Directories", "rom_dir_0", biosPath.Replace("\\", "\\\\") + "\\\\");
                        ini.WriteValue("neocd", "neocd_bios", biosPath.Replace("\\", "\\\\") + "\\\\" + "neocdz.zip");
                        ini.WriteValue("Directories", "emudx", biosPath.Replace("\\", "\\\\") + "\\\\" + "raine" + "\\\\" + "emudx" + "\\\\");
                        ini.WriteValue("Directories", "artwork", biosPath.Replace("\\", "\\\\") + "\\\\" + "raine" + "\\\\" + "artwork" + "\\\\");
                    }

                    string romPath = AppConfig.GetFullPath("roms");
                    if (!string.IsNullOrEmpty(romPath))
                    {
                        ini.WriteValue("Directories", "rom_dir_1", romPath.Replace("\\", "\\\\") + "\\\\" + "neogeo" + "\\\\");
                        ini.WriteValue("neocd", "neocd_dir", romPath.Replace("\\", "\\\\") + "\\\\" + "neogeocd" + "\\\\");
                    }

                    string sshotPath = AppConfig.GetFullPath("screenshots");
                    if (!string.IsNullOrEmpty(sshotPath))
                    {
                        ini.WriteValue("Directories", "ScreenShots", sshotPath.Replace("\\", "\\\\") + "\\\\");
                    }

                    ini.WriteValue("Display", "video_mode", "0");
                    ini.WriteValue("Display", "ogl_render", "1");

                    if (SystemConfig.isOptSet("Set_Shader") && !string.IsNullOrEmpty(SystemConfig["Set_Shader"]))
                        ini.WriteValue("Display", "ogl_shader", _path + "\\" + SystemConfig["Set_Shader"]);
                    else
                        ini.WriteValue("Display", "ogl_shader", "None");

                    if (SystemConfig.isOptSet("ratio") && !string.IsNullOrEmpty(SystemConfig["ratio"]))
                        ini.WriteValue("Display", "fix_aspect_ratio", SystemConfig["ratio"]);
                    else
                        ini.WriteValue("Display", "fix_aspect_ratio", "1");

                    if (SystemConfig.isOptSet("Set_Bios") && !string.IsNullOrEmpty(SystemConfig["Set_Bios"]))
                        ini.WriteValue("neogeo", "bios", SystemConfig["Set_Bios"]);
                    else
                        ini.WriteValue("neogeo", "bios", "25");

                    if (SystemConfig.isOptSet("Music_Volume") && !string.IsNullOrEmpty(SystemConfig["Music_Volume"]))
                        ini.WriteValue("neocd", "music_volume", SystemConfig["Music_Volume"]);
                    else
                        ini.WriteValue("neocd", "music_volume", "75");

                    if (SystemConfig.isOptSet("Sfx_Volume") && !string.IsNullOrEmpty(SystemConfig["Sfx_Volume"]))
                        ini.WriteValue("neocd", "sfx_volume", SystemConfig["Sfx_Volume"]);
                    else
                        ini.WriteValue("neocd", "sfx_volume", "75");

                    if (SystemConfig.isOptSet("Speed_Hack") && !string.IsNullOrEmpty(SystemConfig["Speed_Hack"]))
                        ini.WriteValue("neocd", "allowed_speed_hacks", SystemConfig["Speed_Hack"]);
                    else
                        ini.WriteValue("neocd", "allowed_speed_hacks", "1");

                    if (SystemConfig.isOptSet("Cd_Speed") && !string.IsNullOrEmpty(SystemConfig["Cd_Speed"]))
                        ini.WriteValue("neocd", "cdrom_speed", SystemConfig["Cd_Speed"]);
                    else
                        ini.WriteValue("neocd", "cdrom_speed", "8");
                }
            }
            catch { }
        }
    }
}
