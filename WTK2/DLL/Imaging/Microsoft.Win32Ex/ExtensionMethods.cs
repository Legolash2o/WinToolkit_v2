using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    ///     Extension methods for objects in the System namespace.
    /// </summary>
    public static class Win32ExExtensionMethods
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this IntPtr ptr, int count)
        {
            if (count == 0)
            {
                yield break;
            }

            // Calculate the size of the struct
            //
            var structSize = Marshal.SizeOf(typeof (T));

            // Get the starting point as a long
            //
            var startPtr = ptr.ToInt64();

            // Loop through each pointer
            //
            for (var i = 0; i < count; i++)
            {
                // Get the address of the current structure
                //
                var currentPtr = new IntPtr(startPtr + (i*structSize));

                // Return the structure at the current pointer
                //
                yield return currentPtr.ToStructure<T>();
            }
        }

        /// <summary>
        ///     Marshals data of the ICollection to unmanaged memory.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="items">The <see cref="ICollection{T}" /> to marshal.</param>
        /// <returns>
        ///     A pointer to the newly allocated memory. This memory must be released using the
        ///     <see cref="Marshal.FreeHGlobal" /> method.
        /// </returns>
        public static IntPtr ToIntPtr<T>(this ICollection<T> items)
        {
            var elementSize = Marshal.SizeOf(typeof (T));

            var ptr = Marshal.AllocHGlobal(elementSize*items.Count);

            var startPtr = ptr.ToInt64();

            var i = 0;

            foreach (var item in items)
            {
                Marshal.StructureToPtr(item, new IntPtr(startPtr + (i++*elementSize)), false);
            }

            return ptr;
        }

        /// <summary>
        ///     Copies all characters up to the first null character from an unmanaged ANSI string to a managed String, and widens
        ///     each ANSI character to Unicode.
        /// </summary>
        /// <param name="ptr">The address of the first character of the unmanaged string.</param>
        /// <returns>
        ///     A managed string that holds a copy of the unmanaged ANSI string. If <paramref name="ptr" /> is null, the
        ///     method returns a null string.
        /// </returns>
        public static string ToStringAnsi(this IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <summary>
        ///     Allocates a managed String and copies all characters up to the first null character from a string stored in
        ///     unmanaged memory into it.
        /// </summary>
        /// <param name="ptr">
        ///     For Unicode platforms, the address of the first Unicode character.
        ///     -or-
        ///     For ANSI platforms, the address of the first ANSI character.
        /// </param>
        /// <returns>
        ///     A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" />
        ///     parameter is not null; otherwise, this method returns null.
        /// </returns>
        public static string ToStringAuto(this IntPtr ptr)
        {
            return Marshal.PtrToStringAuto(ptr);
        }

        /// <summary>
        ///     Allocates a managed String and copies all characters up to the first null character from a string stored in
        ///     unmanaged memory into it.
        /// </summary>
        /// <param name="ptr">
        ///     For Unicode platforms, the address of the first Unicode character.
        ///     -or-
        ///     For ANSI platforms, the address of the first ANSI character.
        /// </param>
        /// <param name="len">The number of characters to copy.</param>
        /// <returns>
        ///     A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" />
        ///     parameter is not null; otherwise, this method returns null.
        /// </returns>
        public static string ToStringAuto(this IntPtr ptr, int len)
        {
            return Marshal.PtrToStringAuto(ptr, len);
        }

        /// <summary>
        ///     Allocates a managed String and copies a BSTR Data Type string stored in unmanaged memory into it.
        /// </summary>
        /// <param name="ptr">The address of the first character of the unmanaged string.</param>
        /// <returns>
        ///     A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" />
        ///     parameter is not null; otherwise, this method returns null.
        /// </returns>
        public static string ToStringBSTR(this IntPtr ptr)
        {
            return Marshal.PtrToStringBSTR(ptr);
        }

        /// <summary>
        ///     Allocates a managed String and copies a specified number of characters from an unmanaged Unicode string into it.
        /// </summary>
        /// <param name="ptr">The address of the first character of the unmanaged string.</param>
        /// <returns>
        ///     A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" />
        ///     parameter is not null; otherwise, this method returns null.
        /// </returns>
        public static string ToStringUni(this IntPtr ptr)
        {
            return Marshal.PtrToStringUni(ptr);
        }

        /// <summary>
        ///     Allocates a managed String and copies a specified number of characters from an unmanaged Unicode string into it.
        /// </summary>
        /// <param name="ptr">The address of the first character of the unmanaged string.</param>
        /// <param name="len">The number of Unicode characters to copy.</param>
        /// <returns>
        ///     A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" />
        ///     parameter is not null; otherwise, this method returns null.
        /// </returns>
        public static string ToStringUni(this IntPtr ptr, int len)
        {
            return Marshal.PtrToStringUni(ptr, len);
        }

        /// <summary>
        ///     Marshals data from an unmanaged block of memory to a newly allocated managed object of the specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     The System.Type of object to be created. This type object must represent a formatted class or a
        ///     structure.
        /// </typeparam>
        /// <param name="ptr">A pointer to an unmanaged block of memory.</param>
        /// <returns>A managed object containing the data pointed to by the ptr parameter.</returns>
        /// <exception cref="ArgumentException">
        ///     The T parameter layout is not sequential or explicit.
        ///     -or-
        ///     The T parameter is a generic type.
        /// </exception>
        public static T ToStructure<T>(this IntPtr ptr)
        {
            return (T) Marshal.PtrToStructure(ptr, typeof (T));
        }
    }
}

#if NET20
namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    internal sealed class ExtensionAttribute : Attribute
    {
    }
}
#endif