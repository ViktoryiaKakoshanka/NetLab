using System;

namespace PolynomialProgram.Helpers
{
<<<<<<< HEAD:FifthLesson/VectorProgram/PolynomialProgram/Controller/ExtensionForDouble.cs
<<<<<<< HEAD:FifthLesson/VectorProgram/PolynomialProgram/Controller/ExtensionForDouble.cs
    public static class ExtensionForDouble
    {
        public static bool IsEquals(this double first, double second, double delta = 0.001)
=======
    public static class DataParser
    {
        public static double ParseDouble(string value)
>>>>>>> master:SecondLesson/NewtonsMethod/NewtonsMethod/Controller/DataParser.cs
=======
    public static class DoubleExtensions
    {
        public static bool IsEqual(this double first, double second, double delta = 0.001)
>>>>>>> RefactoringInLab:FifthLesson/VectorProgram/PolynomialProgram/Helpers/DoubleExtensions.cs
        {
            return Math.Abs(first - second) <= delta;
        }
<<<<<<< HEAD:FifthLesson/VectorProgram/PolynomialProgram/Controller/ExtensionForDouble.cs
=======

        public static int ParseInt(string value) => Convert.ToInt32(value);
>>>>>>> master:SecondLesson/NewtonsMethod/NewtonsMethod/Controller/DataParser.cs
    }
}