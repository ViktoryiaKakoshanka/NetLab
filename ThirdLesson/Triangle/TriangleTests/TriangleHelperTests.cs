using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib.Model;
using TriangleLib.Controller;

namespace TriangleTests
{
    [TestClass]
    public class TriangleHelperTests
    {
        Triangle _triangle;

        [TestInitialize]
        public void TestInitialize()
        {
            _triangle = new Triangle(1, 2, 2);
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
