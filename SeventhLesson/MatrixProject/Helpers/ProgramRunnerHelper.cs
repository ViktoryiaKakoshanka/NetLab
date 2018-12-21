using System;

namespace MatrixProject.Helpers
{
    public static class ProgramRunnerHelper
    {
        public static double[,] InitializeMatrix(Random random, int numberOfLines, int numberOfColumns)
        {
            var matrix = new double[numberOfLines, numberOfColumns];
            for (var i = 0; i < numberOfLines; i++)
            {
                for (var j = 0; j < numberOfColumns; j++)
                {
                    matrix[i, j] = random.NextDouble() * 10;
                }
            }
            return matrix;
        }
    }
}