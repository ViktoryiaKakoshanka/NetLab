using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TriangleLib.Model;
using TriangleLib.Controller;

namespace TriangleTests
{
    [TestClass]
    public class TriangleCalculationsTests
    {
        [TestMethod]
        public void CalculateThePerimeterTest_returned_PerimeterTriangle()
        {
            var triangle = new Triangle(1, 2, 2);
            var expected = 5;

            var actual = TriangleCalculations.CalculateThePerimeter(triangle);

            Assert.AreEqual(expected, actual, $"Perimeter: expected={expected}, actual={actual}");

        }

        [TestMethod]
        public void CalculateTheArea_returned_AreaTriangle()
        {
            var triangle = new Triangle(1, 2, 2);
            var expected = 0.968246;

            var actual = TriangleCalculations.CalculateTheArea(triangle);

            Assert.AreEqual(expected, Math.Round(actual, 6), $"Area: expected={expected}, actual={Math.Round(actual, 6)}");

        }
    }
}
