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
            var numericalRoot = 27.0;
            var power = 3;
            var accuracy = 0.000001;
            var exected = 3.0;

            var radicalSign = new RadicalSign(numericalRoot, power, accuracy);
            
            var calc = new Calculator();
            calc.CalculateRadicalSign(radicalSign);

            var actual = Math.Round(radicalSign.Result, 5);

            Assert.AreEqual(exected, actual);
        }
    }
}
