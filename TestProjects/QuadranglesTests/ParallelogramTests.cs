using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quadrangles;

namespace QuadranglesTests
{
    [TestClass]
    public class ParallelogramTests
    {
        private Parallelogram _parallelogram;

        [TestInitialize]
        public void TestInitialize()
        {
            _parallelogram = new Parallelogram(2.5, 3.3, 33.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The edge was given a negative number.")]
        public void CreateParallelogram_ArgumentException_Test()
        {
            var parallelogram = new Parallelogram(9.2, -1.2, 90);
        }

        [TestMethod]
        public void CalculatePerimeter_CorrectResult_Test()
        {
            const double expected = 11.6;

            var actual = Math.Round(_parallelogram.CalculatePerimeter(), 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSquare_CorrectResult_Test()
        {
            const double expected = 4.6;

            var actual = Math.Round(_parallelogram.CalculateSquare(), 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
