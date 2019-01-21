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
            var number = double.Parse(RequestUserInput(ValidationType.Number, "Enter the number under the root"));
            var rootPower = int.Parse(RequestUserInput(ValidationType.RootPower, "Enter the power"));
            var accuracy = double.Parse(RequestUserInput(ValidationType.Accuracy, "Enter a calculation accuracy from 0 to 1"));

            var rootNewton = Calculator.CalculateRootByMethodNewtons(number, rootPower, accuracy);
            var rootMath = Calculator.CalculateRootNumberByMath(number, rootPower);

            _view.PrintCompareResult(number, rootPower, rootNewton, rootMath);
        }

        private string RequestUserInput(ValidationType dataType, string welcomeMessage)
        {
            string userInput;

            do
            {
                userInput = _view.RequestInput(welcomeMessage);
            } while (!ValidateUserInput(dataType, userInput));

            return userInput;
        }

        private bool ValidateUserInput(ValidationType param, string userInput)
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
