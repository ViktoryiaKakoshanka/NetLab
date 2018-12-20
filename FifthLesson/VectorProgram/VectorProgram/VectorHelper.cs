using System;
using VectorProgram.Model;

namespace VectorProgram
{
    public static class VectorHelper
    {
        public static double CalculateAngle(Vector first, Vector second)
        {
            var scalarProduct = CalculateScalarProduct(first, second);
            var firstModule = CalculateModule(first);
            var secondModule = CalculateModule(second);

            return scalarProduct / (firstModule * secondModule);
        }

        public static Vector CalculateVectorProduct(Vector first, Vector second)
        {
            var arrayOfOrts = CreateArrayOfOrts(first, second);

            var determinantOne = CalculateDeterminant(arrayOfOrts[0]);
            var determinantTwo = CalculateDeterminant(arrayOfOrts[1]);
            var determinantThree = CalculateDeterminant(arrayOfOrts[2]);

            return new Vector(determinantOne, determinantTwo, determinantThree);
        }

        public static double CalculateScalarProduct(Vector first, Vector second)
        {
            return first.X * second.X + first.Y * second.Y + first.Z * second.Z;
        }

        private static double CalculateModule(Vector vector)
        {
            var result = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
            return Math.Abs(result);
        }

        private static double[][,] CreateArrayOfOrts(Vector first, Vector second)
        {
            var arrayOfOrts = new[]
            {
                new[,]
                {
                    { first.Y, first.Z },
                    { second.Y, second.Z },
                },
                new[,]
                {
                    { first.X, first.Z },
                    { second.X, second.Z }
                },
                new[,]
                {
                    { first.X, first.Y },
                    { second.X, second.Y }
                }
            };
            return arrayOfOrts;
        }

        private static double CalculateDeterminant(double[,] array)
        {
            return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
        }
    }
}
