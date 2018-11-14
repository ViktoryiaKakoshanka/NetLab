using System;
using VectorProgram.Model;

namespace VectorProgram.Controller
{
    public static class VectorHelper
    {
        public static double AngleBetweenVectors(Vector ferst, Vector second)
        {
            var scalarMultiple = ferst.FirstCoordinate * second.FirstCoordinate + ferst.SecondCoordinate * second.SecondCoordinate + ferst.ThirdCoordinate + second.ThirdCoordinate;

            var moduleFirstVector = Math.Sqrt(Math.Pow(ferst.FirstCoordinate, 2) + Math.Pow(ferst.SecondCoordinate, 2) + Math.Pow(ferst.ThirdCoordinate, 2));
            var moduleSecondVector = Math.Sqrt(Math.Pow(second.FirstCoordinate, 2) + Math.Pow(second.SecondCoordinate, 2) + Math.Pow(second.ThirdCoordinate, 2));

            var angle = scalarMultiple / (moduleFirstVector * moduleSecondVector);

            return angle;
        }

        public static string VectorMultiplicate(Vector first, Vector second)
        {
            var i = 1;
            var j = 1;
            var k = 1;

            var determinantOne = (first.SecondCoordinate * second.ThirdCoordinate - first.ThirdCoordinate * second.SecondCoordinate) * i;
            var determinantTwo = (first.ThirdCoordinate * second.FirstCoordinate - first.FirstCoordinate * second.ThirdCoordinate) * j;
            var determinantThree = (first.FirstCoordinate * second.SecondCoordinate - first.SecondCoordinate * second.FirstCoordinate) * k;

            return $"{determinantOne.ToString()} * i + {determinantTwo.ToString()} * j + {determinantThree.ToString()} * k";
        }

    }
}
