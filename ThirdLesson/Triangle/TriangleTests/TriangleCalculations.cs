using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib.Model;
using TriangleLib.Controller;

namespace TriangleTests
{
    [TestClass]
    public class TriangleCalculationsTests
    {
        Triangle triangle;

        [TestInitialize]
        public void TestInitialize()
        {
            triangle = new Triangle(1, 2, 2);
        }

        [TestMethod]
        public void CalculateThePerimeter_returnNewNumber_Test()
        {
            var expected = 5;

            var actual = TriangleCalculations.CalculateThePerimeter(triangle);

            Assert.AreEqual(expected, actual, $"Perimeter: expected={expected}, actual={actual}");

        }

        [TestMethod]
        public void CalculateTheArea_returnNewNumber_Test()
        {
            var expected = 0.968246;

            var actual = TriangleCalculations.CalculateTheArea(triangle);

            Assert.AreEqual(expected, Math.Round(actual, 6), $"Area: expected={expected}, actual={Math.Round(actual, 6)}");

        }
    }
}
