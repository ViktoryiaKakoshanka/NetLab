using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib.Helpers;
using TriangleLib.Model;

namespace TriangleTests
{
    [TestClass]
    public class TriangleCalculationsTests
    {
        private Triangle _triangle;

        [TestInitialize]
        public void TestInitialize()
        {
            _triangle = new Triangle(1, 2, 2);
        }

        [TestMethod]
        public void CalculateThePerimeter_returnNewNumber_Test()
        {
            const int expected = 5;

            var actual = TriangleHelper.CalculatePerimeter(_triangle);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTheArea_returnNewNumber_Test()
        {
            const double expected = 0.968246;

            var actual = TriangleHelper.CalculateArea(_triangle);

            Assert.AreEqual(expected, Math.Round(actual, 6));
        }
    }
}