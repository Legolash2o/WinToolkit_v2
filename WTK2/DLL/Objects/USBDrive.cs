using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Controls;
using Microsoft.Win32.SafeHandles;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects
{
    public class USBDrive
    {
        private readonly bool _bootable;
        private readonly int _disk;
        private readonly long _driveSize;
        private readonly string _driveStatus;
        private readonly DriveFormat _format;
        private readonly long _free;
        private readonly string _model;
        private readonly long _size;
        private readonly long _used;
        //letter, disk, partition, label, format, used, free, size, type, bootable, status
        private string _image = "/Images/_Global/Delete_16.png";
        private string _label;
        private int _partition;
        private Status _status;

        public USBDrive(string model, string driveLetter, int disk, int partition, string label, string format,
            long driveSize, long size, long free, bool bootable, string status, BootRecord bootRecord)
        {
            _model = model;
            Letter = driveLetter;
            _disk = disk;
            _label = label;
            _driveSize = driveSize;
            _partition = partition;
            _free = free;
            _size = size;
            _used = _size - _free;
            _bootable = bootable;
            if (!Enum.TryParse(format, true, out _format))
            {
                _format = DriveFormat.Unknown;
            }
            BootRecord = bootRecord;
            _driveStatus = status;

            if (BootRecord == BootRecord.GPT && !Letter.EqualsIgnoreCase("None"))
            {
                Status = Status.Success;
            }
            else if (_bootable)
            {
                Status = Status.Success;
            }
            else if (BootRecord == BootRecord.Hybrid)
            {
                Status = Status.Success;
            }

            if (!_driveStatus.EqualsIgnoreCase("OK") || LargerThan32Gb)
            {
                Status = Status.Incompatible;
            }
        }

        public Status Status
        {
            get { return _status; }
            set
            {
                _status = value;
                switch (_status)
                {
                    case Status.Incompatible:
                        _image = "/Images/_Global/Incompatible_16.png";
                        break;
                    case Status.Failed:
                        _image = "/Images/_Global/Delete_16.png";
                        break;
                    case Status.Success:
                        _image = "/Images/_Global/OK_16.png";
                        break;
                    case Status.Working:
                        _image = "/Images/_Global/Start_16.png";
                        break;
                }
            }
        }

        public string Model
        {
            get { return _model + " [" + FileHandling.BytesToString(_driveSize) + "]"; }
        }

        public string Letter { get; private set; }

        public string Label
        {
            get { return _label; }
            set
            {
                foreach (
                    var d in
                        DriveInfo.GetDrives()
                            .Where(
                                d =>
                                    d.IsReady && d.DriveType == DriveType.Removable &&
                                    d.Name.StartsWithIgnoreCase(Letter)))
                {
                    d.VolumeLabel = value;
                }
                _label = value;
            }
        }

        public DriveFormat Format
        {
            get { return _format; }
        }

        public string Size
        {
            get { return FileHandling.BytesToString(_size); }
        }

        public string Used
        {
            get { return FileHandling.BytesToString(_used); }
        }

        public string Free
        {
            get { return FileHandling.BytesToString(_free); }
        }

        public string Image
        {
            get { return _image; }
        }

        public BootRecord BootRecord { get; private set; }

        public string Boot
        {
            get
            {
                switch (BootRecord)
                {
                    case BootRecord.Hybrid:
                        return "HYBRID";
                    case BootRecord.GPT:
                        return "UEFI";
                    default:
                        return "BIOS";
                }
            }
        }

        public bool LargerThan32Gb
        {
            get { return (_size > Sizes.GB32) || (_size == 0 && _driveSize > Sizes.GB32); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private static void UpdateLabel(ProgressBar progressBar, int progress)
        {
            if (progressBar == null)
                return;
            progressBar.Dispatcher.Invoke(() => { progressBar.Value = progress; });
        }

        public string PrepareUSB_MBR(bool quickFormat,
            DriveFormat driveFormat, ProgressBar progressBar)
        {
            if (_disk == 0)
            {
                throw new InvalidOperationException("Win Toolkit will not attempted to work with the system drive.");
            }

            if (driveFormat == DriveFormat.FAT32 && LargerThan32Gb)
            {
                throw new InvalidOperationException("Volume cannot be bigger than 30GB.");
            }

            if (driveFormat == _format && _bootable && BootRecord == BootRecord.MBR)
            {
                OnPropertyChanged("Skipping");
                return "Skipping";
            }

            if (_bootable && _format == DriveFormat.FAT32 && driveFormat == DriveFormat.NTFS)
            {
                OnPropertyChanged("Converting to NTFS...");
                var result = Processes.Run("convert", Letter + " /fs:NTFS");
                return result;
            }

            if (driveFormat == _format && _bootable && BootRecord == BootRecord.GPT)
            {
                OnPropertyChanged("Skipping");
                return "Skipping";
            }

            OnPropertyChanged("Preparing...");

            var Tas = "Select Disk " + _disk + Environment.NewLine;

            var full = BootRecord != BootRecord.MBR || _partition == -1;

            if (full)
            {
                Tas += "CLEAN" + Environment.NewLine;
                if (BootRecord != BootRecord.MBR)
                {
                    Tas += "CONVERT MBR";
                }

                Tas += "CREATE PARTITION PRIMARY ALIGN=512" + Environment.NewLine;
                _partition = 1;
            }

            Tas += "SELECT PARTITION " + _partition + Environment.NewLine;

            if (full || _format != driveFormat)
            {
                if (!Letter.EqualsIgnoreCase("None"))
                {
                    Tas += "REMOVE" + Environment.NewLine;
                }

                if (quickFormat)
                {
                    Tas += "FORMAT FS=" + driveFormat + " LABEL=\"" + _label + "\" QUICK" +
                           Environment.NewLine;
                }
                else
                {
                    Tas += "FORMAT FS=" + driveFormat + " LABEL=\"" + _label + "\"" + Environment.NewLine;
                }
            }
            Tas += "ACTIVE" + Environment.NewLine;

            if (full || _format != driveFormat || Letter.EqualsIgnoreCase("None"))
            {
                Tas += "ASSIGN" + Environment.NewLine;
            }

            Tas += "EXIT";

            UpdateLabel(progressBar, 20);
            OnPropertyChanged("Working...");
            var SW = new StreamWriter("C:\\T.txt");
            SW.Write(Tas);
            SW.Close();
            var R = Processes.Run("\"" + Directories.System32 + "\\DiskPart.exe\"", "/s C:\\T.txt");
            UpdateLabel(progressBar, 90);
            FileHandling.DeleteFile("C:\\T.txt");
            return R;
        }

        public string PrepareUSB_GPT(bool quickFormat, ProgressBar progressBar)
        {
            if (_disk == 0)
            {
                throw new InvalidOperationException("Win Toolkit will not attempted to work with the system drive.");
            }
            if (LargerThan32Gb)
            {
                throw new InvalidOperationException("Volume cannot be bigger than 30GB. UEFI requires FAT32.");
            }
            OnPropertyChanged("Preparing...");
            var Tas = "Select Disk " + _disk + Environment.NewLine;

            var full = BootRecord != BootRecord.GPT || _partition == -1;

            if (BootRecord != BootRecord.GPT)
            {
                Tas += "CLEAN" + Environment.NewLine;
                Tas += "CONVERT GPT" + Environment.NewLine;
                Tas += "CREATE PARTITION PRIMARY ALIGN=512" + Environment.NewLine;
                _partition = 1;
            }

            Tas += "SELECT PARTITION " + _partition + Environment.NewLine;


            if (full || _format != DriveFormat.FAT32)
            {
                if (!Letter.EqualsIgnoreCase("None"))
                {
                    Tas += "REMOVE" + Environment.NewLine;
                }
                if (quickFormat)
                {
                    Tas += "FORMAT FS=FAT32 LABEL=\"" + _label + "\" QUICK" + Environment.NewLine;
                }
                else
                {
                    Tas += "FORMAT FS=FAT32 LABEL=\"" + _label + "\"" + Environment.NewLine;
                }
            }

            if (full || Letter.EqualsIgnoreCase("None"))
            {
                Tas += "ASSIGN" + Environment.NewLine;
            }

            Tas += "EXIT";
            UpdateLabel(progressBar, 20);
            OnPropertyChanged("Working...");
            using (var SW = new StreamWriter("C:\\T.txt"))
            {
                SW.Write(Tas);
            }

            var R = Processes.Run("\"" + Directories.System32 + "\\DiskPart.exe\"", "/s C:\\T.txt");
            UpdateLabel(progressBar, 90);
            FileHandling.DeleteFile("C:\\T.txt");
            return R;
        }
    }

    public class IOCtl
    {
        //http://brianhehir.blogspot.co.uk/2011/12/kernel32dll-deviceiocontrol-in-c.html
        private const int GENERIC_READ = unchecked((int) 0x80000000);
        private const int FILE_SHARE_READ = 1;
        private const int FILE_SHARE_WRITE = 2;
        private const int OPEN_EXISTING = 3;
        private const int IOCTL_DISK_GET_DRIVE_LAYOUT_EX = unchecked(0x00070050);
        private const int ERROR_INSUFFICIENT_BUFFER = 122;

        public static BootRecord SendIoCtlDiskGetDriveLayoutEx(int PhysicalDrive)
        {
            var lie = default(DRIVE_LAYOUT_INFORMATION_EX);
            var _bootrecord = BootRecord.RAW;

            using (var hDevice =
                NativeMethods.CreateFile("\\\\.\\PHYSICALDRIVE" + PhysicalDrive, GENERIC_READ,
                    FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero))
            {
                if (hDevice.IsInvalid)
                    throw new Win32Exception();
                // Must run as administrator, otherwise we get "ACCESS DENIED"

                // We don't know how many partitions there are, so we have to use a blob of memory...
                var numPartitions = 1;
                var done = false;
                do
                {
                    // 48 = the number of bytes in DRIVE_LAYOUT_INFORMATION_EX up to
                    // the first PARTITION_INFORMATION_EX in the array.
                    // And each PARTITION_INFORMATION_EX is 144 bytes.
                    var outBufferSize = 48 + (numPartitions*144);
                    var blob = default(IntPtr);
                    var bytesReturned = 0;
                    var result = false;


                    try
                    {
                        blob = Marshal.AllocHGlobal(outBufferSize);
                        result = NativeMethods.DeviceIoControl(hDevice, IOCTL_DISK_GET_DRIVE_LAYOUT_EX, IntPtr.Zero, 0,
                            blob, outBufferSize, ref bytesReturned, IntPtr.Zero);
                        // We expect that we might not have enough room in the output buffer.
                        if (result == false)
                        {
                            // If the buffer wasn't too small, then something else went wrong.
                            if (Marshal.GetLastWin32Error() != ERROR_INSUFFICIENT_BUFFER)
                                throw new Win32Exception();
                            // We need more space on the next loop.
                            numPartitions += 1;
                        }
                        else
                        {
                            // We got the size right, so stop looping.
                            done = true;
                            // Do something with the data here - we'll free the memory before we leave the loop.
                            // First we grab the DRIVE_LAYOUT_INFORMATION_EX, it's at the start of the blob of memory:
                            lie =
                                (DRIVE_LAYOUT_INFORMATION_EX)
                                    Marshal.PtrToStructure(blob, typeof (DRIVE_LAYOUT_INFORMATION_EX));
                            Enum.TryParse(lie.PartitionStyle.ToString(), true, out _bootrecord);
                        }
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(blob);
                    }
                } while (!(done));
            }
            return _bootrecord;
        }

        private enum PARTITION_STYLE
        {
            MBR = 0,
            GPT = 1,
            RAW = 2
        }

        [SuppressUnmanagedCodeSecurity]
        public static class NativeMethods
        {
            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern SafeFileHandle CreateFile(
                string fileName,
                int desiredAccess,
                int shareMode,
                IntPtr securityAttributes,
                int creationDisposition,
                int flagsAndAttributes,
                IntPtr hTemplateFile);

            [DllImport("kernel32", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DeviceIoControl(
                SafeFileHandle hVol,
                int controlCode,
                IntPtr inBuffer,
                int inBufferSize,
                IntPtr outBuffer,
                int outBufferSize,
                ref int bytesReturned,
                IntPtr overlapped);
        }

        // Needs to be explicit to do the union.
        [StructLayout(LayoutKind.Explicit)]
        private struct DRIVE_LAYOUT_INFORMATION_EX
        {
            [FieldOffset(0)] public readonly PARTITION_STYLE PartitionStyle;
            [FieldOffset(4)] public readonly int PartitionCount;
            [FieldOffset(8)] public readonly DRIVE_LAYOUT_INFORMATION_MBR Mbr;
            [FieldOffset(8)] public readonly DRIVE_LAYOUT_INFORMATION_GPT Gpt;
            // Forget partition entry, we can't marshal it directly
            // as we don't know how big it is.
        }

        private struct DRIVE_LAYOUT_INFORMATION_MBR
        {
            public uint Signature;
        }

        // Sequential ensures the fields are laid out in memory
        // in the same order as we write them here. Without it,
        // the runtime can arrange them however it likes, and the
        // type may no longer be blittable to the C type.
        [StructLayout(LayoutKind.Sequential)]
        private struct DRIVE_LAYOUT_INFORMATION_GPT
        {
            public readonly Guid DiskId;
            // C LARGE_INTEGER is 64 bit
            public readonly long StartingUsableOffset;
            public readonly long UsableLength;
            // C ULONG is 32 bit
            public readonly int MaxPartitionCount;
        }
    }
}