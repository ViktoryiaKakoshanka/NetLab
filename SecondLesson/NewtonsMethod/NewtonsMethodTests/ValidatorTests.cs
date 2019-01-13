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

            var actual = inputPower.All(x => Validator.ValidateInput(x, DataType.Power));
            
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateInput_CorrectNumericalFormat_Test()
        {
            var inputNumerical = new List<string> { "1", "56565", "1.0", "1,54" };

            var actual = inputNumerical.All(x => Validator.ValidateInput(x, DataType.Number));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateInput_CorrectAccuracyFormat_Test()
        {
            var inputAccuracy = new List<string> { "0,005", "0.549", "0,00000000001" };
            
            var actual = inputAccuracy.All(x => Validator.ValidateInput(x, DataType.Accuracy));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateInput_WrongPowerFormat_Test()
        {
            var inputPower = new List<string> { "1.0", "0,56565", string.Empty, "asf" };

            var actual = inputPower.All(x => Validator.ValidateInput(x, DataType.Power));

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateInput_WrongNumericalFormat_Test()
        {
            var inputNumerical = new List<string> { string.Empty, "asf" };

            var actual = inputNumerical.All(x => Validator.ValidateInput(x, DataType.Number));

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateInput_WrongAccuracyFormat_Test()
        {
            var inputAccuracy = new List<string> { "15", "54", "1.65", string.Empty, "asf" };

            var actual = inputAccuracy.All(x => Validator.ValidateInput(x, DataType.Accuracy));

            Assert.IsFalse(actual);
        }
    }
}
