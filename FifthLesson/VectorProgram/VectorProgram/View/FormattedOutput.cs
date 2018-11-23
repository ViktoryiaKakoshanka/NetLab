using System;
using VectorProgram.Model;

namespace VectorProgram.View
{
    public class FormattedOutput
    {
        private IConsoleView _view;

        public FormattedOutput(IConsoleView view)
        {
            _view = view;
        }

        public void ShowVectors(Vector first, Vector second)
        {
            _view.WriteLine("Your vectors:");
            _view.WriteLine($"1 vector: {first}");
            _view.WriteLine($"2 vector: {second}\n");
        }

        public void ShowSimpleActionsWithVectorsResults(Vector[] initialVectors, Vector sumResult, Vector differenceResult)
        {
            _view.WriteLine("Actions with vectors:");
            _view.WriteLine($"{initialVectors[0]} + {initialVectors[1]} = {sumResult}");
            _view.WriteLine($"{initialVectors[0]} - {initialVectors[1]} = {differenceResult}");
        }

        public void ShowScalarMultiplicationResult(Vector[] initialVectors, double result)
        {
            _view.WriteLine($"Scalar multiplication: {initialVectors[0]} * {initialVectors[1]} = {result}\n");
        }

        public void ShowVectorsMultiplicationResult(Vector[] initialVectors, Vector result)
        {
            _view.WriteLine($"Vector multiplication: {initialVectors[0]} x {initialVectors[1]} = {result}\n");
        }

        public void ShowMultiplicationVectorsByNumberResults(Vector[] initialVectors, Vector[] resultNumberRight, Vector[] resultNumberLeft, double multiplier)
        {
            _view.WriteLine("Multiplication of vectors by number:");

            _view.WriteLine($"{initialVectors[0]} * {multiplier} = {resultNumberRight[0]}");
            _view.WriteLine($"{initialVectors[1]} * {multiplier} = {resultNumberRight[1]}\n");
            _view.WriteLine($"{multiplier} * {initialVectors[0]} = {resultNumberLeft[0]}");
            _view.WriteLine($"{multiplier} * {initialVectors[1]} = {resultNumberLeft[1]}");
        }

        public void ShowCompareVectorsResults(Vector[] initialVectors, bool equalityResult, bool inequalityResult)
        {
            _view.WriteLine("Compare vectors:");
            _view.WriteLine($"{initialVectors[0]} == {initialVectors[1]} = {equalityResult}");
            _view.WriteLine($"{initialVectors[0]} != {initialVectors[1]} = {inequalityResult}");
            _view.WriteLine(string.Empty);
        }

        public void ShowAngleBetweenVectorsResult(Vector[] initialVectors, double angle)
        {
            _view.WriteLine($"The angle between {initialVectors[0]} and {initialVectors[1]} = {Math.Abs(angle)}");
            _view.WriteLine(string.Empty);
        }
    }
}
