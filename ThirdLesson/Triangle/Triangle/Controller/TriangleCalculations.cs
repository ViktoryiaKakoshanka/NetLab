using System;
using TriangleLib.Model;

namespace TriangleLib.Controller
{
    public class TriangleCalculations
    {

        public static double CalculateThePerimeter(Triangle triangle)
        {
            return triangle.A + triangle.B + triangle.C;
        }

        public static double CalculateTheArea(Triangle triangle)
        {
            double p = CalculateThePerimeter(triangle) / 2;
            double area = Math.Sqrt(p * (p - triangle.A) * (p - triangle.B) * (p - triangle.C));
            return Math.Round(area, 6);
        }
    }
}
