using System;

namespace PolynomialProgram.Controller
{
<<<<<<< HEAD:FifthLesson/VectorProgram/PolynomialProgram/Controller/ExtensionForDouble.cs
    public static class ExtensionForDouble
    {
        public static bool IsEquals(this double first, double second, double delta = 0.001)
=======
    public static class DataParser
    {
        public static double ParseDouble(string value)
>>>>>>> master:SecondLesson/NewtonsMethod/NewtonsMethod/Controller/DataParser.cs
        {
            return Math.Abs(first - second) <= delta;
        }
<<<<<<< HEAD:FifthLesson/VectorProgram/PolynomialProgram/Controller/ExtensionForDouble.cs
=======

        public static int ParseInt(string value) => Convert.ToInt32(value);
>>>>>>> master:SecondLesson/NewtonsMethod/NewtonsMethod/Controller/DataParser.cs
    }
}
