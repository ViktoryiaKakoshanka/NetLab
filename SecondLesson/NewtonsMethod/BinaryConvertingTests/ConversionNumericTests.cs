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
            INumbers numberMock = Mock.Of<INumbers>(x=> x.DecimalNumber==51);
            var externed = "110011";
            var conversionNumeric = new ConversionNumeric();
            conversionNumeric.ConvertDecimalToBinary(numberMock);

            Assert.AreSame(string.Intern(externed), string.Intern(numberMock.BinaryNumber));
        }

        [TestMethod]
        public void NumberDecimalToBinary_rand_10_30_Test()
        {
            var conversionNumeric = new ConversionNumeric();

            for (int i = 10; i < 30; i++)
            {
                INumbers numberMock = Mock.Of<INumbers>(x => x.DecimalNumber == i);
                var externed = Convert.ToString(i, 2);
                
                conversionNumeric.ConvertDecimalToBinary(numberMock);
                
                Assert.AreSame(string.Intern(externed), string.Intern(numberMock.BinaryNumber), "Conversion from decimal number {0} to binary number system {1}", externed, numberMock.BinaryNumber);
            }
        }
    }
}
