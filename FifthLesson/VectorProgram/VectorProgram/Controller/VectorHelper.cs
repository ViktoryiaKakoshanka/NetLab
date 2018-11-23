using System;
using VectorProgram.Model;

namespace VectorProgram.Controller
{
    public static class VectorHelper
    {
        public static double CalculateAngle(Vector first, Vector second)
        {
            var scalarMultiplicationResult = VectorHelper.CalculateScalarMultiplication(first, second);

            var firstVectorModule = CalculateModule(first);
            var secondVectorModule = CalculateModule(second);

            var productOfVectorModules = firstVectorModule * secondVectorModule;

            var angle = scalarMultiplicationResult / productOfVectorModules;

            return angle;
        }

        public static Vector CalculateVectorMultiplication(Vector first, Vector second)
        {
            var arrayForOrts = CreateArrayOrts(first, second);
            
            var determinantOne = CalculateDeterminant(arrayForOrts[0]);
            var determinantTwo = CalculateDeterminant(arrayForOrts[1]);
            var determinantThree = CalculateDeterminant(arrayForOrts[2]);

            return new Vector(determinantOne, determinantTwo, determinantThree);
        }

        public static double CalculateModule(Vector vector)
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

        public static double CalculateDeterminant(double[,] array)
        {
            var mainDiagonal = array[0, 0] * array[1, 1];
            var sideDiagonal = array[0, 1] * array[1, 0];
            return mainDiagonal - sideDiagonal;
        }

        public static double CalculateScalarMultiplication(Vector first, Vector second)
        {
            var multiplicationFirstCoordinates = first.FirstCoordinate * second.FirstCoordinate;
            var multiplicationSecondCoordinates = first.SecondCoordinate * second.SecondCoordinate;
            var multiplicationThirdCoordinates = first.ThirdCoordinate * second.ThirdCoordinate;

            var sumMultiplicationCoordinates = multiplicationFirstCoordinates + multiplicationSecondCoordinates + multiplicationThirdCoordinates;

            return sumMultiplicationCoordinates;
        }
    }
}
