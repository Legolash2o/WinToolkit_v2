using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class Integration : Testing
    {
        public readonly string MOUNT_PATH = "D:\\Test_Mount";

        public Integration()
        {
            if (!Directory.Exists(MOUNT_PATH))
            {
                Assert.Inconclusive();
            }
        }
    }
}