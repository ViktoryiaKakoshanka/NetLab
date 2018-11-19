using System;
using VectorProgram.Model;

namespace VectorProgram.Controller
{
    public static class VectorHelper
    {
        public static double CalculateAngleBetweenVectors(Vector first, Vector second)
        {
            var scalarMultiplicationResult = first * second;

            var firstVectorModule = CalculateModuleVector(first);
            var secondVectorModule = CalculateModuleVector(second);

            var productOfVectorModules = firstVectorModule * secondVectorModule;

            var angle = scalarMultiplicationResult / productOfVectorModules;

            return angle;
        }

        public static Vector CalculateVectorMultiplication(Vector first, Vector second)
        {
            var arrayForOrts = CreateArrayOrts(first, second);
            
            var determinantOne = ArrayDeterminantCalculator.CalculateDeterminant(arrayForOrts[0]);
            var determinantTwo = ArrayDeterminantCalculator.CalculateDeterminant(arrayForOrts[1]);
            var determinantThree = ArrayDeterminantCalculator.CalculateDeterminant(arrayForOrts[2]);

            return new Vector(determinantOne, determinantTwo, determinantThree);
        }

        public static double CalculateModuleVector(Vector vector)
        {
            var powFirst = Math.Pow(vector.FirstCoordinate, 2);
            var powSecond = Math.Pow(vector.SecondCoordinate, 2);
            var powThird = Math.Pow(vector.ThirdCoordinate, 2);

            var result = Math.Sqrt(powFirst + powSecond + powThird);
            return Math.Abs(result);
        }

        private static double[][,] CreateArrayOrts(Vector first, Vector second)
        {
            var arrayOrts = new[]
            {
                new[,]
                {
                    { first.SecondCoordinate, first.ThirdCoordinate },
                    { second.SecondCoordinate, second.ThirdCoordinate },
                },
                new[,]
                {
                    { first.FirstCoordinate, first.ThirdCoordinate },
                    { second.FirstCoordinate, second.ThirdCoordinate }
                },
                new[,]
                {
                    { first.FirstCoordinate, first.SecondCoordinate },
                    { second.FirstCoordinate, second.SecondCoordinate }
                }
            };
            return arrayOrts;
        }
    }
}
