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
        public void NumberDecimalToBinaryTest_51_returned_110011()
        {
            INumbers numberMock = Mock.Of<INumbers>(x=> x.DecimalNumber==51);
            var externed = "110011";
            var conversionNumeric = new ConversionNumeric();
            conversionNumeric.NumberDecimalToBinary(numberMock);

            Assert.AreSame(string.Intern(externed), string.Intern(numberMock.BinaryNumber));
        }

        [TestMethod]
        public void NumberDecimalToBinaryTest_rand_10_30()
        {
            var conversionNumeric = new ConversionNumeric();

            for (int i = 10; i < 30; i++)
            {
                INumbers numberMock = Mock.Of<INumbers>(x => x.DecimalNumber == i);
                var externed = Convert.ToString(i, 2);
                
                conversionNumeric.NumberDecimalToBinary(numberMock);
                
                Assert.AreSame(string.Intern(externed), string.Intern(numberMock.BinaryNumber), "Перевод из десятичного числа {0} в двоичную сиситему счисления {1}", externed, numberMock.BinaryNumber);
            }
        }


    }
}
