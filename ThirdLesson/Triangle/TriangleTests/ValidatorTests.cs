using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TriangleLib.Controller;
using System.Linq;

namespace TriangleTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateTriangle_TriangleExists_Test()
        {
            var firstSideLength = 1.0;
            var secondSideLength = 2.0;
            var thirdSideLength = 2.5;

            var triangleExists = Validator.TriangleExists(firstSideLength, secondSideLength, thirdSideLength);

            Assert.IsTrue(triangleExists);
        }

        [TestMethod]
        public void ValidateTriangle_TriangleNotExists_Test()
        {
            var firstSideLength = 1.0;
            var secondSideLength = 2.0;
            var thirdSideLength = 3.0;

            var triangleExists = Validator.TriangleExists(firstSideLength, secondSideLength, thirdSideLength);

            Assert.IsFalse(triangleExists);
        }
        
        [TestMethod]
        public void TryParseSideLength_CorrectFormat_Test()
        {
            var correctFormatInputs = new List<string> { "3.0", "3,0" };
            var expectedParsedValues = new List<double> { 3.0, 3.0 };

            for (var i = 0; i < correctFormatInputs.Count; i++)
            {
                double actual = 0.0;
                Assert.IsTrue(Validator.TryParseSideLength(correctFormatInputs[i], out actual));
                Assert.AreEqual(expectedParsedValues[i], actual, $"expected={expectedParsedValues[i]}, actual={actual}");
            }
        }

        [TestMethod]
        public void TryParseSideLength_WrongFormat_Test()
        {
            var wrongFormatInputs = new List<string> { "kj", " " };
            double sideLength;

            var allInputsWrong = wrongFormatInputs.All(x => !Validator.TryParseSideLength(x, out sideLength));
            Assert.IsTrue(allInputsWrong);
        }
    }
}
