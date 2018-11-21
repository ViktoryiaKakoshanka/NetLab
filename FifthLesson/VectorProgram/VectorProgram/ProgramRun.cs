using System;
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
        private IProcessingUserInput _userInput;

        public void Run(IConsoleView view)
        {
            _view = view;
            _userInput = new ProcessingUserInput(_view);

            var vectors = CreateVectors();

            _formattedOutput.ShowVectors(vectors[0], vectors[1]);

            ActionsWithVectors(vectors);

            CompareVectors(vectors);
            
            AngleBetweenVectors(vectors);

            _view.ReadKey();
        }

        private Vector[] CreateVectors()
        {
            Vector vectorFirst = RequestVector("first");
            Vector vectorSecond = RequestVector("second");

            return new[] { vectorFirst, vectorSecond };
        }
        
        private void ActionsWithVectors(Vector[] vectors)
        {
            SimpleActionsWithVectors(vectors);
            VectorsMultiplication(vectors);
            MultiplicationVectorsByNumber(vectors);
        }

        private void CompareVectors(Vector[] vectors)
        {
            var equalityResult = (vectors[0] == vectors[1]);
            var inequalityResult = vectors[0] != vectors[1];
            _formattedOutput.ShowCompareVectorsResults(vectors, equalityResult, inequalityResult);
        }

        private void AngleBetweenVectors(Vector[] vectors)
        {
            var angle = vectors[0].CalculateAngleBetweenVectors(vectors[1]);
            _formattedOutput.ShowAngleBetweenVectorsResult(vectors, angle);
        }

        private void SimpleActionsWithVectors(Vector[] vectors)
        {
            var sumResult = vectors[0] + vectors[1];
            var differenceResult = vectors[0] - vectors[1];
            var multiplicationResult = vectors[0] * vectors[1];

            _formattedOutput.ShowSimpleActionsWithVectorsResults(vectors, sumResult, differenceResult, multiplicationResult);
        }

        private void VectorsMultiplication(Vector[] vectors)
        {
            var vectorMultiplicationResult = Vector.CalculateVectorsMultiplication(vectors[0], vectors[1]);
            _formattedOutput.ShowVectorsMultiplicationResult(vectors, vectorMultiplicationResult);
        }

        private void MultiplicationVectorsByNumber(Vector[] vectors)
        {
            var multiplier = GetUserNumberMultiplier();

            var multiplicationVectorsByNumberRight = new[]
            {
                (vectors[0] * multiplier),
                (vectors[1] * multiplier)
            };

            var multiplicationVectorsByNumberLeft = new[]
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

        private double GetUserNumberMultiplier()
        {
            var userInput = _userInput.RequestUserInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseToDouble(userInput);
        }
                
        private Vector ParseVector(string userInput)
        {
            var coords = DataParser.ParseStringToArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }
        
    }
}
