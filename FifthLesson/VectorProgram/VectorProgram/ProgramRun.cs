using PolynomialProgram.Controller;
using PolynomialProgram.Model;
using VectorProgram.Model;
using VectorProgram.View;

namespace VectorProgram
{
    internal class ProgramRun
    {
        private readonly IView _view;

        internal ProgramRun(IView view)
        {
            _view = view;
        }

        public void Run()
        {
            var vectorFirst = RequestVector("first");
            var vectorSecond = RequestVector("second");

            _view.ShowVectors(vectorFirst, vectorSecond);

            var multiplier = RequestMultiplier();
            ProgramRunnerHelper.PerformActionsWithVectors(vectorFirst, vectorSecond, multiplier, _view);

            _view.Exit();
        }

        private double RequestMultiplier()
        {
            var userInput = RequestInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseDouble(userInput);
        }
        
        private Vector RequestVector(string orderByVectors)
        {
            var userInput = RequestInput(DataType.Vector, $"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space:");
            return ParseVector(userInput);
        }
                
        private static Vector ParseVector(string userInput)
        {
            var coords = DataParser.ParseArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }

        private string RequestInput(DataType dataType, string welcomeMessage)
        {
            string userInput;

            do
            {
                userInput = _view.ReadInput(welcomeMessage);
            } while (ValidateUserInput(dataType, userInput));

            return userInput;
        }

        private bool ValidateUserInput(DataType dataType, string userInput)
        {
            var isUserInputCorrect = Validator.ValidateInput(dataType, userInput);
            if (!isUserInputCorrect)
            {
                _view.ShowErrorMessage();
            }

            return isUserInputCorrect;
        }
    }
}
