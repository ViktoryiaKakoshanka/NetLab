using System;
using System.Collections.Generic;
using VectorProgram.Model;

namespace VectorProgram.View
{
    public class ConsoleView : IConsoleView, IVectorView
    {
        public void WaitForAnyKeyPress() => Console.ReadKey(true);

        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string text) => Console.WriteLine(text);

        public void WriteErrorMessage() => Console.WriteLine("You entered incorrect numbers.");

        public void ShowVectors(IList<Vector> vectors)
        {
            WriteLine("Your vectors:");

            foreach (var vector in vectors)
            {
                WriteLine(vector.ToString());
            }
        }

        public void ShowSimpleActionsWithVectorsResults(Vector first, Vector second, Vector sumResult, Vector differenceResult)
        {
            WriteLine("Actions with vectors:");
            WriteLine($"{first} + {second} = {sumResult}");
            WriteLine($"{first} - {second} = {differenceResult}");
        }

        public void ShowScalarMultiplicationResult(Vector first, Vector second, double result)
        {
            WriteLine($"Scalar multiplication: {first} * {second} = {result}\n");
        }

        public void ShowVectorsMultiplicationResult(Vector first, Vector second, Vector result)
        {
            WriteLine($"Vector multiplication: {first} x {second} = {result}\n");
        }

        public void ShowMultiplicationVectorsByNumberResults(Vector first, Vector second, IList<Vector> resultNumberRight, IList<Vector> resultNumberLeft, double multiplier)
        {
            WriteLine("Multiplication of vectors by number:");

            WriteLine($"{first} * {multiplier} = {resultNumberRight[0]}");
            WriteLine($"{second} * {multiplier} = {resultNumberRight[1]}\n");
            WriteLine($"{multiplier} * {first} = {resultNumberLeft[0]}");
            WriteLine($"{multiplier} * {second} = {resultNumberLeft[1]}");
        }

        public void ShowVectorsComparisonResults(Vector first, Vector second, bool equalityResult, bool inequalityResult)
        {
            WriteLine("Compare vectors:");
            WriteLine($"{first} == {second} = {equalityResult}");
            WriteLine($"{first} != {second} = {inequalityResult}");
            WriteLine(string.Empty);
        }

        public void ShowAngleBetweenVectorsResult(Vector first, Vector second, double angle)
        {
            WriteLine($"The angle between {first} and {second} = {Math.Abs(angle)}");
            WriteLine(string.Empty);
        }
    }
}
