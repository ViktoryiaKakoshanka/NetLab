using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonsMethod.Controller;

namespace NewtonsMethodTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void CalculateRadicalSign_3_27_returned_3_Test()
        {
            const double number = 27.0;
            const int power = 3;
            const double accuracy = 0.000001;
            const double expected = 3.0;
            
            var root =  Calculator.CalculateRootByMethodNewtons(number, power, accuracy);

            var actual = Math.Round(root, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
