using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using System.Collections.Generic;
using System.Linq;

namespace NewtonsMethodTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateInput_CorrectPowerFormat_Test()
        {
            var inputPower = new List<string> { "1", "56565"};

            var actual = inputPower.All(x => Validator.ValidateInput(x, ValidationType.RootPower));
            
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateInput_CorrectNumericalFormat_Test()
        {
            var inputNumerical = new List<string> { "1", "56565", "1.0" };

            var actual = inputNumerical.All(x => Validator.ValidateInput(x, ValidationType.Number));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateInput_CorrectAccuracyFormat_Test()
        {
            var inputAccuracy = new List<string> { "0,005", "0.549" };
            
            var actual = inputAccuracy.All(x => Validator.ValidateInput(x, ValidationType.Accuracy));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateInput_WrongPowerFormat_Test()
        {
            var inputPower = new List<string> { "1.0", string.Empty, "asf" };

            var actual = inputPower.All(x => Validator.ValidateInput(x, ValidationType.RootPower));

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateInput_WrongNumericalFormat_Test()
        {
            var inputNumerical = new List<string> { string.Empty, "asf" };

            var actual = inputNumerical.All(x => Validator.ValidateInput(x, ValidationType.Number));

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateInput_WrongAccuracyFormat_Test()
        {
            var inputAccuracy = new List<string> { "15", "54", "1.65", string.Empty, "asf" };

            var actual = inputAccuracy.All(x => Validator.ValidateInput(x, ValidationType.Accuracy));

            Assert.IsFalse(actual);
        }
    }
}
