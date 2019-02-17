using System;
using System.ComponentModel;
using WinToolkitDLL.Commands;

namespace WinToolkitDLL.Extensions
{
    public static class Numbers
    {
        /// <summary>
        ///     Converts number into x,xx MB
        /// </summary>
        /// <param name="source">The size.</param>
        /// <returns>2.5GB</returns>
        public static string toStringSize(this long source)
        {
            return FileHandling.BytesToString(source);
        }

        /// <summary>
        ///     Converts number into x,xx MB
        /// </summary>
        /// <param name="source">The size.</param>
        /// <returns>2.5GB</returns>
        public static string toStringSize(this double source)
        {
            return FileHandling.BytesToString(source);
        }

        /// <summary>
        ///     Converts number into x,xx MB
        /// </summary>
        /// <param name="source">The size.</param>
        /// <returns>2.5GB</returns>
        public static string toStringSize(this int source)
        {
            return FileHandling.BytesToString(source);
        }

        public static T Parse<T>(this string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T TryParse<T>(this string value)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (!converter.IsValid(value) || converter is null)
                {
                    return default(T);
                }

                // Cast ConvertFromString(string text) : object to (T)
                return (T)converter.ConvertFromString(value);
            }
            catch (Exception ex)
            {
                return default(T);
            }

        }
    }
}