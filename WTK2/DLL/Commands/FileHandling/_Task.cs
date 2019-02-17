using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace WinToolkitDLL.Commands.FileHandlingTasks
{
    public abstract class _Task
    {
        protected string _directory;
        protected List<_TaskFile> FileList = new List<_TaskFile>();
        protected long TotalSize;
        protected long WorkedSize = 0;

        protected _Task(string directory)
        {
            var dirInfo = new DirectoryInfo(directory);
            foreach (
                var fsInfo in dirInfo.GetFileSystemInfos("*", SearchOption.AllDirectories).Where(f => f is FileInfo))
            {
                FileList.Add(new _TaskFile(fsInfo.FullName, directory));
            }
            Calculate();
        }

        public event PropertyChangedEventHandler Status;

        protected void OnPropertyChanged(long current, string file)
        {
            var handler = Status;

            if (handler != null)
            {
                var t = WorkedSize + current;
                var p = ((double) t/TotalSize)*100;

                handler(this, new PropertyChangedEventArgs(p.ToString("F1") + "|" + file));
            }
        }

        protected void Calculate()
        {
            foreach (var taskFile in FileList)
            {
                TotalSize += taskFile.Size;
            }
        }

        public abstract bool Run();

        protected class _TaskFile
        {
            private readonly long _size = -1;

            public _TaskFile(string filePath, string baseDirectory)
            {
                Filename = filePath;
                ShortFilename = Filename.Substring(baseDirectory.Length);
                _size = new FileInfo(Filename).Length;
            }

            public long Size
            {
                get { return _size; }
            }

            public string Filename { get; private set; }
            public string ShortFilename { get; private set; }
        }
    }
}