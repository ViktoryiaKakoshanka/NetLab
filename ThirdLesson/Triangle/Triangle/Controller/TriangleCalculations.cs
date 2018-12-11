using System;
using TriangleLib.Model;

namespace TriangleLib.Controller
{
    public class TriangleCalculations
    {
        public static double CalculateThePerimeter(Triangle triangle) => triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide;

        public static double CalculateTheArea(Triangle triangle)
        {
            var semiperimeter = CalculateThePerimeter(triangle) / 2;

            var semiperimeterWithoutFirstSide = semiperimeter - triangle.FirstSide;
            var semiperimeterWithoutSecondSide = semiperimeter - triangle.SecondSide;
            var semiperimeterWithoutThirdSide = semiperimeter - triangle.ThirdSide;

            var multiplicationOfAllParts = semiperimeter * semiperimeterWithoutFirstSide * semiperimeterWithoutSecondSide * semiperimeterWithoutThirdSide;
            
            return Math.Sqrt(multiplicationOfAllParts);
        }
    }
}
