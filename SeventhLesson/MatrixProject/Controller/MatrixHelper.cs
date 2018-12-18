using System;
using MatrixProject.Model;

namespace MatrixProject.Controller
{
    public class MatrixHelper
    {
        private enum Action
        {
            Sum,
            Subtract,
            Multiply
        }

        public static Matrix Sum(Matrix first, Matrix second)
        {
            if (!IsCorrectMatricesForActions(Action.Sum, first, second))
            {
                throw new InvalidOperationException("The amount is not calculated. Matrices must be the same size.");
            }

            var matrix = CalculateArray(Action.Sum, first, second);

            return new Matrix(matrix, first.Lines, first.Columns);
        }

        public static Matrix Subtract(Matrix first, Matrix second)
        {
            if (!IsCorrectMatricesForActions(Action.Subtract, first, second))
            {
                throw new InvalidOperationException("Subtraction is not calculated. Matrices must be the same size.");
            }

            var matrix = CalculateArray(Action.Subtract, first, second);

            return new Matrix(matrix, first.Lines, first.Columns);
        }

        public static Matrix Multiply(Matrix first, Matrix second)
        {
            if (!IsCorrectMatricesForActions(Action.Multiply, first, second))
            {
                throw new InvalidOperationException(
                    "Multiplication is not calculated. The number of columns of the first matrix must be equal to the number of rows of another matrix.");
            }

            var matrix = new double[second.Lines, second.Columns];

            for (var k = 0; k < second.Columns; k++)
            {
                for (var i = 0; i < first.Lines; i++)
                {
                    for (var j = 0; j < first.Columns; j++)
                    {
                        matrix[i, k] += first.Array[i, j] * second.Array[j, k];
                    }
                }
            }

            return new Matrix(matrix, first.Lines, first.Columns); 
        }

        private static bool IsCorrectMatricesForActions(Action action, Matrix first, Matrix second)
        {
            if ((action == Action.Sum || action == Action.Subtract) &&
                first.Columns == second.Columns &&
                first.Lines == second.Lines)
            {
                return true;
            }

            return action == Action.Multiply && first.Columns == second.Lines;
        }

        private static double[,] CalculateArray(Action action, Matrix first, Matrix second)
        {
            var resultArray = new double[first.Lines, first.Columns];

            for (var i = 0; i < first.Lines; i++)
            {
                for (var j = 0; j < first.Columns; j++)
                {
                     resultArray[i, j] = action == Action.Sum ? 
                         first.Array[i, j] + second.Array[i, j] : 
                         first.Array[i, j] - second.Array[i, j];
                }
            }

            return resultArray;
        }
    }
}
