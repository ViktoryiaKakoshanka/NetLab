using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using NewtonsMethod.View;

namespace NewtonsMethod
{
    public class ProgramRunner
    {
        private readonly IView _view;

        public ProgramRunner(IView view)
        {
            _view = view;
        }

        public void RunProgram()
        {
            var number = double.Parse(RequestUserInput(DataType.Number, "Enter the number under the root"));
            var power = int.Parse(RequestUserInput(DataType.Power, "Enter the root stem"));
            var accuracy = double.Parse(RequestUserInput(DataType.Accuracy, "Enter a calculation accuracy from 0 to 1"));
            
            var compareResult = Calculator.Compare(number, power, accuracy, out var delta);

            _view.PrintNumberRoot(number, power, Calculator.CalculateRootNumberByNewtons(number, power, accuracy));
            _view.PrintCompareResult(compareResult, delta);
        }

        private string RequestUserInput(DataType dataType, string welcomeMessage)
        {
            string userInput;

            do
            {
                userInput = _view.RequestInput(welcomeMessage);
            } while (!ValidateUserInput(dataType, userInput));

            return userInput;
        }

        private bool ValidateUserInput(DataType param, string userInput)
        {
            var correctInput = Validator.ValidateInput(userInput, param);
            if (!correctInput)
            {
                _view.ShowErrorMessageUserInput();
            }

            return correctInput;
        }
    }
}
