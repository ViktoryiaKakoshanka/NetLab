using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProgram.Controller;
using VectorProgram.Model;

namespace VectorProgramTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateInput_CorrectValues()
        {
            bool actual;

            var inputMultiplier = new[] { "1", "56565", "1.0", "1,54" };
            var inputVector = new[] { " 1 1 1", "0,005 0,005 0,005", "0.549 0.549 0.549", "1 1 1" };

            foreach (var item in inputMultiplier)
            {
                actual = Validator.ValidateInput(DataType.Multiplier, item);
                Assert.AreEqual(true, actual);
            }

            foreach (var item in inputVector)
            {
                actual = Validator.ValidateInput(DataType.Vector, item);
                Assert.AreEqual(true, actual, $"{item} = {actual}");
            }
        }

        [TestMethod]
        public void ValidateInput_WrongValues()
        {
            bool actual;

            var inputMultiplier = new[] { string.Empty, "asf" };
            var inputVector = new[] { "kl", string.Empty,  "1 1 1 ", "   1 1 1   " };

            foreach (var item in inputMultiplier)
            {
                actual = Validator.ValidateInput(DataType.Multiplier, item);
                Assert.AreEqual(false, actual);
            }

            foreach (var item in inputVector)
            {
                actual = Validator.ValidateInput(DataType.Vector, item);
                Assert.AreEqual(false, actual, $"{item} = {actual}");
            }
        }
    }
}
