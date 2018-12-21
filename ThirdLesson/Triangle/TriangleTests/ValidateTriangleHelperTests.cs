using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib.Helpers;

namespace TriangleTests
{
    [TestClass]
    public class ValidateTriangleHelperTests
    {
        [TestMethod]
        public void ValidateTriangle_CorrectTriangle_Test()
        {
            const double firstEdge = 1.0;
            const double secondEdge = 2.0;
            var thirdEdge = new List<double> { 1.0, 2.0, 3.0 };

            var actual = thirdEdge.All(x => Validator.ValidateTriangle(firstEdge, secondEdge, x));

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