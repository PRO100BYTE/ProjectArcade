﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using emulatorLauncher;

namespace TeknoParrotUi.Common
{
    public class JoystickHelper
    {
        /// <summary>
        /// Serializes GameProfile class to a GameProfile.xml file.
        /// </summary>
        /// <param name="profile"></param>
        public static void SerializeGameProfile(GameProfile profile, string filename = "")
        {
            var serializer = new XmlSerializer(profile.GetType());
            using (var writer = XmlWriter.Create(filename == "" ? Path.Combine("UserProfiles", Path.GetFileName(profile.FileName)) : filename, new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(writer, profile);
            }
        }

        /// <summary>
        /// Deserializes GameProfile.xml to the class.
        /// </summary>
        /// <returns>Read Gameprofile class.</returns>
        public static GameProfile DeSerializeGameProfile(string fileName, bool userProfile)
        {
            if (!File.Exists(fileName))
                return null;

            try
            {
                var serializer = new XmlSerializer(typeof(GameProfile));
                
                GameProfile profile;
                using (var reader = XmlReader.Create(fileName))
                    profile = (GameProfile)serializer.Deserialize(reader);
                                
#if !DEBUG
                if (profile.DevOnly)
                {
                    SimpleLogger.Instance.Warning("Skipping loading dev profile " + fileName);
                    return null;
                }
#endif

                if (profile.Is64Bit && !Environment.Is64BitOperatingSystem)
                {
                    SimpleLogger.Instance.Warning("Skipping loading profile (64 bit profile on 32 bit OS)");
                    return null;
                }

                // migrate stuff in case names get changed, only for UserProfiles
                if (userProfile)
                {
                    if (profile.EmulationProfile == "FNFDrift")
                    {
                        profile.EmulationProfile = "RawThrillsFNF";
                        SerializeGameProfile(profile, fileName);
                    }

                    if (profile.ConfigValues != null)
                    {
                        var list = profile.ConfigValues.FindAll(x => x.FieldName != null && x.FieldName.Contains("Sensitivity"));
                        if (list.Count > 0)
                        {
                            var oldVars = new HashSet<string> { "Low", "Medium Low", "Medium", "Medium High", "High", "Instant" };

                            foreach (FieldInformation f in list)
                            {
                                if (f.FieldType != "Slider" || oldVars.Contains(f.FieldValue))
                                {
                                    f.FieldType = "Slider";

                                    switch (f.FieldValue)
                                    {
                                        case "Low":
                                            f.FieldValue = "10";
                                            break;
                                        case "Medium Low":
                                            f.FieldValue = "32";
                                            break;
                                        case "Medium":
                                            f.FieldValue = "63";
                                            break;
                                        case "Medium High":
                                            f.FieldValue = "95";
                                            break;
                                        case "High":
                                            f.FieldValue = "111";
                                            break;
                                        case "Instant":
                                            f.FieldValue = "127";
                                            break;
                                    }
                                }
                                else
                                    continue;

                                int index = profile.ConfigValues.FindIndex(x => x.FieldName == f.FieldName);
                                if (index >= 0)
                                    profile.ConfigValues[index] = f;
                            }

                            SerializeGameProfile(profile, fileName);
                        }
                    }
                }

                // Add filename to profile
                profile.FileName = fileName;

                return profile;
            }
            catch (Exception e)
            {
                SimpleLogger.Instance.Error("[TeknoParrotUi] " + e.Message, e);
                return null;
            }
        }

    }
}
