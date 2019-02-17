using System;
using System.IO;
using System.Runtime.InteropServices;

namespace WinToolkitDLL.Commands.FileHandlingTasks
{
    public class CopyDirectory : _Task
    {
        private readonly string _copyTo;
        private string _fileName;
        private int pbCancel;

        public CopyDirectory(string directory, string copyTo)
            : base(directory)
        {
            _copyTo = copyTo;
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref int pbCancel,
            CopyFileFlags dwCopyFlags);

        private void XCopy(string oldFile, string newFile)
        {
            CopyFileEx(oldFile, newFile, CopyProgressHandler, IntPtr.Zero, ref pbCancel,
                CopyFileFlags.COPY_FILE_RESTARTABLE);
        }

        private CopyProgressResult CopyProgressHandler(long total, long transferred, long streamSize,
            long StreamByteTrans, uint dwStreamNumber, CopyProgressCallbackReason reason, IntPtr hSourceFile,
            IntPtr hDestinationFile, IntPtr lpData)
        {
            OnPropertyChanged(transferred, _fileName);
            return CopyProgressResult.PROGRESS_CONTINUE;
        }

        public override bool Run()
        {
            foreach (var fi in FileList)
            {
                var _copyPath = _copyTo + fi.ShortFilename;
                var _copyDir = Path.GetDirectoryName(_copyPath);
                if (!Directory.Exists(_copyDir))
                {
                    Directory.CreateDirectory(_copyDir);
                }
                _fileName = fi.ShortFilename;
                XCopy(fi.Filename, _copyPath);
                WorkedSize += fi.Size;
            }
            return true;
        }

        private delegate CopyProgressResult CopyProgressRoutine(
            long TotalFileSize,
            long TotalBytesTransferred,
            long StreamSize,
            long StreamBytesTransferred,
            uint dwStreamNumber,
            CopyProgressCallbackReason dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData);

        private enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }

        private enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }

        [Flags]
        private enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }
    }
}