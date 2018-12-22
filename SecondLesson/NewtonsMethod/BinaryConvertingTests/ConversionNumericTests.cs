using System;
using BinaryConverting.Helpers;
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

            Assert.AreSame(string.Intern(expected), string.Intern(numberMock.ConvertDecimalToBinary().BinaryNumber));
        }

        [TestMethod]
        public void NumberDecimalToBinary_rand_10_30_Test()
        {
            for (var i = 10; i < 30; i++)
            {
                var numberMock = Mock.Of<INumbers>(x => x.DecimalNumber == i);
                var expected = Convert.ToString(i, 2);
                
                Assert.AreSame(string.Intern(expected), string.Intern(numberMock.ConvertDecimalToBinary().BinaryNumber), "Conversion from decimal number {0} to binary number system {1}", expected, numberMock.BinaryNumber);
            }
        }
    }
}
