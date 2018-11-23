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

            CallActionsWithVectors(vectors);

            CallCompareVectors(vectors);
            
            CallAngleBetweenVectors(vectors);

            _view.PressKeyToContinue();
        }

        private Vector[] CreateVectors()
        {
            Vector vectorFirst = RequestVector("first");
            Vector vectorSecond = RequestVector("second");

            return new[] { vectorFirst, vectorSecond };
        }
        
        private void CallActionsWithVectors(Vector[] vectors)
        {
            CallSimpleActionsWithVectors(vectors);
            CallVectorMultiplication(vectors);
            CallMultiplyVectorsByNumber(vectors);
        }

        private void CallCompareVectors(Vector[] vectors)
        {
            var equalityResult = (vectors[0] == vectors[1]);
            var inequalityResult = vectors[0] != vectors[1];
            _formattedOutput.ShowCompareVectorsResults(vectors, equalityResult, inequalityResult);
        }

        private void CallAngleBetweenVectors(Vector[] vectors)
        {
            var angle = VectorHelper.CalculateAngle(vectors[0], vectors[1]);
            _formattedOutput.ShowAngleBetweenVectorsResult(vectors, angle);
        }

        private void CallSimpleActionsWithVectors(Vector[] vectors)
        {
            var sumResult = vectors[0] + vectors[1];
            var differenceResult = vectors[0] - vectors[1];

            _formattedOutput.ShowSimpleActionsWithVectorsResults(vectors, sumResult, differenceResult);
        }

        private void CallScalarMultiplication(Vector[] vectors)
        {
            var multiplicationResult = VectorHelper.CalculateScalarMultiplication(vectors[0], vectors[1]);
            _formattedOutput.ShowScalarMultiplicationResult(vectors, multiplicationResult);
        }

        private void CallVectorMultiplication(Vector[] vectors)
        {
            var vectorMultiplicationResult = VectorHelper.CalculateVectorMultiplication(vectors[0], vectors[1]);
            _formattedOutput.ShowVectorsMultiplicationResult(vectors, vectorMultiplicationResult);
        }

        private void CallMultiplyVectorsByNumber(Vector[] vectors)
        {
            var multiplier = RequestUserNumberMultiplier();

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

        private double RequestUserNumberMultiplier()
        {
            var userInput = _userInput.RequestUserInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseDouble(userInput);
        }
                
        private Vector ParseVector(string userInput)
        {
            var coords = DataParser.ParseArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }
        
    }
}
