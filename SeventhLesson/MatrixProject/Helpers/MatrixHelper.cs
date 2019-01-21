using System;

namespace MatrixProject.Helpers
{
    public static class MatrixHelper
    {
        public static double[,] AddMatrix(this double[,] first, double[,] second)
        {
            CanSum(first, second);
            return ExecuteSimpleAction(first, second, (a, b) => a + b);
        }

        public static double[,] SubtractMatrix(this double[,] first, double[,] second)
        {
            CanSum(first, second);
            return ExecuteSimpleAction(first, second, (a, b) => a - b);
        }

        public static double[,] MultiplyByMatrix(this double[,] first, double[,] second)
        {
            CanMultiply(first, second);
            var matrix = new double[second.GetLength(0), second.GetLength(1)];

            for (var k = 0; k < second.GetLength(1); k++)
            {
                for (var i = 0; i < first.GetLength(0); i++)
                {
                    for (var j = 0; j < first.GetLength(1); j++)
                    {
                        matrix[i, k] += first[i, j] * second[j, k];
                    }
                }
            }

            return matrix;
        }

        private static void CanSum(double[,] first, double[,] second)
        {
            if (first.GetLength(0) != second.GetLength(0) || 
                first.GetLength(1) != second.GetLength(1))
            {
                throw new InvalidOperationException("Matrices must be the same size.");
            }
        }
        
        private static void CanMultiply(double[,] first, double[,] second)
        {
            if (first.GetLength(1) != second.GetLength(0))
            {
                throw new InvalidOperationException(
                    "Multiplication is not calculated. The number of columns of the first matrix must be equal to the number of rows of another matrix.");
            }
        }

        private static double[,] ExecuteSimpleAction(double[,] first, double[,] second, Func<double, double, double> action)
        {
            var resultArray = new double[first.GetLength(0), first.GetLength(1)];

            for (var i = 0; i < first.GetLength(0); i++)
            {
                for (var j = 0; j < first.GetLength(1); j++)
                {
                    resultArray[i, j] = action(first[i, j], second[i, j]);
                }
            }

            return resultArray;
        }
    }
}
