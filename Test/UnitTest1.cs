using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumberTest;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConvert()
        {
            RomanNumber test1 = new RomanNumber(1);
            RomanNumber test2 = new RomanNumber(23);
            RomanNumber test3 = new RomanNumber(740);
            RomanNumber test4 = new RomanNumber(1005);
            RomanNumber test5 = new RomanNumber(2050);
            RomanNumber test6 = new RomanNumber(3999);

            Assert.AreEqual("I", test1.ToString());
            Assert.AreEqual("XXIII", test2.ToString());
            Assert.AreEqual("DCCXL", test3.ToString());
            Assert.AreEqual("MV", test4.ToString());
            Assert.AreEqual("MML", test5.ToString());
            Assert.AreEqual("MMMCMXCIX", test6.ToString());
        }
        [TestMethod]
        public void TestCorrectValue()
        {
            try
            {
                 var value1 = new RomanNumber(1);
            }
            catch (RomanNumberException exep)
            {
                Assert.Fail(exep.Message);
            }

            try
            {
                var value2 = new RomanNumber(3999);
            }
            catch (RomanNumberException exep)
            {
                Assert.Fail(exep.Message);
            }
        }
        [TestMethod]
        public void TestIncorrectValue()
        {
            try
            {
                var c = new RomanNumber(0);
                Assert.Fail("Ошибка вводимого значения");
            }
            catch
            {
            }

            try
            {
                var d = new RomanNumber(4000);
                Assert.Fail("Ошибка вводимого значения");
            }
            catch
            {
            }
        }
        

        [TestMethod]
        public void TestAdd()
        {
            var test1 = new RomanNumber(23);
            var test2 = new RomanNumber(101);
            var test3 = new RomanNumber(3000);
            var test4 = new RomanNumber(150);
            Assert.AreEqual("CXXIV", (test1 + test2).ToString());
            Assert.AreEqual("MMMCL", (test3 + test4).ToString());
        }

        [TestMethod]
        public void TestSub()
        {
            var test1 = new RomanNumber(3999);
            var test2 = new RomanNumber(1200);
            var test3 = new RomanNumber(50);
            var test4 = new RomanNumber(15);
            Assert.AreEqual("MMDCCXCIX", (test1 - test2).ToString());
            Assert.AreEqual("XXXV", (test3 - test4).ToString());
        }

        [TestMethod]
        public void TestMul()
        {
            var test1 = new RomanNumber(39);
            var test2 = new RomanNumber(55);
            var test3 = new RomanNumber(1200);
            var test4 = new RomanNumber(2);
            Assert.AreEqual("MMCXLV", (test1 * test2).ToString());
            Assert.AreEqual("MMCD", (test3 * test4).ToString());
        }

        [TestMethod]
        public void TestDiv()
        {
            var test1 = new RomanNumber(2500);
            var test2 = new RomanNumber(500);
            var test3 = new RomanNumber(1200);
            var test4 = new RomanNumber(2);
            Assert.AreEqual("V", (test1 / test2).ToString());
            Assert.AreEqual("DC", (test3 / test4).ToString());
        }

        [TestMethod]
        public void TestClone()
        {
            var value1 = new RomanNumber(133);
            var value2 = new RomanNumber(122);
            var CloneValue = (RomanNumber)value1.Clone();
            Assert.AreEqual(value1.ToString(), CloneValue.ToString());
            value1 = value2;
            Assert.AreNotEqual(value1.ToString(), CloneValue.ToString());
        }

        [TestMethod]
        public void TestCompare()
        {
            var a = new RomanNumber(8);
            var b = new RomanNumber(8);
            Assert.AreEqual(0, a.CompareTo(b));
            a += b;
            Assert.AreEqual(8, a.CompareTo(b));
        }
    }
}
