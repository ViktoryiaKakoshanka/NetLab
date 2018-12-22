using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using PolynomialProgram.Controller;
using PolynomialProgram.Model;

namespace VectorProgramTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateInput_CorrectMultiplierFormat_Test()
        {
            var inputMultiplier = new List<string> { "1", "56565", "1.0", "1,54" };

            var allParsedCorrect = inputMultiplier.All(x => Validator.ValidateInput(DataType.Multiplier, x));

            Assert.IsTrue(allParsedCorrect);
        }

        [TestMethod]
        public void ValidateInput_CorrectVectorFormat_Test()
        {            
            var inputVector = new List<string> { " 1 1 1", "0,005 0,005 0,005", "0.549 0.549 0.549", "1 1 1" };

            var allParsedCorrect = inputVector.All(x => Validator.ValidateInput(DataType.Vector, x));

            Assert.IsTrue(allParsedCorrect);
        }

        [TestMethod]
        public void ValidateInput_WrongMultiplierFormat_Test()
        {
            var inputMultiplier = new List<string> { string.Empty, "asf" };

            var allParsedWrong = inputMultiplier.All(x => Validator.ValidateInput(DataType.Multiplier, x));

            Assert.IsFalse(allParsedWrong);
        }

        [TestMethod]
        public void ValidateInput_WrongVectorFormat_Test()
        {
            var inputVector = new List<string> { "kl", string.Empty, "1 1 1 ", "   1 1 1   ", "   1  1 1   " };

            var allParsedWrong = inputVector.All(x => Validator.ValidateInput(DataType.Vector, x));

            Assert.IsFalse(allParsedWrong);
        }
    }
}
