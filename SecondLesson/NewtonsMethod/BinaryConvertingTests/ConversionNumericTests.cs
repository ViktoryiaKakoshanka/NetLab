using System;
using BinaryConverting.Controller;
using BinaryConverting.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BinaryConvertingTests
{
    [TestClass]
    public class ConversionNumericTests
    {
        [TestMethod]
        public void NumberDecimalToBinary_51_returned_110011_Test()
        {
            var numberMock = Mock.Of<INumbers>(x=> x.DecimalNumber == 51);
            const string expected = "110011";
            var conversionNumeric = new ConversionNumber();
            conversionNumeric.ConvertDecimalToBinary(numberMock);

            Assert.AreSame(string.Intern(expected), string.Intern(numberMock.BinaryNumber));
        }

        [TestMethod]
        public void NumberDecimalToBinary_rand_10_30_Test()
        {
            var conversionNumeric = new ConversionNumber();

            for (var i = 10; i < 30; i++)
            {
                var numberMock = Mock.Of<INumbers>(x => x.DecimalNumber == i);
                var expected = Convert.ToString(i, 2);
                
                conversionNumeric.ConvertDecimalToBinary(numberMock);
                
                Assert.AreSame(string.Intern(expected), string.Intern(numberMock.BinaryNumber), "Conversion from decimal number {0} to binary number system {1}", expected, numberMock.BinaryNumber);
            }
        }
    }
}
