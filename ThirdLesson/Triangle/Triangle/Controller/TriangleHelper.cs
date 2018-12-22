using System;
using TriangleLib.Model;

namespace TriangleLib.Controller
{
    public static class TriangleHelper
    {
        public static double CalculatePerimeter(Triangle triangle) => triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide;

        public static double CalculateArea(Triangle triangle)
        {
            var semiperimeter = CalculatePerimeter(triangle) / 2;

            var semiperimeterWithoutFirstSide = semiperimeter - triangle.FirstSide;
            var semiperimeterWithoutSecondSide = semiperimeter - triangle.SecondSide;
            var semiperimeterWithoutThirdSide = semiperimeter - triangle.ThirdSide;

<<<<<<< HEAD:ThirdLesson/Triangle/Triangle/Controller/TriangleCalculations.cs
            var multiplicationOfAllParts = semiperimeter * semiperimeterWithoutFirstSide * semiperimeterWithoutSecondSide * semiperimeterWithoutThirdSide;
            
            return Math.Sqrt(multiplicationOfAllParts);
=======
            var multiplicationAllParts = semiperimeter * semiperimeterWithoutFirstSide * semiperimeterWithoutSecondSide * semiperimeterWithoutThirdSide;

            return Math.Sqrt(multiplicationAllParts);
>>>>>>> master:ThirdLesson/Triangle/Triangle/Controller/TriangleHelper.cs
        }

        public static Triangle TryCreateTriangle(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            var triangleExists = Validator.TriangleExists(firstSideLength, secondSideLength, thirdSideLength);

            if (!triangleExists)
            {
                return null;
            }

            return new Triangle(firstSideLength, secondSideLength, thirdSideLength);
        }
    }
}
