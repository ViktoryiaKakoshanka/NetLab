using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quadrangles;

namespace QuadranglesTests
{
    [TestClass]
    public class TrapezoidTests
    {
        private Trapezoid _trapezoid;

        [TestInitialize]
        public void TestInitialize()
        {
            _trapezoid = new Trapezoid(4.0, 4.0, 4.0, 6.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The edge was given a negative number.")]
        public void CreateParallelogram_ArgumentException_Test()
        {
            var trapezoid = new Trapezoid(-6.0, 4.0, 4.0, 4.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The edge was given a negative number.")]
        public void CreateParallelogram_ArgumentExceptionIsNoTrapezoid_Test()
        {
            var trapezoid = new Trapezoid(6.0, 6.0, 6.0, 6.0);
        }

        [TestMethod]
        public void CalculatePerimeter_CorrectResult_Test()
        {
            const double expected = 18.0;

            var actual = Math.Round(_trapezoid.CalculatePerimeter(), 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSquare_CorrectResult_Test()
        {
            const double expected = 19.4;

            var actual = Math.Round(_trapezoid.CalculateSquare(), 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
