using Microsoft.Win32;
using WinToolkitDLL.Commands;

namespace WinToolkitDLL.Objects.WimImage
{
    public abstract class RegistryMount
    {
        protected string _filePath;
        protected string _key;
        protected string _mountPath;
        protected string _uniqueID;

        protected RegistryMount()
        {
            _uniqueID = Misc.RandomString();
        }

        public bool Mounted
        {
            get { return Reg.KeyExist(Registry.LocalMachine, _key); }
        }

        public bool Mount()
        {
            return Mounted;
        }

        public bool Unmount()
        {
            return Mounted;
        }

        public void WriteValue(string key, string valueName, object value,
            RegistryValueKind kind = RegistryValueKind.String)
        {
            Reg.WriteValue(Registry.LocalMachine, _key + "\\" + key, valueName, value, kind);
        }

        public void DeleteValue(string key, string reg)
        {
            Reg.DeleteValue(Registry.LocalMachine, _key + "\\" + key, reg);
        }

        public void DeleteKey(string pKey, string cKey)
        {
            Reg.DeleteKey(Registry.LocalMachine, _key + "\\" + pKey, cKey);
        }

        public bool KeyExist(string key)
        {
            return Reg.KeyExist(Registry.LocalMachine, _key + "\\" + key);
        }

        public string[] GetAllKeys(string key)
        {
            return Reg.GetAllKeys(Registry.LocalMachine, _key + "\\" + key);
        }

        public string[] GetAllValues(string key)
        {
            return Reg.GetAllValues(Registry.LocalMachine, _key + "\\" + key);
        }

        public string GetValue(string key, string item)
        {
            return Reg.GetValue(Registry.LocalMachine, _key + "\\" + key, item);
        }
    }

    public class SYSTEM : RegistryMount
    {
        public SYSTEM(string mountPath)
        {
            _mountPath = mountPath;
            _key = "WIM_SYSTEM_" + _uniqueID;
            _filePath = mountPath + "\\Windows\\System32\\Config\\SYSTEM";
        }
    }

    public class SOFTWARE : RegistryMount
    {
        public SOFTWARE(string mountPath)
        {
            _mountPath = mountPath;
            _key = "WIM_SOFTWARE_" + _uniqueID;
            _filePath = mountPath + "\\Windows\\System32\\Config\\SOFTWARE";
        }
    }

    public class USER : RegistryMount
    {
        public USER(string mountPath)
        {
            _mountPath = mountPath;
            _key = "WIM_SOFTWARE_" + _uniqueID;
            _filePath = mountPath + "\\Users\\Default\\NTUSER.DAT";
        }
    }

    public class ADMIN : RegistryMount
    {
        public ADMIN(string mountPath)
        {
            _mountPath = mountPath;
            _key = "WIM_SOFTWARE_" + _uniqueID;
            _filePath = mountPath + "\\Users\\Administrator\\NTUSER.DAT";
        }
    }
}