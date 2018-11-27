using System.Collections.Generic;
using VectorProgram.Controller;
using VectorProgram.Model;
using VectorProgram.UserInput;
using VectorProgram.View;

namespace VectorProgram
{
    class ProgramRun
    {
        private IConsoleView _view;
        private FormattedOutput _formattedOutput;
        private IUserInputProcessor _userInput;

        public void Run(IConsoleView view)
        {
            _view = view;
            _userInput = new ProcessingUserInput(_view);
            _formattedOutput = new FormattedOutput(_view);

            var vectors = CreateVectors();

            var isCorrectedListVectors = GetIsCorrectedListVectors(vectors);
            if (isCorrectedListVectors) return;

            _formattedOutput.ShowVectors(vectors);

            CallActionsWithVectors(vectors);
            CallScalarMultiplication(vectors);
            CompareVectors(vectors);
            CallAngleBetweenVectors(vectors);

            _view.WaitForAnyKeyPress();
        }

        private List<Vector> CreateVectors()
        {
            Vector vectorFirst = RequestVector("first");
            Vector vectorSecond = RequestVector("second");

            return new List<Vector>()  { vectorFirst, vectorSecond, vectorFirst };
        }
        
        private void CallActionsWithVectors(List<Vector> vectors)
        {
            CallSimpleActionsWithVectors(vectors);
            CallVectorMultiplication(vectors);
            CallMultiplyVectorsByNumber(vectors);
        }

        private void CompareVectors(List<Vector> vectors)
        {
            var equalityResult = (vectors[0] == vectors[1]);
            var inequalityResult = vectors[0] != vectors[1];
            _formattedOutput.ShowVectorsComparisonResults(vectors, equalityResult, inequalityResult);
        }

        private void CallAngleBetweenVectors(List<Vector> vectors)
        {
            var angle = VectorHelper.CalculateAngle(vectors[0], vectors[1]);
            _formattedOutput.ShowAngleBetweenVectorsResult(vectors, angle);
        }

        private void CallSimpleActionsWithVectors(List<Vector> vectors)
        {
            var sumResult = vectors[0] + vectors[1];
            var differenceResult = vectors[0] - vectors[1];

            _formattedOutput.ShowSimpleActionsWithVectorsResults(vectors, sumResult, differenceResult);
        }

        private void CallScalarMultiplication(List<Vector> vectors)
        {
            var multiplicationResult = VectorHelper.CalculateScalarMultiplication(vectors[0], vectors[1]);
            _formattedOutput.ShowScalarMultiplicationResult(vectors, multiplicationResult);
        }

        private void CallVectorMultiplication(List<Vector> vectors)
        {
            var vectorMultiplicationResult = VectorHelper.CalculateVectorMultiplication(vectors[0], vectors[1]);
            _formattedOutput.ShowVectorsMultiplicationResult(vectors, vectorMultiplicationResult);
        }

        private void CallMultiplyVectorsByNumber(List<Vector> vectors)
        {
            var multiplier = RequestMultiplier();

            var multiplicationVectorsByNumberRight = new List<Vector>
            {
                (vectors[0] * multiplier),
                (vectors[1] * multiplier)
            };

            var multiplicationVectorsByNumberLeft = new List<Vector>
            {
                (multiplier * vectors[0]),
                (multiplier * vectors[1])
            };
            
            _formattedOutput.ShowMultiplicationVectorsByNumberResults(vectors, multiplicationVectorsByNumberRight, multiplicationVectorsByNumberLeft, multiplier);
        }
        
        private Vector RequestVector(string orderByVectors)
        {
            var userInput = _userInput.RequestUserInput(DataType.Vector, $"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space:");
            return ParseVector(userInput);
        }

        private double RequestMultiplier()
        {
            var userInput = _userInput.RequestUserInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseDouble(userInput);
        }
                
        private Vector ParseVector(string userInput)
        {
            var coords = DataParser.ParseArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }
        
        private bool GetIsCorrectedListVectors(List<Vector> vectors)
        {
            return (vectors.Count < 2 || vectors == null);
        }
    }
}
