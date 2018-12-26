using System;

namespace PolynomialProgram.Helpers
{
    public static class ExtensionForDouble
    {
        public static bool IsEqual(this double first, double second, double delta = 0.001)
        {
            return Math.Abs(first - second) <= delta;
        }
    }
}