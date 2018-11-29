using System;
using VectorProgram.Model;
using System.Collections.Generic;

namespace VectorProgram.View
{
    public class FormattedOutput
    {
        private IConsoleView _view;

        public FormattedOutput(IConsoleView view)
        {
            _view = view;
        }

        public void ShowVectors(IList<Vector> vectors)
        {
            _view.WriteLine("Your vectors:");

            foreach (var vector in vectors)
            {
                _view.WriteLine(vector.ToString());
            }
        }

        public void ShowSimpleActionsWithVectorsResults(Vector first, Vector second, Vector sumResult, Vector differenceResult)
        {
            _view.WriteLine("Actions with vectors:");
            _view.WriteLine($"{first} + {second} = {sumResult}");
            _view.WriteLine($"{first} - {second} = {differenceResult}");
        }

        public void ShowScalarMultiplicationResult(Vector first, Vector second, double result)
        {
            _view.WriteLine($"Scalar multiplication: {first} * {second} = {result}\n");
        }

        public void ShowVectorsMultiplicationResult(Vector first, Vector second, Vector result)
        {
            _view.WriteLine($"Vector multiplication: {first} x {second} = {result}\n");
        }

        public void ShowMultiplicationVectorsByNumberResults(Vector first, Vector second, IList<Vector> resultNumberRight, IList<Vector> resultNumberLeft, double multiplier)
        {
            _view.WriteLine("Multiplication of vectors by number:");

            _view.WriteLine($"{first} * {multiplier} = {resultNumberRight[0]}");
            _view.WriteLine($"{second} * {multiplier} = {resultNumberRight[1]}\n");
            _view.WriteLine($"{multiplier} * {first} = {resultNumberLeft[0]}");
            _view.WriteLine($"{multiplier} * {second} = {resultNumberLeft[1]}");
        }

        public void ShowVectorsComparisonResults(Vector first, Vector second, bool equalityResult, bool inequalityResult)
        {
            _view.WriteLine("Compare vectors:");
            _view.WriteLine($"{first} == {second} = {equalityResult}");
            _view.WriteLine($"{first} != {second} = {inequalityResult}");
            _view.WriteLine(string.Empty);
        }

        public void ShowAngleBetweenVectorsResult(Vector first, Vector second, double angle)
        {
            _view.WriteLine($"The angle between {first} and {second} = {Math.Abs(angle)}");
            _view.WriteLine(string.Empty);
        }
    }
}
