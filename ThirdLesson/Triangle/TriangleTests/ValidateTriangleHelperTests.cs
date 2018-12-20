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
            const double firstSide = 1.0;
            const double secondSide = 2.0;
            const double thirdSide = 4.0;

            var actual = Validator.ValidateTriangle(firstSide, secondSide, thirdSide);

            Assert.IsFalse(actual);
        }
    }
}