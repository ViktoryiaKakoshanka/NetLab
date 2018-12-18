using System;
using MatrixProject.Controller;
using MatrixProject.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixProjectTests
{
    [TestClass]
    public class MatrixHelperTests
    {
        private Matrix _first;
        private Matrix _second;
        private Matrix _third;

        [TestInitialize]
        public void TestInitialize()
        {
            var array = new[,] 
            {
                { 1D, 2D},
                { 3D, 4D}
            };
            _first = new Matrix(array, array.GetLength(0), array.GetLength(1));

            array = new[,]
            {
                { 1D},
                { 2D}
            };
            _second = new Matrix(array, array.GetLength(0), array.GetLength(1));

            array = new[,]
            {
                { 1D, 2D },
                { 3D, 4D }
            };
            _third = new Matrix(array, array.GetLength(0), array.GetLength(1));
        }

        [TestMethod]
        public void SumMatrices_NewMatrix_Test()
        {
            var expected = new[,]
            {
                {2.0, 4.0},
                {6.0, 8.0}
            };

            var actual = MatrixHelper.Sum(_first, _third).Array;
            
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

            var actual = MatrixHelper.Subtract(_first, _third).Array;

            Assert.IsTrue(IsEqualsArrays(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubtractMatrices_InvalidOperationException_Test()
        {
            var actual = MatrixHelper.Subtract(_first, _second).Array;
        }

        [TestMethod]
        public void MultiplyMatrices_NewMatrix_Test()
        {
            var expected = new[,]
            {
                { 5D },
                { 11D }
            };

            var actual = MatrixHelper.Multiply(_first, _second).Array;

            Assert.IsTrue(IsEqualsArrays(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MultiplyMatrices_InvalidOperationException_Test()
        {
            var array = new[,]
            {
                { 5D },
                { 5D },
                { 11D }
            };

            var second = new Matrix(array, 3, 2);

            var actual = MatrixHelper.Multiply(_first, second).Array;
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
