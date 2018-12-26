using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quadrangles;

namespace QuadranglesTests
{
    [TestClass]
    public class RectangleTests
    {
        private Rectangle _rectangle;

        [TestInitialize]
        public void TestInitialize()
        {
            _rectangle = new Rectangle(2.5, 3.3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The edge was given a negative number.")]
        public void CreateRectangle_ArgumentException_Test()
        {
            var rectangle = new Rectangle(9.2, -1.2);
        }

        [TestMethod]
        public void CalculatePerimeter_CorrectResult_Test()
        {
            const double expected = 11.6;

            var actual = Math.Round(_rectangle.CalculatePerimeter(), 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSquare_CorrectResult_Test()
        {
            const double expected = 8.2;

            var actual = Math.Round(_rectangle.CalculateSquare(), 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
