using System;
using BinaryConverting.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryConvertingTests
{
    [TestClass]
    public class ConversionNumericTests
    {
        [TestMethod]
        public void NumberDecimalToBinary_51_returned_110011_Test()
        {
            var number = 51;
            var externed = "110011";
            var conversionNumeric = new NumberConverter();
            var actual = conversionNumeric.ConvertDecimalToBinary(number);

            Assert.AreSame(string.Intern(externed), string.Intern(actual));
        }

        [TestMethod]
        public void NumberDecimalToBinary_rand_10_30_Test()
        {
            var conversionNumeric = new NumberConverter();

            for (int i = 10; i < 30; i++)
            {
                var externed = Convert.ToString(i, 2);
                
                var actual = conversionNumeric.ConvertDecimalToBinary(i);
                
                Assert.AreSame(string.Intern(externed), string.Intern(actual), "Conversion from decimal number {0} to binary number system {1}", externed, actual);
            }
        }
    }
}
