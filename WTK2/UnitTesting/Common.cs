using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace UnitTesting
{
    [TestClass]
    public class Test_Common : Testing
    {
        [TestMethod]
        public void MD5HashString1()
        {
            var newtext = "MyNameIsLiam".CreateMD5();
            Assert.AreEqual("E404EA08F40D99F478CFBECE63E363D1", newtext);
        }

        [TestMethod]
        public void MD5HashString2()
        {
            var newtext = "MyNaMeIsLiAmCrOzIeR".CreateMD5();
            Assert.AreEqual("5057BC1CD67317386EDD201E50DE699E", newtext);
        }

        [TestMethod]
        public void MD5HashString3()
        {
            var newtext = ("MyNaMeIs" + "LiAmCrOzIeR").CreateMD5();
            Assert.AreEqual("5057BC1CD67317386EDD201E50DE699E", newtext);
        }

        [TestMethod]
        public void IsNumeric()
        {
            Assert.IsTrue(("233").IsNumeric());
        }

        [TestMethod]
        public void IsNotNumeric()
        {
            Assert.IsFalse("abc".IsNumeric());
        }

        [TestMethod]
        public void IsNotNumericMix()
        {
            Assert.IsFalse("abc123".IsNumeric());
        }

        [TestMethod]
        public void ForeignDetectStandard()
        {
            Assert.IsFalse("TEST".ContainsForeignCharacters());
        }

        [TestMethod]
        public void ForeignDetectContains()
        {
            Assert.IsTrue("TESTÅ".ContainsForeignCharacters());
        }

        [TestMethod]
        public void ReplaceTextStandard()
        {
            var newtext = "one".ReplaceIgnoreCase("o", "t");
            Assert.AreEqual("tne", newtext);
        }

        [TestMethod]
        public void ReplaceTextMulti()
        {
            var newtext = "hello".ReplaceIgnoreCase("hell", "bo");
            Assert.AreEqual("boo", newtext);
        }

        [TestMethod]
        public void ReplaceTextCapitals()
        {
            var newtext = "JimBob".ReplaceIgnoreCase("jim", "Tom");
            Assert.AreEqual("TomBob", newtext);
        }

        [TestMethod]
        public void ReplaceTextTrim()
        {
            var newtext = " JimBob ".ReplaceIgnoreCase("jim", "Jim", true);
            Assert.AreEqual("JimBob", newtext);
        }

        [TestMethod]
        public void LPNameGerman()
        {
            Assert.AreEqual("German", "de-DE".GetLanguageName());
        }

        [TestMethod]
        public void LPNameUnknown()
        {
            Assert.AreEqual("N/A", "NN".GetLanguageName());
        }

        [TestMethod]
        public void LPNameUS()
        {
            Assert.AreEqual("English", "en-US".GetLanguageName());
        }

        [TestMethod]
        public void Random()
        {
            var value = "0";
            value = Misc.RandomString();
            Assert.AreNotEqual("0", value);
        }

        [TestMethod]
        public void RandomWithRange()
        {
            var value = int.Parse(Misc.RandomString(100, 150));
            if (value < 100 || value > 150)
            {
                Assert.Fail();
            }
        }
    }
}