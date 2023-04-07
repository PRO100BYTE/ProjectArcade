﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Management;
using emulatorLauncher.Tools;

namespace emulatorLauncher
{
    partial class Pcsx2Generator : Generator
    {
        /// <summary>
        /// Cf. https://github.com/PCSX2/pcsx2/blob/master/pcsx2/Frontend/SDLInputSource.cpp#L211
        /// </summary>
        /// <param name="pcsx2ini"></param>
        private void UpdateSdlControllersWithHints(IniFile pcsx2ini)
        {
            var hints = new List<string>();
            hints.Add("SDL_JOYSTICK_HIDAPI_WII = 1");

            if (pcsx2ini.GetValue("InputSources", "SDLControllerEnhancedMode") == "true")
            {
                hints.Add("SDL_HINT_JOYSTICK_HIDAPI_PS4_RUMBLE = 1");
                hints.Add("SDL_HINT_JOYSTICK_HIDAPI_PS5_RUMBLE = 1");
            }
         
            SdlGameController.ReloadWithHints(string.Join(",", hints));
            Program.Controllers.ForEach(c => c.ResetSdlController());
        }

        private void CreateControllerConfiguration(IniFile pcsx2ini)
        {
            if (Program.SystemConfig.isOptSet("disableautocontrollers") && Program.SystemConfig["disableautocontrollers"] == "1")
                return;

            UpdateSdlControllersWithHints(pcsx2ini);
            
            // clear existing pad sections of ini file
            for (int i = 1; i < 9; i++)
                pcsx2ini.ClearSection("Pad" + i.ToString());

            // If more than 2 controllers plugged, PCSX2 must be set to use multitap, if more than 5, both multitaps must be activated
            if (Controllers.Count > 5)
            {
                pcsx2ini.WriteValue("Pad", "MultitapPort1", "true");
                pcsx2ini.WriteValue("Pad", "MultitapPort2", "true");
            }
            else if (Controllers.Count > 2)
                pcsx2ini.WriteValue("Pad", "MultitapPort1", "true");
            else
            {
                pcsx2ini.WriteValue("Pad", "MultitapPort1", "false");
                pcsx2ini.WriteValue("Pad", "MultitapPort2", "false");
            }
          
            pcsx2ini.WriteValue("InputSources", "DInput", "false");
            pcsx2ini.WriteValue("InputSources", "XInput", Controllers.Any(c => c.IsXInputDevice) ? "true" : "false");
            pcsx2ini.WriteValue("InputSources", "SDL", Controllers.Any(c => !c.IsKeyboard && !c.IsXInputDevice) ? "true": "false");
            pcsx2ini.WriteValue("InputSources", "SDLControllerEnhancedMode", "true");

            // Reset hotkeys
            ResetHotkeysToDefault(pcsx2ini);

            // Inject controllers                
            foreach (var controller in this.Controllers.OrderBy(i => i.PlayerIndex))
                ConfigureInput(pcsx2ini, controller, "Pad" + controller.PlayerIndex); // ini has one section for each pad (from Pad1 to Pad8)
        }

        private void ConfigureInput(IniFile pcsx2ini, Controller controller, string padNumber)
        {
            if (controller == null || controller.Config == null)
                return;

            if (controller.IsKeyboard)
                ConfigureKeyboard(pcsx2ini, controller.Config, padNumber);
            else
                ConfigureJoystick(pcsx2ini, controller, controller.PlayerIndex, padNumber);
        }

        /// <summary>
        /// Keyboard
        /// </summary>
        /// <param name="pcsx2ini"></param>
        /// <param name="keyboard"></param>
        /// <param name="padNumber"></param>
        private void ConfigureKeyboard(IniFile pcsx2ini, InputConfig keyboard, string padNumber)
        {
            if (keyboard == null)
                return;

            Action<string, string, InputKey> WriteKeyboardMapping = (v, w, k) =>
            {
                var a = keyboard[k];
                if (a != null)
                    pcsx2ini.WriteValue(v, w, "Keyboard/" + SdlToKeyCode(a.Id));
            };

            pcsx2ini.WriteValue(padNumber, "Type", "DualShock2");
            pcsx2ini.WriteValue(padNumber, "InvertL", "0");
            pcsx2ini.WriteValue(padNumber, "InvertR", "0");
            pcsx2ini.WriteValue(padNumber, "Deadzone", "0");
            pcsx2ini.WriteValue(padNumber, "AxisScale", "1.33");
            pcsx2ini.WriteValue(padNumber, "LargeMotorScale", "1");
            pcsx2ini.WriteValue(padNumber, "SmallMotorScale", "1");
            pcsx2ini.WriteValue(padNumber, "ButtonDeadzone", "0");
            pcsx2ini.WriteValue(padNumber, "PressureModifier", "0.5");

            //Perform mappings based on es_input
            WriteKeyboardMapping(padNumber, "Up", InputKey.up);
            WriteKeyboardMapping(padNumber, "Right", InputKey.right);
            WriteKeyboardMapping(padNumber, "Down", InputKey.down);
            WriteKeyboardMapping(padNumber, "Left", InputKey.left);
            WriteKeyboardMapping(padNumber, "Triangle", InputKey.x);
            WriteKeyboardMapping(padNumber, "Circle", InputKey.a);
            WriteKeyboardMapping(padNumber, "Cross", InputKey.b);
            WriteKeyboardMapping(padNumber, "Square", InputKey.y);
            WriteKeyboardMapping(padNumber, "Start", InputKey.start);
            WriteKeyboardMapping(padNumber, "Select", InputKey.select);
            WriteKeyboardMapping(padNumber, "L1", InputKey.pageup);
            WriteKeyboardMapping(padNumber, "L2", InputKey.l2);
            WriteKeyboardMapping(padNumber, "R1", InputKey.pagedown);
            WriteKeyboardMapping(padNumber, "R2", InputKey.r2);
            WriteKeyboardMapping(padNumber, "L3", InputKey.l3);
            WriteKeyboardMapping(padNumber, "R3", InputKey.r3);
            WriteKeyboardMapping(padNumber, "LUp", InputKey.leftanalogup);
            WriteKeyboardMapping(padNumber, "LRight", InputKey.leftanalogright);
            WriteKeyboardMapping(padNumber, "LDown", InputKey.leftanalogdown);
            WriteKeyboardMapping(padNumber, "LLeft", InputKey.leftanalogleft);
            WriteKeyboardMapping(padNumber, "RUp", InputKey.rightanalogup);
            WriteKeyboardMapping(padNumber, "RRight", InputKey.rightanalogright);
            WriteKeyboardMapping(padNumber, "RDown", InputKey.rightanalogdown);
            WriteKeyboardMapping(padNumber, "RLeft", InputKey.rightanalogleft);
        }

        /// <summary>
        /// Gamepad configuration
        /// </summary>
        /// <param name="pcsx2ini"></param>
        /// <param name="ctrl"></param>
        /// <param name="playerIndex"></param>
        /// <param name="padNumber"></param>
        private void ConfigureJoystick(IniFile pcsx2ini, Controller ctrl, int playerIndex, string padNumber)
        {
            if (ctrl == null)
                return;

            InputConfig joy = ctrl.Config;
            if (joy == null)
                return;

            //Define tech (SDL or XInput)
            string tech = ctrl.IsXInputDevice ? "XInput" : "SDL";

            //Start writing in ini file
            pcsx2ini.ClearSection(padNumber);
            pcsx2ini.WriteValue(padNumber, "Type", "DualShock2");

            //Get SDL controller index
            string techPadNumber = "SDL-" + (ctrl.SdlController == null ? ctrl.DeviceIndex : ctrl.SdlController.Index) + "/";
            if (ctrl.IsXInputDevice)
                techPadNumber = "XInput-" + ctrl.XInput.DeviceIndex + "/";

            //Write button mapping
            pcsx2ini.WriteValue(padNumber, "Up", techPadNumber + GetInputKeyName(ctrl, InputKey.up, tech));
            pcsx2ini.WriteValue(padNumber, "Right", techPadNumber + GetInputKeyName(ctrl, InputKey.right, tech));
            pcsx2ini.WriteValue(padNumber, "Down", techPadNumber + GetInputKeyName(ctrl, InputKey.down, tech));
            pcsx2ini.WriteValue(padNumber, "Left", techPadNumber + GetInputKeyName(ctrl, InputKey.left, tech));
            pcsx2ini.WriteValue(padNumber, "Triangle", techPadNumber + GetInputKeyName(ctrl, InputKey.y, tech));
            pcsx2ini.WriteValue(padNumber, "Circle", techPadNumber + GetInputKeyName(ctrl, InputKey.b, tech));
            pcsx2ini.WriteValue(padNumber, "Cross", techPadNumber + GetInputKeyName(ctrl, InputKey.a, tech));
            pcsx2ini.WriteValue(padNumber, "Square", techPadNumber + GetInputKeyName(ctrl, InputKey.x, tech));
            pcsx2ini.WriteValue(padNumber, "Select", techPadNumber + GetInputKeyName(ctrl, InputKey.select, tech));
            pcsx2ini.WriteValue(padNumber, "Start", techPadNumber + GetInputKeyName(ctrl, InputKey.start, tech));
            pcsx2ini.WriteValue(padNumber, "L1", techPadNumber + GetInputKeyName(ctrl, InputKey.pageup, tech));
            pcsx2ini.WriteValue(padNumber, "L2", techPadNumber + GetInputKeyName(ctrl, InputKey.l2, tech));
            pcsx2ini.WriteValue(padNumber, "R1", techPadNumber + GetInputKeyName(ctrl, InputKey.pagedown, tech));
            pcsx2ini.WriteValue(padNumber, "R2", techPadNumber + GetInputKeyName(ctrl, InputKey.r2, tech));
            pcsx2ini.WriteValue(padNumber, "L3", techPadNumber + GetInputKeyName(ctrl, InputKey.l3, tech));
            pcsx2ini.WriteValue(padNumber, "R3", techPadNumber + GetInputKeyName(ctrl, InputKey.r3, tech));
            pcsx2ini.WriteValue(padNumber, "Analog", techPadNumber + "Guide");
            pcsx2ini.WriteValue(padNumber, "LUp", techPadNumber + GetInputKeyName(ctrl, InputKey.leftanalogup, tech));
            pcsx2ini.WriteValue(padNumber, "LRight", techPadNumber + GetInputKeyName(ctrl, InputKey.leftanalogright, tech));
            pcsx2ini.WriteValue(padNumber, "LDown", techPadNumber + GetInputKeyName(ctrl, InputKey.leftanalogdown, tech));
            pcsx2ini.WriteValue(padNumber, "LLeft", techPadNumber + GetInputKeyName(ctrl, InputKey.leftanalogleft, tech));
            pcsx2ini.WriteValue(padNumber, "RUp", techPadNumber + GetInputKeyName(ctrl, InputKey.rightanalogup, tech));
            pcsx2ini.WriteValue(padNumber, "RRight", techPadNumber + GetInputKeyName(ctrl, InputKey.rightanalogright, tech));
            pcsx2ini.WriteValue(padNumber, "RDown", techPadNumber + GetInputKeyName(ctrl, InputKey.rightanalogdown, tech));
            pcsx2ini.WriteValue(padNumber, "RLeft", techPadNumber + GetInputKeyName(ctrl, InputKey.rightanalogleft, tech));
            pcsx2ini.WriteValue(padNumber, "LargeMotor", techPadNumber + "LargeMotor");
            pcsx2ini.WriteValue(padNumber, "SmallMotor", techPadNumber + "SmallMotor");

            // Write Hotkeys for player 1
            if (playerIndex == 1)
            {
                var hotKeyName = GetInputKeyName(ctrl, InputKey.hotkey, tech);
                if (hotKeyName != "None")
                {
                    foreach (var hotkey in hotkeys)
                    {
                        var inputKeyName = GetInputKeyName(ctrl, hotkey.Key, tech);
                        if (string.IsNullOrEmpty(inputKeyName) || inputKeyName == "None")
                            continue;

                        pcsx2ini.WriteValue("Hotkeys", hotkey.Value.Key, techPadNumber + hotKeyName + " & " + techPadNumber + inputKeyName);
                    }
                }
            }
        }

        private void ResetHotkeysToDefault(IniFile pcsx2ini)
        {
            foreach (var hotkey in hotkeys)
                pcsx2ini.WriteValue("Hotkeys", hotkey.Value.Key, hotkey.Value.Value);
        }

        static public Dictionary<InputKey, KeyValuePair<string, string>> hotkeys = new Dictionary<InputKey, KeyValuePair<string, string>>()
        {            
            { InputKey.b, new KeyValuePair<string, string>("TogglePause", "Keyboard/Space") },
            { InputKey.a, new KeyValuePair<string, string>("OpenPauseMenu", "Keyboard/Escape") },
            { InputKey.x, new KeyValuePair<string, string>("LoadStateFromSlot", "Keyboard/F3") },
            { InputKey.y, new KeyValuePair<string, string>("SaveStateToSlot", "Keyboard/F1") },
            { InputKey.r3, new KeyValuePair<string, string>("Screenshot", "Keyboard/F8") },
            { InputKey.up, new KeyValuePair<string, string>("NextSaveStateSlot", "Keyboard/F2") },
            { InputKey.down, new KeyValuePair<string, string>("PreviousSaveStateSlot", "Keyboard/Shift & Keyboard/F2") },            
        };


        private static string GetInputKeyName(Controller c, InputKey key, string tech)
        {            
            Int64 pid = -1;

            // If controller is nintendo, A/B and X/Y are reversed
            //bool revertbuttons = (c.VendorID == VendorId.USB_VENDOR_NINTENDO);

            bool revertAxis = false;
            key = key.GetRevertedAxis(out revertAxis);

            var input = c.Config[key];
            if (input != null)
            {
                if (input.Type == "button")
                {
                    pid = input.Id;
                    switch (pid)
                    {
                        case 0: return "A";
                        case 1: return "B";
                        case 2: return "Y";
                        case 3: return "X";
                        case 4: return tech == "XInput" ? "LeftShoulder" : "Back";
                        case 5: return "RightShoulder";
                        case 6: return tech == "XInput" ? "Back" : "Start";
                        case 7: return tech == "XInput" ? "Start" : "LeftStick";
                        case 8: return tech == "XInput" ? "LeftStick" : "RightStick";
                        case 9: return tech == "XInput" ? "RightStick" : "LeftShoulder";
                        case 10: return "RightShoulder";
                        case 11: return "DPadUp";
                        case 12: return "DPadDown";
                        case 13: return "DPadLeft";
                        case 14: return "DPadRight";
                    }
                }

                if (input.Type == "axis")
                {
                    pid = input.Id;
                    switch (pid)
                    {
                        case 0:
                            if ((!revertAxis && input.Value > 0) || (revertAxis && input.Value < 0)) return "+LeftX";
                            else return "-LeftX";
                        case 1:
                            if ((!revertAxis && input.Value > 0) || (revertAxis && input.Value < 0)) return "+LeftY";
                            else return "-LeftY";
                        case 2:
                            if ((!revertAxis && input.Value > 0) || (revertAxis && input.Value < 0)) return "+RightX";
                            else return "-RightX";
                        case 3:
                            if ((!revertAxis && input.Value > 0) || (revertAxis && input.Value < 0)) return "+RightY";
                            else return "-RightY";
                        case 4: return "+LeftTrigger";
                        case 5: return "+RightTrigger";
                    }
                }

                if (input.Type == "hat")
                {
                    pid = input.Value;
                    switch (pid)
                    {
                        case 1: return "DPadUp";
                        case 2: return "DPadRight";
                        case 4: return "DPadDown";
                        case 8: return "DPadLeft";
                    }
                }
            }
            return "None";
        }

        private static string SdlToKeyCode(long sdlCode)
        {
            switch (sdlCode)
            {
                case 0x0D: return "Return";
                case 0x00: return "\"\"";
                case 0x08: return "Backspace";
                case 0x09: return "Tab";
                case 0x1B: return "Esc";
                case 0x20: return "Space";
                case 0x21: return "Exclam";
                case 0x22: return "\"" + @"\" + "\"" + "\"";
                case 0x23: return "\"#\"";
                case 0x24: return "Dollar";
                case 0x25: return "\"%\"";
                case 0x26: return "Ampersand";
                case 0x27: return @"\";
                case 0x28: return "ParenLeft";
                case 0x29: return "ParenRight";
                case 0x2A: return "NumpadAsterisk";
                case 0x2B: return "\"+\"";
                case 0x2C: return "Comma";
                case 0x2D: return "\"-\"";
                case 0x2E: return "\".\"";
                case 0x2F: return "/";
                case 0x30: return "0";
                case 0x31: return "1";
                case 0x32: return "2";
                case 0x33: return "3";
                case 0x34: return "4";
                case 0x35: return "5";
                case 0x36: return "6";
                case 0x37: return "7";
                case 0x38: return "8";
                case 0x39: return "9";
                case 0x3A: return "\":\"";
                case 0x3B: return "Semicolon";
                case 0x3C: return "<";
                case 0x3D: return "Equal";
                case 0x3F: return ">";
                case 0x40: return "\"" + "@" + "\"";
                case 0x5B: return "\"[\"";
                case 0x5C: return @"\";
                case 0x5D: return "\"]\"";
                case 0x5E: return "^";
                case 0x5F: return "_";
                case 0x60: return "\"'\"";
                case 0x61: return "A";
                case 0x62: return "B";
                case 0x63: return "C";
                case 0x64: return "D";
                case 0x65: return "E";
                case 0x66: return "F";
                case 0x67: return "G";
                case 0x68: return "H";
                case 0x69: return "I";
                case 0x6A: return "J";
                case 0x6B: return "K";
                case 0x6C: return "L";
                case 0x6D: return "M";
                case 0x6E: return "N";
                case 0x6F: return "O";
                case 0x70: return "P";
                case 0x71: return "Q";
                case 0x72: return "R";
                case 0x73: return "S";
                case 0x74: return "T";
                case 0x75: return "U";
                case 0x76: return "V";
                case 0x77: return "W";
                case 0x78: return "X";
                case 0x79: return "Y";
                case 0x7A: return "Z";
                case 0x7F: return "Delete";
                case 0x40000039: return "CapsLock";
                case 0x4000003A: return "F1";
                case 0x4000003B: return "F2";
                case 0x4000003C: return "F3";
                case 0x4000003D: return "F4";
                case 0x4000003E: return "F5";
                case 0x4000003F: return "F6";
                case 0x40000040: return "F7";
                case 0x40000041: return "F8";
                case 0x40000042: return "F9";
                case 0x40000043: return "F10";
                case 0x40000044: return "F11";
                case 0x40000045: return "F12";
                case 0x40000046: return "PrintScreen";
                case 0x40000047: return "ScrollLock";
                case 0x40000048: return "Pause";
                case 0x40000049: return "Insert";
                case 0x4000004A: return "Home";
                case 0x4000004B: return "PageUp";
                case 0x4000004D: return "End";
                case 0x4000004E: return "PageDown";
                case 0x4000004F: return "Right";
                case 0x40000050: return "Left";
                case 0x40000051: return "Down";
                case 0x40000052: return "Up";
                case 0x40000053: return "NumLock";
                case 0x40000054: return "Num+/";
                case 0x40000055: return "Num+*";
                case 0x40000056: return "Num+-";
                case 0x40000057: return "Num++";
                case 0x40000058: return "Num+Enter";
                case 0x40000059: return "Num+1";
                case 0x4000005A: return "Num+2";
                case 0x4000005B: return "Num+3";
                case 0x4000005C: return "Num+4";
                case 0x4000005D: return "Num+5";
                case 0x4000005E: return "Num+6";
                case 0x4000005F: return "Num+7";
                case 0x40000060: return "Num+8";
                case 0x40000061: return "Num+9";
                case 0x40000062: return "Num+0";
                case 0x40000063: return "Num+.";
                case 0x40000067: return "Num+=";
                case 0x40000068: return "F13";
                case 0x40000069: return "F14";
                case 0x4000006A: return "F15";
                case 0x4000006B: return "F16";
                case 0x4000006C: return "F17";
                case 0x4000006D: return "F18";
                case 0x4000006E: return "F19";
                case 0x4000006F: return "F20";
                case 0x40000070: return "F21";
                case 0x40000071: return "F22";
                case 0x40000072: return "F23";
                case 0x40000073: return "F24";
                case 0x40000074: return "Execute";
                case 0x40000075: return "Help";
                case 0x40000076: return "Menu";
                case 0x40000077: return "Select";
                case 0x40000078: return "Stop";
                case 0x40000079: return "Again";
                case 0x4000007A: return "Undo";
                case 0x4000007B: return "Cut";
                case 0x4000007C: return "Copy";
                case 0x4000007D: return "Paste";
                case 0x4000007E: return "Menu";
                case 0x4000007F: return "Volume Mute";
                case 0x40000080: return "Volume Up";
                case 0x40000081: return "Volume Down";
                case 0x40000085: return "Num+,";
                case 0x400000E0: return "Control";
                case 0x400000E1: return "Shift";
                case 0x400000E2: return "Alt";
                case 0x400000E4: return "Control";
                case 0x400000E5: return "Shift";
                case 0x400000E6: return "Control & Keyboard/Alt";
                case 0x40000101: return "Mode";
                case 0x40000102: return "Media Next";
                case 0x40000103: return "Media Previous";
                case 0x40000105: return "Media Play";
            }
            return "None";
        }
    }
}