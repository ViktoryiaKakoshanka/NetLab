using System;
using TriangleLib.Model;

namespace TriangleLib.Controller
{
    public class TriangleCalculations
    {

        public static double CalculateThePerimeter(Triangle triangle)
        {
            return triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide;
        }

        public static double CalculateTheArea(Triangle triangle)
        {
            var semiperimeter = CalculateThePerimeter(triangle) / 2;
            var area = Math.Sqrt(semiperimeter * (semiperimeter - triangle.FirstSide) * (semiperimeter - triangle.SecondSide) * (semiperimeter - triangle.ThirdSide));
            return Math.Round(area, 6);
        }
    }
}
