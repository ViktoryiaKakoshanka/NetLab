using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonsMethod.Controller;
using NewtonsMethod.Model;

namespace NewtonsMethodTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateInput_CorrectValues()
        {
            bool actual;
            var inputPower = new[] { "1", "56565"};
            var inputNumerical = new[] { "1", "56565", "1.0", "1,54" };
            var inputАccurancy = new[] { "0,005", "0.549", "0,00000000001" };

            foreach(var item in inputPower)
            {
                actual = Validator.ValidateInput(item, InputedParams.Power);
                Assert.AreEqual(true, actual);
            }
            
            foreach (var item in inputNumerical)
            {
                actual = Validator.ValidateInput(item, InputedParams.Numerical);
                Assert.AreEqual(true, actual);
            }
            
            foreach (var item in inputАccurancy)
            {
                actual = Validator.ValidateInput(item, InputedParams.Аccurancy);
                Assert.AreEqual(true, actual);
            }
        }
        
        [TestMethod]
        public void ValidateInput_WrongValues()
        {
            bool actual;

            var inputPower = new[] { "1.0", "0,56565", string.Empty, "asf" };
            var inputNumerical = new[] { string.Empty, "asf" };
            var inputАccurancy = new[] { "15", "54", "1.65", string.Empty, "asf" };

            foreach (var item in inputPower)
            {
                actual = Validator.ValidateInput(item, InputedParams.Power);
                Assert.AreEqual(false, actual);
            }

            foreach (var item in inputNumerical)
            {
                actual = Validator.ValidateInput(item, InputedParams.Numerical);
                Assert.AreEqual(false, actual);
            }

            foreach (var item in inputАccurancy)
            {
                actual = Validator.ValidateInput(item, InputedParams.Аccurancy);
                Assert.AreEqual(false, actual);
            }
        }
    }
}
