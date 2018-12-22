using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using NewtonsMethod.View;
using System;

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
            var radicalSign = CreateRadicalSign();

            var radicalSignMethodNewton = Calculator.CalculateRadicalSign(radicalSign);
            var radicalSignMathPow = Calculator.CalculateRootNumber(radicalSign);
            
            _view.PrintCompareResult(radicalSign, radicalSignMethodNewton, radicalSignMathPow);
        }

        private IRadicalSign CreateRadicalSign()
        {
            var numericalRoot = RequestUserInput(DataType.Numerical, "Enter the number under the root");
            var power = RequestUserInput(DataType.Power, "Enter the root stem");
            var accuracy = RequestUserInput(DataType.Accuracy, "Enter a calculation accuracy from 0 to 1");

            return new RadicalSign(Convert.ToDouble(numericalRoot), Convert.ToInt32(power), Convert.ToDouble(accuracy));
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