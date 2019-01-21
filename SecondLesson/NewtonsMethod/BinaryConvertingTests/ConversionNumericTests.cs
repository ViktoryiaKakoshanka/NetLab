using System;
using BinaryConverting.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryConvertingTests
{
    [TestClass]
    public class ConversionNumericTests
    {
        [TestMethod]
        public void NumberDecimalToBinary_51_returned_110011_Test()
        {
            const string expected = "110011";
            var actual = 51.ByBinary();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberDecimalToBinary_10_30_Test()
        {
            for (var i = 10; i < 30; i++)
            {
                var expected = Convert.ToString(i, 2);
                var actual = i.ByBinary();
                
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
