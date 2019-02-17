using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace UnitTesting
{
    [TestClass]
    public class Test_FileHandling : Testing
    {
        [TestMethod]
        public void DeleteFolder()
        {
            var testDir = Directories.TempPath + "TESTDIR_" + Misc.RandomString();
            Directory.CreateDirectory(testDir);
            Assert.IsTrue(FileHandling.DeleteDirectory(testDir));
        }

        [TestMethod]
        public void DeleteFolderNotExist()
        {
            var testDir = Directories.TempPath + "TESTDIR_" + Misc.RandomString();

            Assert.IsTrue(FileHandling.DeleteDirectory(testDir));
        }

        [TestMethod]
        public void DeleteFolderNotEmpty()
        {
            var testDir = Directories.TempPath + "TESTDIR_" + Misc.RandomString();
            Directory.CreateDirectory(testDir);
            var testFile = testDir + "\\TESTFILE_" + Misc.RandomString() + ".exe";
            File.WriteAllLines(testFile, new string[0]);

            Assert.IsTrue(FileHandling.DeleteDirectory(testDir));
        }

        [TestMethod]
        public void DeleteFolderWithRecreate()
        {
            var testDir = Directories.TempPath + "TESTDIR_" + Misc.RandomString();
            Directory.CreateDirectory(testDir);

            Assert.IsTrue(FileHandling.DeleteDirectory(testDir, true));
        }

        [TestMethod]
        public void DeleteFile()
        {
            var testFile = Directories.TempPath + "TESTFILE_" + Misc.RandomString() + ".exe";
            File.WriteAllLines(testFile, new string[0]);

            Assert.IsTrue(FileHandling.DeleteFile(testFile));
        }

        [TestMethod]
        public void GetSizeFolder()
        {
            var size = FileHandling.GetSize("C:\\Windows\\Web");
            if (size == 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetSizeFile()
        {
            var size = FileHandling.GetSize("C:\\Windows\\Explorer.exe");
            if (size == 0)
            {
                Assert.Fail();
            }
            if (!FileHandling.BytesToString(size).EndsWithIgnoreCase("B"))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetMD5()
        {
            var testFile = Directories.TempPath + "TESTFILE_" + Misc.RandomString() + ".txt";
            File.WriteAllText(testFile, "This is a test string");
            Options.GetMD5 = true;

            Assert.AreEqual("C639EFC1E98762233743A75E7798DD9C", FileHandling.GetMD5(testFile));
        }

        [TestMethod]
        public void GetMD5Disabled()
        {
            var testFile = Directories.TempPath + "TESTFILE_" + Misc.RandomString() + ".txt";
            File.WriteAllText(testFile, "This is a test string");
            Options.GetMD5 = false;

            Assert.AreEqual("N/A", FileHandling.GetMD5(testFile));
        }

        [TestMethod]
        public void GetMD5NotExist()
        {
            var testFile = Directories.TempPath + "TESTFILE_" + Misc.RandomString() + ".txt";
            Options.GetMD5 = true;

            File.Delete(testFile);
            Assert.IsNull(FileHandling.GetMD5(testFile));
        }

        [TestMethod]
        public void ReadFile()
        {
            var testFile = Directories.TempPath + "TESTFILE_" + Misc.RandomString() + ".txt";
            File.WriteAllText(testFile, "This is a test string\n" + testFile);
            var readFile = FileHandling.ReadFile(testFile);

            Assert.AreEqual("This is a test string\n" + testFile, readFile);
        }

        [TestMethod]
        public void ReadFileForeign()
        {
            var testFile = Directories.TempPath + "TESTFILE_" + Misc.RandomString() + ".txt";
            File.WriteAllText(testFile, "This is a test stringÅ\n" + testFile);
            var readFile = FileHandling.ReadFile(testFile);

            Assert.AreEqual("This is a test stringÅ\n" + testFile, readFile);
        }

        [TestMethod]
        public void WriteFile()
        {
            var testFile = Directories.TempPath + "TESTFILE_" + Misc.RandomString() + ".txt";
            FileHandling.WriteFile(testFile, "This is a test stringÅ\n" + testFile);

            using (var sr = new StreamReader(testFile, Encoding.UTF8))
            {
                Assert.AreEqual("This is a test stringÅ\n" + testFile + "\r\n", sr.ReadToEnd());
            }
        }

        [TestMethod]
        public void FileInUseRead1()
        {
            var inUse = false;
            using (
                var fs = new FileStream(Directories.TempPath + "TESTFILE.txt", FileMode.OpenOrCreate, FileAccess.Read,
                    FileShare.Read))
            {
                inUse = FileHandling.IsFileLocked(fs.Name, FileAccess.Read);
            }

            if (inUse)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FileInUseRead2()
        {
            var inUse = false;
            using (
                var fs = new FileStream(Directories.TempPath + "TESTFILE.txt", FileMode.OpenOrCreate, FileAccess.Read,
                    FileShare.None))
            {
                inUse = FileHandling.IsFileLocked(fs.Name, FileAccess.Read);
            }

            if (!inUse)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FileInUseWrite()
        {
            var inUse = false;
            using (
                var fs = new FileStream(Directories.TempPath + "TESTFILE.txt", FileMode.OpenOrCreate, FileAccess.Write,
                    FileShare.None))
            {
                inUse = FileHandling.IsFileLocked(fs.Name, FileAccess.ReadWrite);
            }

            if (!inUse)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FileInUseWrite2()
        {
            var inUse = false;
            inUse = FileHandling.IsFileLocked("C:\\Windows\\win.ini", FileAccess.ReadWrite);

            if (inUse)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IsNotNetworkPath()
        {
            if (FileHandling.IsNetworkPath("D:\\"))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IsReadOnly()
        {
            if (!FileHandling.IsReadOnly("G:\\"))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IsNotReadOnly()
        {
            if (FileHandling.IsReadOnly(Directories.Desktop))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IsNetworkPath()
        {
            if (!FileHandling.IsNetworkPath("\\\\LiamsNAS\\Downloads"))
            {
                Assert.Fail();
            }
        }
    }
}