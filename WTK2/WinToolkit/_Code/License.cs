using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using WinToolkitDLL;

namespace WinToolkitv2._Code
{
    public static class Product
    {
        private static ProductMode _mode = ProductMode.Pro; //Needs to be 'Free'

        internal static ProductMode Mode
        {
            get { return _mode; }
        }

        internal static void SetMode(ProductMode mode)
        {
            _mode = mode;
        }

        internal static void SetMode(string mode)
        {
            _mode = (ProductMode)Enum.Parse(typeof(ProductMode),mode);
        }

        internal static DateTime BuildDate
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.MinorRevision * 2);
            }
        }

    }

    internal enum ProductMode
    {
        Free,
        Home,
        Pro,
        Debugger
    }




}