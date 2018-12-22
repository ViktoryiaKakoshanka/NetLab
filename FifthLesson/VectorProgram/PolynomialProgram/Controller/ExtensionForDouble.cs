using System;

namespace PolynomialProgram.Controller
{
    public static class ExtensionForDouble
    {
        public static bool IsEquals(this double first, double second, double delta = 0.001)
        {
            return Math.Abs(first - second) <= delta;
        }
    }
}
