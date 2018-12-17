using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quadrangles;

namespace QuadranglesTests
{
    [TestClass]
    public class RhombusTests
    {
        private Rhombus _rhombus;

        [TestInitialize]
        public void TestInitialize()
        {
            _rhombus = new Rhombus(2.5, 3.3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The edge was given a negative number.")]
        public void CreateRhombus_ArgumentException_Test()
        {
            var rhombus = new Rhombus(-9.2, 1.2);
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
            const double expected = 0.4;

            var actual = Math.Round(_rhombus.CalculateSquare(), 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
