using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinToolkitDLL;
using WinToolkitDLL.Objects.Integratables;

namespace UnitTesting
{
    [TestClass]
    public class Install : Testing
    {
        /// <summary>
        ///     The specified update does not have a .txt or .xml to load information from.
        /// </summary>
        [TestMethod]
        public void InitializeAkwardUpdate()
        {
            var U = new MsuUpdate(_Global.TestDirectory + "Windows6.1-KB943790-x86_INV.msu");
            if (U.PackageName == null)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        ///     The specified update is invalid. It has an MSU file inside.
        ///     Default expand methods do not work.
        /// </summary>
        [TestMethod]
        public void InitializeAkwardUpdate2()
        {
            var U = new MsuUpdate(_Global.TestDirectory + "Windows6.1-KB2756651-x64_INV.msu");
            if (U.PackageName == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InstallUpdateMSU_Win10()
        {
            var U = new MsuUpdate(_Global.TestDirectory + "Windows6.4-KB3002675-x64.msu");
            if (U.Install() != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InstallUpdateMSU_Win10LDR()
        {
            var U = new MsuUpdate(_Global.TestDirectory + "Windows6.4-KB3002675-x64.msu");
            if (U.InstallLDR() != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InstallUpdateCAB_Win10()
        {
            var U = new CabUpdate(_Global.TestDirectory + "Windows6.4-KB3002675-x64.cab");
            if (U.Install() != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InstallUpdateCAB_Win10LDR()
        {
            var U = new CabUpdate(_Global.TestDirectory + "Windows6.4-KB3002675-x64.cab");
            if (U.InstallLDR() != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InstallWallpaper()
        {
            var U = new Wallpaper(_Global.TestDirectory + "Panda.jpg");
            if (U.Install() != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InstallFiles()
        {
            var U = new Files(_Global.TestDirectory + "Panda.jpg", "Windows\\WinToolkit_Temp\\Panda.jpg");
            if (U.Install() != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InitializeDriver_32()
        {
            var U = new Driver(_Global.TestDirectory + "Drivers\\HDARt.inf");
            Assert.AreEqual(U.Architecture, Architecture.X86);
        }

        [TestMethod]
        public void InitializeDriverArc_64()
        {
            var U = new Driver(_Global.TestDirectory + "Drivers\\HDXMSS.inf");
            Assert.AreEqual(U.Architecture, Architecture.X64);
        }

        [TestMethod]
        public void InitializeDriverArc_Mix()
        {
            var U = new Driver(_Global.TestDirectory + "Drivers\\nvhda.inf");
            Assert.AreEqual(U.Architecture, Architecture.Mix);
        }

        [TestMethod]
        public void InitializeDriverVer_64()
        {
            var U = new Driver(_Global.TestDirectory + "Drivers\\HDXMSS.inf");
            Assert.AreEqual(U.Version, "6.0.1.7083");
        }

        [TestMethod]
        public void InitializeDriverDate_64()
        {
            var U = new Driver(_Global.TestDirectory + "Drivers\\HDXMSS.inf");
            var compare = new DateTime(2013, 11, 05);
            Assert.AreEqual(U.Date, compare);
        }
    }
}