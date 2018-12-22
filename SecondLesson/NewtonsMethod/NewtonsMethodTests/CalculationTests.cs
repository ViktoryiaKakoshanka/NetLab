using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonsMethod.Controller;
using NewtonsMethod.Model;

namespace NewtonsMethodTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void CalculateRadicalSign_3_27_returned_3_Test()
        {
            const double numericalRoot = 27.0;
            const int power = 3;
            const double accuracy = 0.000001;
            const double expected = 3.0;

            var radicalSign = new RadicalSign(numericalRoot, power, accuracy);
            
            Calculator.CalculateRadicalSign(radicalSign);

            var actual = Math.Round(radicalSign.Root, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
