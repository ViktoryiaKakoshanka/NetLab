using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib.Model;
using TriangleLib.Controller;

namespace TriangleTests
{
    [TestClass]
    public class TriangleHelperTests
    {
<<<<<<< HEAD:ThirdLesson/Triangle/TriangleTests/TriangleCalculations.cs
        TriangleLib triangle;
=======
        Triangle _triangle;
>>>>>>> master:ThirdLesson/Triangle/TriangleTests/TriangleHelperTests.cs

        [TestInitialize]
        public void TestInitialize()
        {
<<<<<<< HEAD:ThirdLesson/Triangle/TriangleTests/TriangleCalculations.cs
            triangle = new TriangleLib(1, 2, 2);
=======
            _triangle = new Triangle(1, 2, 2);
>>>>>>> master:ThirdLesson/Triangle/TriangleTests/TriangleHelperTests.cs
        }

        [TestMethod]
        public void CalculatePerimeter_Test()
        {
            var expected = 5;

            var actual = TriangleHelper.CalculatePerimeter(_triangle);

            Assert.AreEqual(expected, actual, $"Perimeter: expected={expected}, actual={actual}");

        }

        [TestMethod]
        public void CalculateArea_Test()
        {
            var expected = 0.968246;

            var actual = TriangleHelper.CalculateArea(_triangle);

            Assert.AreEqual(expected, Math.Round(actual, 6), $"Area: expected={expected}, actual={Math.Round(actual, 6)}");

        }
    }
}
