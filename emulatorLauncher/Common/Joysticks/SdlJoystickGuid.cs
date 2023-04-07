﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace emulatorLauncher.Tools
{   
    /// <summary>
    /// This GUID fits the standard form:
    ///     * 16-bit bus
    ///     * 16-bit CRC16 of the joystick name (can be zero)
    ///     * 16-bit vendor ID
    ///     * 16-bit zero
    ///     * 16-bit product ID
    ///     * 16-bit zero
    ///     * 16-bit version
    ///     * 8-bit driver identifier ('h' for HIDAPI, 'x' for XInput, etc.)
    ///     * 8-bit driver-dependent type info`
    /// </summary>
    public class SdlJoystickGuid
    {
        #region Constructor
        public SdlJoystickGuid(string guid)
        {
            _guid = guid.ToUpper();
        }

        public SdlJoystickGuid(Guid guid)
        {
            _guid = guid.ToSdlGuidString().ToUpper();
        }

        private string _guid;
        #endregion

        #region Properties
        public SdlWrappedTechId WrappedTechID
        {
            get
            {
                if (_guid.Length != 32)
                    return SdlWrappedTechId.DirectInput;

                string id = _guid.Substring(28, 2).ToUpper();
                int intValue = int.Parse(id, System.Globalization.NumberStyles.HexNumber);
                return (SdlWrappedTechId)intValue;
            }
        }

        public USB_VENDOR VendorId
        {
            get
            {
                if (_guid.Length != 32)
                    return USB_VENDOR.UNKNOWN;

                string id = (_guid.Substring(10, 2) + _guid.Substring(8, 2)).ToUpper();
                int intValue = int.Parse(id, System.Globalization.NumberStyles.HexNumber);
                return (USB_VENDOR)intValue;
            }
        }

        public USB_PRODUCT ProductId
        {
            get
            {
                if (_guid.Length != 32)
                    return USB_PRODUCT.UNKNOWN;

                string id = (_guid.Substring(18, 2) + _guid.Substring(16, 2)).ToUpper();
                int intValue = int.Parse(id, System.Globalization.NumberStyles.HexNumber);
                return (USB_PRODUCT)intValue;
            }
        }

        public ushort JoystickNameCrc16
        {
            get
            {
                if (_guid.Length != 32)
                    return 0;

                var sdlGuid = _guid.Substring(4, 4).ToUpper();
                return ushort.Parse(sdlGuid, System.Globalization.NumberStyles.HexNumber);
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return _guid;
        }

        public string ToLowerInvariant()
        {
            return _guid.ToLowerInvariant();
        }

        public Guid ToGuid()
        {
            return _guid.FromSdlGuidString();
        }

        public SdlJoystickGuid ToXInputGuid(XINPUT_DEVSUBTYPE subType = XINPUT_DEVSUBTYPE.GAMEPAD)
        {
            if (_guid.Length != 32)
                return new SdlJoystickGuid(_guid);

            return new SdlJoystickGuid(_guid.Substring(0, 28) + "78" + ((byte)subType).ToString("X2"));
        }

        public SdlJoystickGuid ToRawInputGuid()
        {
            if (_guid.Length != 32)
                return new SdlJoystickGuid(_guid);

            return new SdlJoystickGuid(_guid.Substring(0, 28) + "7200");
        }

        public SdlJoystickGuid ConvertSdlGuid(string name, SdlVersion version)
        {
            if (version == SdlVersion.Unknown || _guid.Length != 32)
                return new SdlJoystickGuid(_guid);

            SdlJoystickGuid ret = new SdlJoystickGuid(_guid);

            if (version == SdlVersion.SDL2_26 && name != null)
            {
                var crc16 = SDL.SDL_Swap16(SDL.SDL_crc16(System.Text.Encoding.UTF8.GetBytes(name ?? ""))).ToString("X4");

                var ggs = _guid.Substring(0, 4) + crc16 + _guid.Substring(8);
                ret = new SdlJoystickGuid(ggs);
            }
            else
            {
                // Pre 2.26x : remove '16-bit CRC16 of the joystick name'
                var ggs = _guid.Substring(0, 4) + "0000" + _guid.Substring(8);
                ret = new SdlJoystickGuid(ggs);
                if (version == SdlVersion.SDL2_24)
                    return ret;
            }

            // SDL 2.0.X : remove 8-bit driver-dependent type info for switch controllers
            if (JoystickNameCrc16 == 0xd455) // "HORI Wireless Switch Pad" ??? Must check
                return new SdlJoystickGuid(ret.ToString().Substring(0, 30) + "00");

            if (VendorId == USB_VENDOR.NINTENDO)
            {
                var prod = ProductId;

                if (prod == USB_PRODUCT.NINTENDO_N64_CONTROLLER ||
                    prod == USB_PRODUCT.NINTENDO_SEGA_GENESIS_CONTROLLER ||
                    prod == USB_PRODUCT.NINTENDO_SNES_CONTROLLER ||
                    prod == USB_PRODUCT.NINTENDO_SWITCH_JOYCON_GRIP ||
                    prod == USB_PRODUCT.NINTENDO_SWITCH_JOYCON_LEFT ||
                    prod == USB_PRODUCT.NINTENDO_SWITCH_JOYCON_PAIR ||
                    prod == USB_PRODUCT.NINTENDO_SWITCH_JOYCON_RIGHT ||
                    prod == USB_PRODUCT.NINTENDO_SWITCH_PRO)
                {
                    // Remove 8-bit driver-dependent type info
                    ret = new SdlJoystickGuid(ret.ToString().Substring(0, 30) + "00");
                }
            }

            return ret;
        }
        #endregion

        #region Operators
        public static implicit operator Guid(SdlJoystickGuid p)
        {
            return p._guid.FromSdlGuidString();
        }

        public static implicit operator string(SdlJoystickGuid p)
        {
            return p._guid.ToString();
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            SdlJoystickGuid sg = obj as SdlJoystickGuid;
            if (sg != null)
                return sg._guid == _guid;

            if (obj is Guid)
                return new SdlJoystickGuid((Guid)obj)._guid == _guid;

            if (obj is string)
                return _guid.Equals(obj);

            return object.ReferenceEquals(this, obj);
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public static bool operator ==(SdlJoystickGuid obj1, SdlJoystickGuid obj2) { return obj1.Equals(obj2); }
        public static bool operator !=(SdlJoystickGuid obj1, SdlJoystickGuid obj2) { return !obj1.Equals(obj2); }
        #endregion
    }

    public static class SdlJoystickGuidManager
    {
        public static string ToSdlGuidString(this Guid guid)
        {
            string esGuidString = guid.ToString();

            string ret =
                esGuidString.Substring(6, 2) +
                esGuidString.Substring(4, 2) +
                esGuidString.Substring(2, 2) +
                esGuidString.Substring(0, 2) +
                esGuidString.Substring(10 + 1, 2) +
                esGuidString.Substring(8 + 1, 2) +
                esGuidString.Substring(14 + 2, 2) +
                esGuidString.Substring(12 + 2, 2) +
                esGuidString.Substring(16 + 3, 4) +
                esGuidString.Substring(20 + 4);

            return ret;
        }

        public static System.Guid FromSdlGuidString(this string esGuidString)
        {
            if (esGuidString.Length == 32)
            {
                string guid =
                    esGuidString.Substring(6, 2) +
                    esGuidString.Substring(4, 2) +
                    esGuidString.Substring(2, 2) +
                    esGuidString.Substring(0, 2) +
                    "-" +
                    esGuidString.Substring(10, 2) +
                    esGuidString.Substring(8, 2) +
                    "-" +
                    esGuidString.Substring(14, 2) +
                    esGuidString.Substring(12, 2) +
                    "-" +
                    esGuidString.Substring(16, 4) +
                    "-" +
                    esGuidString.Substring(20);

                try { return new System.Guid(guid); }
                catch { }
            }

            return Guid.Empty;
        }

        public static SdlVersion GetSdlVersion(string fileName)
        {
            if (!File.Exists(fileName))
                return SdlVersion.Unknown;

            System.Version version;

            try
            {
                if (!System.Version.TryParse(FileVersionInfo.GetVersionInfo(fileName).ProductVersion.Replace(",", ".").Replace(" ", ""), out version))
                    return SdlVersion.Unknown;
            }
            catch
            {
                return SdlVersion.Unknown;
            }

            if (version.Minor > 26)
                return SdlVersion.Unknown;

            if (version.Minor > 0)
                return SdlVersion.SDL2_24;

            return SdlVersion.SDL2_0_X;
        }
    }

    public enum SdlVersion
    {
        Unknown,
        SDL2_24,
        SDL2_26,
        SDL2_0_X
    }

    public enum SdlWrappedTechId
    {
        DirectInput = 0,
        HID = 0x68, // 'h'
        RawInput = 0x72, // 'x'
        Virtual = 0x76, // 'v'
        WGI = 0x77, // 'w'
        XInput = 0x78, // 'x'        
    }

    public enum USB_VENDOR
    {
        UNKNOWN = 0,
        EIGHTBITDO = 0x2dc8,
        AMAZON = 0x1949,
        APPLE = 0x05ac,
        DRAGONRISE = 0x0079,
        GOOGLE = 0x18d1,
        HORI = 0x0f0d,
        HYPERKIN = 0x2e24,
        MADCATZ = 0x0738,
        MICROSOFT = 0x045e,
        NACON = 0x146b,
        NINTENDO = 0x057e,
        NVIDIA = 0x0955,
        PDP = 0x0e6f,
        POWERA = 0x24c6,
        POWERA_ALT = 0x20d6,
        QANBA = 0x2c22,
        RAZER = 0x1532,
        SHANWAN = 0x2563,
        SHANWAN_ALT = 0x20bc,
        SONY = 0x054c,
        THRUSTMASTER = 0x044f,
        VALVE = 0x28de,
        ZEROPLUS = 0x0c12
    }

    public enum USB_PRODUCT
    {
        UNKNOWN = 0,
        EIGHTBITDO_XBOX_CONTROLLER = 0x2002,
        AMAZON_LUNA_CONTROLLER = 0x0419,
        GOOGLE_STADIA_CONTROLLER = 0x9400,
        EVORETRO_GAMECUBE_ADAPTER = 0x1846,
        HORI_FIGHTING_COMMANDER_OCTA_SERIES_X = 0x0150,
        HORI_FIGHTING_STICK_ALPHA_PS4 = 0x011c,
        HORI_FIGHTING_STICK_ALPHA_PS5 = 0x0184,
        NINTENDO_GAMECUBE_ADAPTER = 0x0337,
        NINTENDO_N64_CONTROLLER = 0x2019,
        NINTENDO_SEGA_GENESIS_CONTROLLER = 0x201e,
        NINTENDO_SNES_CONTROLLER = 0x2017,
        NINTENDO_SWITCH_JOYCON_GRIP = 0x200e,
        NINTENDO_SWITCH_JOYCON_LEFT = 0x2006,
        NINTENDO_SWITCH_JOYCON_PAIR = 0x2008,
        NINTENDO_SWITCH_JOYCON_RIGHT = 0x2007,
        NINTENDO_SWITCH_PRO = 0x2009,
        NINTENDO_WII_REMOTE = 0x0306,
        NINTENDO_WII_REMOTE2 = 0x0330,
        NVIDIA_SHIELD_CONTROLLER_V103 = 0x7210,
        NVIDIA_SHIELD_CONTROLLER_V104 = 0x7214,
        RAZER_ATROX = 0x0a00,
        RAZER_PANTHERA = 0x0401,
        RAZER_PANTHERA_EVO = 0x1008,
        RAZER_RAIJU = 0x1000,
        RAZER_TOURNAMENT_EDITION_USB = 0x1007,
        RAZER_TOURNAMENT_EDITION_BLUETOOTH = 0x100a,
        RAZER_ULTIMATE_EDITION_USB = 0x1004,
        RAZER_ULTIMATE_EDITION_BLUETOOTH = 0x1009,
        SHANWAN_DS3 = 0x0523,
        SONY_DS3 = 0x0268,
        SONY_DS4 = 0x05c4,
        SONY_DS4_DONGLE = 0x0ba0,
        SONY_DS4_SLIM = 0x09cc,
        SONY_DS5 = 0x0ce6,
        VICTRIX_FS_PRO_V2 = 0x0207,
        XBOX360_XUSB_CONTROLLER = 0x02a1,
        XBOX360_WIRED_CONTROLLER = 0x028e,
        XBOX360_WIRELESS_RECEIVER = 0x0719,
        XBOX_ONE_ADAPTIVE = 0x0b0a,
        XBOX_ONE_ADAPTIVE_BLUETOOTH = 0x0b0c,
        XBOX_ONE_ADAPTIVE_BLE = 0x0b21,
        XBOX_ONE_ELITE_SERIES_1 = 0x02e3,
        XBOX_ONE_ELITE_SERIES_2 = 0x0b00,
        XBOX_ONE_ELITE_SERIES_2_BLUETOOTH = 0x0b05,
        XBOX_ONE_ELITE_SERIES_2_BLE = 0x0b22,
        XBOX_ONE_S = 0x02ea,
        XBOX_ONE_S_REV1_BLUETOOTH = 0x02e0,
        XBOX_ONE_S_REV2_BLUETOOTH = 0x02fd,
        XBOX_ONE_S_REV2_BLE = 0x0b20,
        XBOX_SERIES_X = 0x0b12,
        XBOX_SERIES_X_BLE = 0x0b13,
        XBOX_SERIES_X_VICTRIX_GAMBIT = 0x02d6,
        XBOX_SERIES_X_PDP_BLUE = 0x02d9,
        XBOX_SERIES_X_PDP_AFTERGLOW = 0x02da,
        XBOX_SERIES_X_POWERA_FUSION_PRO2 = 0x4001,
        XBOX_SERIES_X_POWERA_SPECTRA = 0x4002,
        XBOX_ONE_XBOXGIP_CONTROLLER = 0x02ff,
        XBOX_ONE_XINPUT_CONTROLLER = 0x02fe,
        STEAM_VIRTUAL_GAMEPAD = 0x11ff
    }

}
