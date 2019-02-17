using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Objects.Integratables;

namespace UnitTesting
{
    [TestClass]
    public class Convertables : Testing
    {
        [TestMethod]
        public void ConvertUpdate()
        {
            var newUpdate = new MsuUpdate(_Global.TestDirectory + "Windows6.1-KB917607-x86_GDR.msu");
            var outDir = _Global.TestDirectory + "Output" + Misc.RandomString() + "\\";
            FileHandling.DeleteDirectory(outDir, true);

            var result = newUpdate.Convert(outDir);

            FileHandling.DeleteDirectory(outDir);

            if (result != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ConvertLangPack()
        {
            var newLangPack = new LangPack(_Global.TestDirectory + "Arabic x64.exe");
            var outDir = _Global.TestDirectory + "Output" + Misc.RandomString() + "\\";
            FileHandling.DeleteDirectory(outDir, true);

            var result = newLangPack.Convert(outDir);

            FileHandling.DeleteDirectory(outDir);

            if (result != Status.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ConvertOffice()
        {
            var newUpdate = new Office(_Global.TestDirectory + "msocf2010-kb2589375-fullfile-x86-glb.exe");
            var outDir = _Global.TestDirectory + "Output" + Misc.RandomString() + "\\";
            FileHandling.DeleteDirectory(outDir, true);

            var result = newUpdate.Convert(outDir);

            FileHandling.DeleteDirectory(outDir);

            if (result != Status.Success)
            {
                Assert.Fail();
            }
        }
    }
}