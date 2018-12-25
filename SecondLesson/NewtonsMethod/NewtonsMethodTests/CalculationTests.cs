using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonsMethod.Controller;

namespace NewtonsMethodTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void CalculateRoot_3_27_returned_3_Test()
        {
<<<<<<< HEAD
            const double numericalRoot = 27.0;
            const int power = 3;
            const double accuracy = 0.000001;
            const double expected = 3.0;

            var radicalSign = new RadicalSign(numericalRoot, power, accuracy);
            
            Calculator.CalculateRadicalSign(radicalSign);

            var actual = Math.Round(radicalSign.Root, 5);
=======
            var radicand = 27.0;
            var degree = 3;
            var accuracy = 0.000001;
            var expected = 3.0;

            var calculator = new Calculator();
            var result = calculator.CalculateRoot(degree, radicand, accuracy);

            var actual = Math.Round(result, 5);
>>>>>>> master

            Assert.AreEqual(expected, actual);
        }
    }
}
