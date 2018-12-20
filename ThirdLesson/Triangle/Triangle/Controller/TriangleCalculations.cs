using System;
using TriangleLib.Model;

namespace TriangleLib.Controller
{
    public class TriangleCalculations
    {
        public static double CalculatePerimeter(Triangle triangle) => triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide;

        public static double CalculateArea(Triangle triangle)
        {
            var semiperimeter = CalculatePerimeter(triangle) / 2;

            var area = semiperimeter * (semiperimeter - triangle.FirstSide) * 
                                       (semiperimeter - triangle.SecondSide) * 
                                       (semiperimeter - triangle.ThirdSide);

            return Math.Sqrt(area);
        }
    }
}