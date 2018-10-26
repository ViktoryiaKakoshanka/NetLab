using System;
using TriangleLib.Model;

namespace TriangleLib.Controller
{
    public class TriangleCalculations
    {

        public static double CalculateThePerimeter(Triangle triangle)
        {
            return triangle.GetA() + triangle.GetB() + triangle.GetC();
        }

        public static double CalculateTheArea(Triangle triangle)
        {
            double p = CalculateThePerimeter(triangle) / 2;
            double area = Math.Sqrt(p * (p - triangle.GetA()) * (p - triangle.GetB()) * (p - triangle.GetC()));
            return Math.Round(area, 6);
        }
    }
}
