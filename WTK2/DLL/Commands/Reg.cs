using System;
using Microsoft.Win32;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Commands
{
    /// <summary>
    ///     NEEEDS UPDATING - ONES WITHOUT SUMMARY
    /// </summary>
    public static class Reg
    {
        /// <summary>
        ///     Gets a registry value.
        /// </summary>
        /// <param name="root">HKLM, HKCU, etc..</param>
        /// <param name="key">Software\\Microsoft\\Windows\\...</param>
        /// <param name="item">Value name.</param>
        /// <returns>The value</returns>
        public static string GetValue(RegistryKey root, string key, string item)
        {
            try
            {
                using (var oRegKey = root.OpenSubKey(key, RegistryKeyPermissionCheck.ReadSubTree))
                {
                    if (oRegKey == null)
                        return "";

                    var value = oRegKey.GetValue(item, null);
                    return value == null ? "" : value.ToString();
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        ///     Returns a list of all the items in a registry key
        /// </summary>
        /// <param name="root">HKLM, HKCU, etc..</param>
        /// <param name="key">Software\\Microsoft\\Windows\\...</param>
        /// <returns></returns>
        public static string[] GetAllValues(RegistryKey root, string key)
        {
            try
            {
                using (var oRegKey = root.OpenSubKey(key, RegistryKeyPermissionCheck.ReadSubTree))
                {
                    return oRegKey == null ? null : oRegKey.GetValueNames();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Returns a list of all the items in a registry key
        /// </summary>
        /// <param name="root">HKLM, HKCU, etc..</param>
        /// <param name="key">Software\\Microsoft\\Windows\\...</param>
        /// <returns></returns>
        public static string[] GetAllKeys(RegistryKey root, string key)
        {
            try
            {
                using (var oRegKey = root.OpenSubKey(key, RegistryKeyPermissionCheck.ReadSubTree))
                {
                    return oRegKey == null ? null : oRegKey.GetSubKeyNames();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Checkes if the key exists or not.
        /// </summary>
        /// <param name="root">HKLM, HKCU, etc..</param>
        /// <param name="key">Software\\Microsoft\\Windows\\...</param>
        /// <returns></returns>
        public static bool KeyExist(RegistryKey root, string key)
        {
            using (var oRegKey = root.OpenSubKey(key, RegistryKeyPermissionCheck.ReadSubTree))
            {
                return oRegKey != null;
            }
        }

        /// <summary>
        ///     Writes a value to the registry.
        /// </summary>
        /// <param name="root">HKLM, HKCU, etc..</param>
        /// <param name="key">Software\\Microsoft\\Windows\\...</param>
        /// <param name="valueName">Name of the new value.</param>
        /// <param name="value">The new value which will be saved.</param>
        /// <param name="kind">What type of value is it. string, dword, etc..</param>
        public static void WriteValue(RegistryKey root, string key, string valueName, object value,
            RegistryValueKind kind = RegistryValueKind.String)
        {
            if (key.StartsWithIgnoreCase("WIM_Default\\"))
            {
                if (KeyExist(Registry.LocalMachine, "WIM_Admin"))
                {
                    WriteValue(Registry.LocalMachine, key.ReplaceIgnoreCase("WIM_Default\\", "WIM_Admin\\"), valueName,
                        value, kind);
                }

                if (KeyExist(Registry.LocalMachine, "WIM_SYSDefault"))
                {
                    WriteValue(Registry.LocalMachine, key.ReplaceIgnoreCase("WIM_Default\\", "WIM_SYSDefault\\"),
                        valueName, value, kind);
                }
            }

            using (var oRegKey = root.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                if (oRegKey == null)
                {
                    return;
                }
                oRegKey.SetValue(valueName, value, kind);
            }
        }

        public static void DeleteValue(RegistryKey Loc, string Key, string Reg)
        {
            if (Key.StartsWithIgnoreCase("WIM_Default\\"))
            {
                if (KeyExist(Registry.LocalMachine, "WIM_Admin"))
                {
                    DeleteValue(Registry.LocalMachine, Key.ReplaceIgnoreCase("WIM_Default\\", "WIM_Admin\\"), Reg);
                }

                if (KeyExist(Registry.LocalMachine, "WIM_SYSDefault"))
                {
                    DeleteValue(Registry.LocalMachine, Key.ReplaceIgnoreCase("WIM_Default\\", "WIM_SYSDefault\\"), Reg);
                }
            }

            try
            {
                using (var regKey = Loc.OpenSubKey(Key, true))
                {
                    regKey.DeleteValue(Reg, false);
                    //  WriteLog("DeleteValue:" + root + "\\" + Key + " | " + Reg);
                }
            }
            catch
            {
            }
        }

        public static void DeleteKey(RegistryKey Loc, string pKey, string cKey)
        {
            if (pKey.StartsWithIgnoreCase("WIM_Default\\"))
            {
                if (KeyExist(Registry.LocalMachine, "WIM_Admin"))
                {
                    DeleteKey(Registry.LocalMachine, pKey.ReplaceIgnoreCase("WIM_Default\\", "WIM_Admin\\"), cKey);
                }

                if (KeyExist(Registry.LocalMachine, "WIM_SYSDefault"))
                {
                    DeleteKey(Registry.LocalMachine, pKey.ReplaceIgnoreCase("WIM_Default\\", "WIM_SYSDefault\\"), cKey);
                }
            }

            try
            {
                using (var nRegKey = Loc.OpenSubKey(pKey, true))
                {
                    nRegKey.DeleteSubKeyTree(cKey);
                    // WriteLog("DeleteKey:" + root + "\\" + pKey + "\\" + cKey);
                }
            }
            catch
            {
            }
        }

        private static string ConvertKey(RegistryKey root, string key)
        {
            if (key.ContainsIgnoreCase("CURRENTCONTROLSET"))
            {
                key = key.ReplaceIgnoreCase("CurrentControlSet", "ControlSet001");
            }
            if (!key.StartsWithIgnoreCase("WIM_"))
            {
                switch (Convert.ToString(root))
                {
                    case "HKEY_CURRENT_USER":
                        key = "WIM_Default\\" + key;
                        break;
                    case "HKEY_LOCAL_MACHINE":
                        if (key.StartsWithIgnoreCase("SOFTWARE\\"))
                        {
                            key = "WIM_" + key;
                        }
                        break;
                    case "HKEY_CLASSES_ROOT":
                        key = "WIM_Software\\Classes" + key;
                        break;
                }

                if (key.StartsWithIgnoreCase("SYSTEM"))
                {
                    key = "WIM_" + key;
                }
                if (Convert.ToString(root).EqualsIgnoreCase("HKEY_USERS") && key.ContainsIgnoreCase(".DEFAULT\\"))
                {
                    key = "WIM_Default\\" + key.ReplaceIgnoreCase(".DEFAULT\\", "");
                }
            }

            key = key.ReplaceIgnoreCase("\\\\", "\\");
            return key;
        }

        public static bool DisableAutoPlay()
        {
            var result = GetValue(Registry.CurrentUser,
                "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoDriveTypeAutoRun");
            var backup = GetValue(Registry.CurrentUser,
                "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoDriveTypeAutoRun_Backup");
            if (!string.IsNullOrWhiteSpace(result) && string.IsNullOrWhiteSpace(backup))
            {
                WriteValue(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer",
                    "NoDriveTypeAutoRun_Backup", result, RegistryValueKind.DWord);
            }
            WriteValue(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer",
                "NoDriveTypeAutoRun", 149, RegistryValueKind.DWord);
            return true;
        }

        public static bool RestoreAutoPlay()
        {
            var backup = GetValue(Registry.CurrentUser,
                "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoDriveTypeAutoRun_Backup");
            if (!string.IsNullOrWhiteSpace(backup))
            {
                WriteValue(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer",
                    "NoDriveTypeAutoRun", backup, RegistryValueKind.DWord);
                DeleteValue(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer",
                    "NoDriveTypeAutoRun_Backup");
            }
            else
            {
                DeleteValue(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer",
                    "NoDriveTypeAutoRun");
            }
            return true;
        }
    }
}