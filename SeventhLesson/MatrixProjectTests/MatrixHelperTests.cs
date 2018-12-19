using System;
using MatrixProject.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixProjectTests
{
    [TestClass]
    public class MatrixHelperTests
    {
        private double[,] _first;
        private double[,] _second;
        private double[,] _third;


        [TestInitialize]
        public void TestInitialize()
        {
            _first = new[,] 
            {
                { 1D, 2D},
                { 3D, 4D}
            };

            _second = new[,]
            {
                { 1D},
                { 2D}
            };

            _third = new[,]
            {
                { 1D, 2D },
                { 3D, 4D }
            };
        }

        [TestMethod]
        public void SumMatrices_NewMatrix_Test()
        {
            var expected = new[,]
            {
                {2.0, 4.0},
                {6.0, 8.0}
            };

            var actual = _first.AddArray(_third);
            
            Assert.IsTrue(IsEqualsArrays(expected, actual));
        }

        [TestMethod]
        public void SubtractMatrices_NewMatrix_Test()
        {
            var expected = new[,]
            {
                {0D, 0D},
                {0D, 0D}
            };

            var actual = _first.SubtractArray(_third);

            Assert.IsTrue(IsEqualsArrays(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubtractMatrices_InvalidOperationException_Test()
        {
            var actual = _first.SubtractArray(_second);
        }

        [TestMethod]
        public void MultiplyMatrices_NewMatrix_Test()
        {
            var expected = new[,]
            {
                { 5D },
                { 11D }
            };

            var actual = _first.MultiplyArray(_second);

            Assert.IsTrue(IsEqualsArrays(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MultiplyMatrices_InvalidOperationException_Test()
        {
            var second = new[,]
            {
                { 5D },
                { 5D },
                { 11D }
            };

            var actual = _first.MultiplyArray(second);
        }

        private static bool IsEqualsArrays(double[,] firstArray, double[,] secondArray)
        {
            for (var i = 0; i < firstArray.GetLength(0); i++)
            {
                for (var j = 0; j < firstArray.GetLength(1); j++)
                {
                    if (!IsEqualsDouble(firstArray[i, j], secondArray[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsEqualsDouble(double firstNumber, double secondNumber, double delta = 0.0001)
        {
            return Math.Abs(firstNumber - secondNumber) <= delta;
        }
    }
}
