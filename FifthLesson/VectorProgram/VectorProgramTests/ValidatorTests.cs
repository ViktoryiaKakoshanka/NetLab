using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProgram.Controller;
using VectorProgram.Model;
using System.Linq;
using System.Collections.Generic;

namespace VectorProgramTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateInput_returnedIsCorrectMultiplier()
        {
            var inputMultiplier = new List<string> { "1", "56565", "1.0", "1,54" };

            var allParsedCorrect = inputMultiplier.All(x => Validator.ValidateInput(DataType.Multiplier, x));

            Assert.IsTrue(allParsedCorrect);
        }

        [TestMethod]
        public void ValidateInput_returnedIsCorrectVector()
        {
            bool actual;
            
            var inputVector = new[] { " 1 1 1", "0,005 0,005 0,005", "0.549 0.549 0.549", "1 1 1" };
            
            foreach (var item in inputVector)
            {
                actual = Validator.ValidateInput(DataType.Vector, item);
                Assert.IsTrue(actual, $"{item} = {actual}");
            }
        }

        [TestMethod]
        public void ValidateInput_returnedIsWrongMultiplier()
        {
            bool actual;

            var inputMultiplier = new[] { string.Empty, "asf" };

            foreach (var item in inputMultiplier)
            {
                actual = Validator.ValidateInput(DataType.Multiplier, item);
                Assert.IsFalse(actual);
            }
        }

        [TestMethod]
        public void ValidateInput_returnedIsWrongVector()
        {
            bool actual;
            
            var inputVector = new[] { "kl", string.Empty, "1 1 1 ", "   1 1 1   ", "   1  1 1   " };
            
            foreach (var item in inputVector)
            {
                actual = Validator.ValidateInput(DataType.Vector, item);
                Assert.IsFalse(actual, $"{item} = {actual}");
            }
        }
    }
}
