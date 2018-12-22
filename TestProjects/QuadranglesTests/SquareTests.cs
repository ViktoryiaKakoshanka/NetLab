using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quadrangles;

namespace QuadranglesTests
{
    [TestClass]
    public class SquareTests
    {
        private Square _rhombus;

        [TestInitialize]
        public void TestInitialize()
        {
            _rhombus = new Square(2.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The edge was given a negative number.")]
        public void CreateSquare_ArgumentException_Test()
        {
            var rhombus = new Square(-9.2);
        }

        [TestMethod]
        public void CalculatePerimeter_CorrectResult_Test()
        {
            const double expected = 10;

            var actual = Math.Round(_rhombus.CalculatePerimeter(), 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSquare_CorrectResult_Test()
        {
            const double expected = 6.2;

            var actual = Math.Round(_rhombus.CalculateSquare(), 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
