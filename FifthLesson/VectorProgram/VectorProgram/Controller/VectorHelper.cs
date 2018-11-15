using System;
using VectorProgram.Model;

namespace VectorProgram.Controller
{
    public static class VectorHelper
    {
        public static double CalculateAngleBetweenVectors(IVector first, IVector second)
        {
            var scalarMultiplicationResult = first.FirstCoordinate * second.FirstCoordinate + first.SecondCoordinate * second.SecondCoordinate + first.ThirdCoordinate * second.ThirdCoordinate;

            var moduleFirstVector = CalculateModuleVector(first);
            var moduleSecondVector = CalculateModuleVector(second);
            var moduleMultipleVectors = moduleFirstVector * moduleSecondVector;

            var angle = scalarMultiplicationResult / moduleMultipleVectors;

            return angle;
        }

        public static string CalculateVectorMultiplicate(IVector first, IVector second)
        {
            var arrayForFirstOrta = new[,] {
                { first.SecondCoordinate, first.ThirdCoordinate },
                { second.SecondCoordinate, second.ThirdCoordinate }
            };
            var arrayForSecondOrta = new[,] {
                { first.FirstCoordinate, first.ThirdCoordinate },
                { second.FirstCoordinate, second.ThirdCoordinate }
            };
            var arrayForThirdOrta = new[,] {
                { first.FirstCoordinate, first.SecondCoordinate },
                { second.FirstCoordinate, second.SecondCoordinate }
            };
            
            var determinantOne = CalculateDeterminantTwoByTwo(arrayForFirstOrta);
            var determinantTwo = CalculateDeterminantTwoByTwo(arrayForFirstOrta);
            var determinantThree = CalculateDeterminantTwoByTwo(arrayForFirstOrta);

            return $"({determinantOne.ToString()}) * i + ({determinantTwo.ToString()}) * j + ({determinantThree.ToString()}) * k";
        }

        public static double CalculateModuleVector(IVector vector)
        {
            var powFirst = Math.Pow(vector.FirstCoordinate, 2);
            var powSecond = Math.Pow(vector.SecondCoordinate, 2);
            var powThird = Math.Pow(vector.ThirdCoordinate, 2);

            var result = Math.Sqrt(powFirst + powSecond + powThird);
            return Math.Abs(result);
        }

        private static double CalculateDeterminantTwoByTwo(double[,] elements)
        {
            return elements[0,0] * elements[1,1] - elements[0, 1] * elements[1, 0];
        }

    }
}
