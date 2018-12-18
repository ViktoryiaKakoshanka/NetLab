using System;

namespace PolynomialProgram.Controller
{
    public static class DoubleExtensions
    {
        public static bool IsEqual(this double first, double second, double delta = 0.001)
        {
            return Math.Abs(first - second) <= delta;
        }
    }
}