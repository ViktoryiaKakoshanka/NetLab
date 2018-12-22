using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TriangleLib.Controller;
using System.Linq;

namespace TriangleTests
{
    [TestClass]
    public class ValidateTriangleHelperTests
    {
        [TestMethod]
        public void ValidateTriangle_CorrectTriangle_Test()
        {
            var firstSide = 1.0;
            var secondSide = 2.0;
            var thirdSide = new List<double> { 1.0, 2.0, 3.0 };

            var actual = thirdSide.All(x => Validator.ValidateTriangle(firstSide, secondSide, x));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateTriangle_WrongTriangle_Test()
        {
            var firstSide = 1.0;
            var secondSide = 2.0;
            var thirdSide = 4.0;

            var actual = Validator.ValidateTriangle(firstSide, secondSide, thirdSide);

            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void TryParseInputtingSide_returnNewNumber_Test()
        {
            var diferentVariants = new List<string> { "3.0", "3,0", "kj", " " };
            var expectedVariants = new List<double> { 3.0, 3.0, 0.0, 0.0 };

            for (var i = 0; i < diferentVariants.Count; i++)
            {
                var actual = Validator.TryParseSide(diferentVariants[i]);
                Assert.AreEqual(expectedVariants[i], actual, $"expected={expectedVariants[i]}, actual={actual}");
            }
        }
    }
}
