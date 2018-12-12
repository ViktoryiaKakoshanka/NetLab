using System.Collections.Generic;
using VectorProgram.Controller;
using VectorProgram.Model;
using VectorProgram.View;

namespace VectorProgram
{
    internal class ProgramRun
    {
        private readonly IView _view;

        public ProgramRun(IView view)
        {
            _view = view;
        }

        public void Run()
        {
            var vectors = CreateVectors();

            _view.ShowVectors(vectors);

            CallActionsWithVectors(vectors[0], vectors[1]);

            _view.Exit();
        }

        private List<Vector> CreateVectors()
        {
            var vectorFirst = RequestVector("first");
            var vectorSecond = RequestVector("second");

            return new List<Vector> { vectorFirst, vectorSecond, vectorFirst };
        }
        
        private void CallActionsWithVectors(Vector first, Vector second)
        {
            CallSimpleActionsWithVectors(first, second);
            CallVectorMultiplication(first, second);
            CallMultiplyVectorsByNumber(first, second);
            CallScalarMultiplication(first, second);
            CompareVectors(first, second);
            CallAngleBetweenVectors(first, second);
        }

        private void CompareVectors(Vector first, Vector second)
        {
            var equalityResult = first == second;
            var inequalityResult = first != second;
            _view.ShowVectorsComparisonResults(first, second, equalityResult, inequalityResult);
        }

        private void CallAngleBetweenVectors(Vector first, Vector second)
        {
            var angle = VectorHelper.CalculateAngle(first, second);
            _view.ShowAngleBetweenVectorsResult(first, second, angle);
        }

        private void CallSimpleActionsWithVectors(Vector first, Vector second)
        {
            var sumResult = first + second;
            var differenceResult = first - second;

            _view.ShowSimpleActionsWithVectorsResults(first, second, sumResult, differenceResult);
        }

        private void CallScalarMultiplication(Vector first, Vector second)
        {
            var multiplicationResult = VectorHelper.CalculateScalarMultiplication(first, second);
            _view.ShowScalarMultiplicationResult(first, second, multiplicationResult);
        }

        private void CallVectorMultiplication(Vector first, Vector second)
        {
            var vectorMultiplicationResult = VectorHelper.CalculateVectorMultiplication(first, second);
            _view.ShowVectorsMultiplicationResult(first, second, vectorMultiplicationResult);
        }

        private void CallMultiplyVectorsByNumber(Vector first, Vector second)
        {
            var multiplier = RequestMultiplier();

            var multiplicationVectorsByNumberRight = new List<Vector>
            {
                first * multiplier,
                second * multiplier
            };

            var multiplicationVectorsByNumberLeft = new List<Vector>
            {
                multiplier * first,
                multiplier * second
            };

            _view.ShowMultiplicationVectorsByNumberResults(first, second, multiplicationVectorsByNumberRight, multiplicationVectorsByNumberLeft, multiplier);
        }
        
        private Vector RequestVector(string orderByVectors)
        {
            var userInput = RequestInput(DataType.Vector, $"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space:");
            return ParseVector(userInput);
        }

        private double RequestMultiplier()
        {
            var userInput = RequestInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseDouble(userInput);
        }
                
        private Vector ParseVector(string userInput)
        {
            var coords = DataParser.ParseArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }

        private string RequestInput(DataType dataType, string welcomeMessage)
        {
            var userInput = string.Empty;
            var isUserInputCorrect = false;

            while (!isUserInputCorrect)
            {
                userInput = _view.ReadLine(welcomeMessage);
                isUserInputCorrect = ValidateUserInput(dataType, userInput);
            }

            return userInput;
        }

        private bool ValidateUserInput(DataType dataType, string userInput)
        {
            var isUserInputCorrect = Validator.ValidateInput(dataType, userInput);
            if (!isUserInputCorrect) _view.WriteErrorMessage();

            return isUserInputCorrect;
        }
    }
}
