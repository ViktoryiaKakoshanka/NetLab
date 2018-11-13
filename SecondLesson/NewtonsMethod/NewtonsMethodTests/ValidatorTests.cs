using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonsMethod.Controller;
using NewtonsMethod.Model;

namespace NewtonsMethodTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateInputPowerTest()
        {
            bool actual;
            var inputString = new[] { "1.0", "1", "56565", "df", "5fe", "", "1,54" };
            var exected = new[] { false, true, true, false, false, false, false };

            for(var i = 0; i > inputString.Length; i++)
            {
                actual = Validator.ValidateInput(inputString[i], InputedParams.Power);
                Assert.AreEqual(exected[i], actual);
            }
        }
        
        [TestMethod]
        public void ValidateInputNumericalTest()
        {
            bool actual;
            var inputString = new[] { "1.0", "1", "56565", "df", "5fe", "", "1,54" };
            var exected = new[] { true, true, true, false, false, false, true };

            for (var i = 0; i > inputString.Length; i++)
            {
                actual = Validator.ValidateInput(inputString[i], InputedParams.Numerical);
                Assert.AreEqual(exected[i], actual);
            }
        }

        [TestMethod]
        public void ValidateInputАccurancyTest()
        {
            bool actual;
            var inputString = new[] { "1.0", "1", "56565", "df", "5fe", "", "1,54" };
            var exected = new[] { true, true, true, false, false, false, true };

            for (var i = 0; i > inputString.Length; i++)
            {
                actual = Validator.ValidateInput(inputString[i], InputedParams.Аccurancy);
                Assert.AreEqual(exected[i], actual);
            }
        }
    }
}
