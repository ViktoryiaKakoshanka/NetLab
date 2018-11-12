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
        public void CalculateRadicalSign_3_27_returned_3()
        {
            double numericalRoot = 27.0;
            int power = 3;
            double accuracy = 0.000001;
            double exected = 3;

            RadicalSign radicalSign = new RadicalSign(numericalRoot, power, accuracy);
            
            Calculator calc = new Calculator();
            calc.CalculateRadicalSign(radicalSign);

            double actual = Math.Round(radicalSign.Result, 5);

            Assert.AreEqual(exected, actual);
        }
    }
}
