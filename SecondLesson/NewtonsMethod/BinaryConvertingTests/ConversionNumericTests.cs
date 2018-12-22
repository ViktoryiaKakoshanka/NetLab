﻿using System;
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
<<<<<<< HEAD
            var numberMock = Mock.Of<INumbers>(x=> x.DecimalNumber == 51);
            const string expected = "110011";
            var conversionNumeric = new ConversionNumber();
            conversionNumeric.ConvertDecimalToBinary(numberMock);

            Assert.AreSame(string.Intern(expected), string.Intern(numberMock.BinaryNumber));
=======
            var number = 51;
            var externed = "110011";
            var conversionNumeric = new NumberConverter();
            var actual = conversionNumeric.ConvertDecimalToBinary(number);

            Assert.AreSame(string.Intern(externed), string.Intern(actual));
>>>>>>> master
        }

        [TestMethod]
        public void NumberDecimalToBinary_rand_10_30_Test()
        {
<<<<<<< HEAD
            var conversionNumeric = new ConversionNumber();
=======
            var conversionNumeric = new NumberConverter();
>>>>>>> master

            for (var i = 10; i < 30; i++)
            {
<<<<<<< HEAD
                var numberMock = Mock.Of<INumbers>(x => x.DecimalNumber == i);
                var expected = Convert.ToString(i, 2);
=======
                var externed = Convert.ToString(i, 2);
>>>>>>> master
                
                var actual = conversionNumeric.ConvertDecimalToBinary(i);
                
<<<<<<< HEAD
                Assert.AreSame(string.Intern(expected), string.Intern(numberMock.BinaryNumber), "Conversion from decimal number {0} to binary number system {1}", expected, numberMock.BinaryNumber);
=======
                Assert.AreSame(string.Intern(externed), string.Intern(actual), "Conversion from decimal number {0} to binary number system {1}", externed, actual);
>>>>>>> master
            }
        }
    }
}
