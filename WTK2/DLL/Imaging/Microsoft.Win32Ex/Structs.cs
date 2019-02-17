using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using BYTE = System.Byte;
using DWORD = System.UInt32;
using SECURITY_DESCRIPTOR_CONTROL = System.Int16;
using PSID = System.IntPtr;
using PACL = System.IntPtr;
using WORD = System.UInt16;

namespace Microsoft.Win32
{
    /// <summary>
    ///     Contains a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        /// <summary>
        ///     The low-order part of the file time.
        /// </summary>
        public uint dwLowDateTime;

        /// <summary>
        ///     The high-order part of the file time.
        /// </summary>
        public uint dwHighDateTime;

        /// <summary>
        ///     Creates a new instance of the FILETIME struct.
        /// </summary>
        /// <param name="dateTime">A <see cref="DateTime" /> object to copy data from.</param>
        public FILETIME(DateTime dateTime)
        {
            // Get the file time as a long in Utc
            //
            var fileTime = dateTime.ToFileTimeUtc();

            // Copy the low bits
            //
            dwLowDateTime = (uint) (fileTime & 0xFFFFFFFF);

            // Copy the high bits
            //
            dwHighDateTime = (uint) (fileTime >> 32);
        }

        /// <summary>
        ///     Converts a <see cref="FILETIME" /> to a <see cref="System.DateTime" />
        /// </summary>
        public static implicit operator DateTime(FILETIME fileTime)
        {
            return fileTime.ToDateTime();
        }

        /// <summary>
        ///     Converts a <see cref="System.DateTime" /> to a <see cref="FILETIME" />.
        /// </summary>
        public static implicit operator FILETIME(DateTime dateTime)
        {
            return new FILETIME(dateTime);
        }

        /// <summary>
        ///     Gets the current FILETIME as a <see cref="DateTime" /> object.
        /// </summary>
        /// <returns>A <see cref="DateTime" /> object that represents the FILETIME.</returns>
        public DateTime ToDateTime()
        {
            // Convert the file time to a long and then to a DateTime
            //
            return DateTime.FromFileTimeUtc((long) dwHighDateTime << 32 | dwLowDateTime);
        }

        /// <summary>
        ///     Converts the value of the current FILETIME object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of value of the current FILETIME object</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The date and time is outside the range of dates supported by the calendar
        ///     used by the current culture.
        /// </exception>
        public override string ToString()
        {
            // Call the DateTime.ToString() method
            //
            return ((DateTime) this).ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        ///     Converts the value of the current FILETIME object to its equivalent string representation using the specified
        ///     culture-specific format information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current FILETIME object as specified by provider.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The date and time is outside the range of dates supported by the calendar
        ///     used by provider.
        /// </exception>
        public string ToString(IFormatProvider provider)
        {
            // Call the DateTime.ToString() method
            //
            return ((DateTime) this).ToString(provider);
        }

        /// <summary>
        ///     Converts the value of the current DateTime object to its equivalent string representation using the specified
        ///     format.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current DateTime object as specified by format.</returns>
        /// <exception cref="FormatException">
        ///     The length of format is 1, and it is not one of the format specifier characters defined for DateTimeFormatInfo.
        ///     -or-
        ///     format does not contain a valid custom format pattern.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The date and time is outside the range of dates supported by the calendar
        ///     used by the current culture.
        /// </exception>
        public string ToString(string format)
        {
            // Call the DateTime.ToString() method
            //
            return ((DateTime) this).ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        ///     Converts the value of the current DateTime object to its equivalent string representation using the specified
        ///     format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current DateTime object as specified by format and provider.</returns>
        /// <exception cref="FormatException">
        ///     The length of format is 1, and it is not one of the format specifier characters defined for DateTimeFormatInfo.
        ///     -or-
        ///     format does not contain a valid custom format pattern.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The date and time is outside the range of dates supported by the calendar
        ///     used by the current culture.
        /// </exception>
        public string ToString(string format, IFormatProvider provider)
        {
            // Call the DateTime.ToString() method
            //
            return ((DateTime) this).ToString(format, provider);
        }
    }

    /// <summary>
    ///     Represents a security descriptor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_DESCRIPTOR
    {
        /// <summary>
        /// </summary>
        public byte Revision;

        /// <summary>
        /// </summary>
        public byte Sbz1;

        /// <summary>
        /// </summary>
        public short Control;

        /// <summary>
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")] public PSID Owner;

        /// <summary>
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")] public PSID Group;

        /// <summary>
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")] public PACL Sacl;

        /// <summary>
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")] public PACL Dacl;
    }

    /// <summary>
    ///     Specifies a date and time, using individual members for the month, day, year, weekday, hour, minute, second, and
    ///     millisecond. The time is either in coordinated universal time (UTC) or local time, depending on the function that
    ///     is being called.
    /// </summary>
    /// <remarks>
    ///     It is not recommended that you add and subtract values from the SYSTEMTIME structure to obtain relative times.
    ///     Instead, you should
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Convert the SYSTEMTIME structure to a FILETIME structure.</description>
    ///         </item>
    ///         <item>
    ///             <description>Copy the resulting FILETIME structure to a ULARGE_INTEGER structure.</description>
    ///         </item>
    ///         <item>
    ///             <description>Use normal 64-bit arithmetic on the ULARGE_INTEGER value.</description>
    ///         </item>
    ///     </list>
    ///     The system can periodically refresh the time by synchronizing with a time source. Because the system time can be
    ///     adjusted either forward or backward, do not compare system time readings to determine elapsed time. Instead, use
    ///     one of the methods described in Windows Time.
    /// </remarks>
    /// <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms724950(v=vs.85).aspx" />
    /// <![CDATA[typedef struct _SYSTEMTIME {
    ///  WORD wYear;
    ///    WORD wMonth;
    ///    WORD wDayOfWeek;
    ///    WORD wDay;
    ///    WORD wHour;
    ///    WORD wMinute;
    ///    WORD wSecond;
    ///    WORD wMilliseconds;
    ///  } SYSTEMTIME, *PSYSTEMTIME;]]>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        /// <summary>
        ///     The year. The valid values for this member are 1601 through 30827.
        /// </summary>
        public ushort wYear;

        /// <summary>
        ///     The month. January = 1 and December = 12
        /// </summary>
        public ushort wMonth;

        /// <summary>
        ///     The day of the week. Sunday = 0 and Saturday = 6
        /// </summary>
        public ushort wDayOfWeek;

        /// <summary>
        ///     The day of the month. The valid values for this member are 1 through 31.
        /// </summary>
        public ushort wDay;

        /// <summary>
        ///     The hour. The valid values for this member are 0 through 23.
        /// </summary>
        public ushort wHour;

        /// <summary>
        ///     The minute. The valid values for this member are 0 through 59.
        /// </summary>
        public ushort wMinute;

        /// <summary>
        ///     The second. The valid values for this member are 0 through 59.
        /// </summary>
        public ushort wSecond;

        /// <summary>
        ///     The millisecond. The valid values for this member are 0 through 999.
        /// </summary>
        public ushort wMilliseconds;

        /// <summary>
        ///     Initializes a new instance of the SYSTEMTIME class.
        /// </summary>
        /// <param name="dateTime">An existing DateTime object to copy data from.</param>
        public SYSTEMTIME(DateTime dateTime)
        {
            var utc = dateTime.ToUniversalTime();

            wYear = (ushort) utc.Year;
            wMonth = (ushort) utc.Month;
            wDay = (ushort) utc.Day;
            wDayOfWeek = (ushort) utc.DayOfWeek;
            wHour = (ushort) utc.Hour;
            wMinute = (ushort) utc.Minute;
            wSecond = (ushort) utc.Second;
            wMilliseconds = (ushort) utc.Millisecond;
        }

        /// <summary>
        ///     Returns the SYSTEMTIME as a <see cref="System.DateTime" /> value.
        /// </summary>
        /// <returns>A <see cref="System.DateTime" /> value.</returns>
        public DateTime ToDateTime()
        {
            if (wYear == 0)
            {
                return DateTime.MinValue;
            }
            return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, DateTimeKind.Utc);
        }

        /// <summary>
        ///     Converts a <see cref="System.DateTime" /> to a <see cref="SYSTEMTIME" />.
        /// </summary>
        public static implicit operator SYSTEMTIME(DateTime dateTime)
        {
            return new SYSTEMTIME(dateTime);
        }

        /// <summary>
        ///     Converts a <see cref="SYSTEMTIME" /> to a <see cref="System.DateTime" />
        /// </summary>
        public static implicit operator DateTime(SYSTEMTIME systemTime)
        {
            return systemTime.ToDateTime();
        }
    }

    /// <summary>
    ///     Contains information about the file that is found by the FindFirstFile, FindFirstFileEx, or FindNextFile function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WIN32_FIND_DATA
    {
        /// <summary>
        ///     The file attributes of a file.
        /// </summary>
        public FileAttributes dwFileAttributes;

        /// <summary>
        ///     A <see cref="System.Runtime.InteropServices.ComTypes.FILETIME" /> structure that specifies when a file or directory
        ///     was created.
        ///     If the underlying file system does not support creation time, this member is zero.
        /// </summary>
        public FILETIME ftCreationTime;

        /// <summary>
        ///     A <see cref="System.Runtime.InteropServices.ComTypes.FILETIME" /> structure.
        ///     For a file, the structure specifies when the file was last read from, written to, or for executable files, run.
        ///     For a directory, the structure specifies when the directory is created. If the underlying file system does not
        ///     support last access time, this member is zero.
        ///     On the FAT file system, the specified date for both files and directories is correct, but the time of day is always
        ///     set to midnight.
        /// </summary>
        public FILETIME ftLastAccessTime;

        /// <summary>
        ///     A <see cref="System.Runtime.InteropServices.ComTypes.FILETIME" /> structure.
        ///     For a file, the structure specifies when the file was last written to, truncated, or overwritten, for example, when
        ///     WriteFile or SetEndOfFile are used. The date and time are not updated when file attributes or security descriptors
        ///     are changed.
        ///     For a directory, the structure specifies when the directory is created. If the underlying file system does not
        ///     support last write time, this member is zero.
        /// </summary>
        public FILETIME ftLastWriteTime;

        /// <summary>
        ///     The high-order DWORD value of the file size, in bytes.
        ///     This value is zero unless the file size is greater than MAXDWORD.
        ///     The size of the file is equal to (nFileSizeHigh * (MAXDWORD+1)) + nFileSizeLow.
        /// </summary>
        public uint nFileSizeHigh;

        /// <summary>
        ///     The low-order DWORD value of the file size, in bytes.
        /// </summary>
        public uint nFileSizeLow;

        /// <summary>
        ///     If the dwFileAttributes member includes the FILE_ATTRIBUTE_REPARSE_POINT attribute, this member specifies the
        ///     re-parse point tag.
        ///     Otherwise, this value is undefined and should not be used.
        /// </summary>
        public uint dwReserved0;

        /// <summary>
        ///     Reserved for future use.
        /// </summary>
        public uint dwReserved1;

        /// <summary>
        ///     The name of the file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Win32Api.MAX_PATH)] public string cFileName;

        /// <summary>
        ///     An alternative name for the file.
        ///     This name is in the classic 8.3 file name format.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)] public string cAlternateFileName;

        /// <summary>
        ///     Gets the file size by combining nFileSizeLow and nFileSizeHigh.
        /// </summary>
        public long FileSize
        {
            get { return (nFileSizeHigh*((long) uint.MaxValue + 1)) + nFileSizeLow; }
        }
    }
}