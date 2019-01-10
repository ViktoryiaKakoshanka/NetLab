using System;
using TriangleLib.Model;

namespace TriangleLib.Helpers
{
    public class TriangleHelper
    {
        public static double CalculatePerimeter(Triangle triangle) => triangle.FirstEdge + triangle.SecondEdge + triangle.ThirdEdge;

        public static double CalculateArea(Triangle triangle)
        {
            var semiperimeter = CalculatePerimeter(triangle) / 2;

            var area = semiperimeter * (semiperimeter - triangle.FirstEdge) * 
                                       (semiperimeter - triangle.SecondEdge) * 
                                       (semiperimeter - triangle.ThirdEdge);

            return Math.Sqrt(area);
        }
    }
}