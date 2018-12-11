using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using NewtonsMethod.View;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NewtonsMethod
{
    public class Startup
    {
        private readonly IProgramView _view;
        private const int Digits = 5;

        public Startup(IProgramView programView)
        {
            _view = programView;
        }

        public void RunProgram()
        {
            var dataByUser = RequestDataByUser();
            var radicalSign = CreateRadicalSign(dataByUser[0], dataByUser[1], dataByUser[2]);

            var dataForCompare = PrepareDataForCompare(radicalSign);
            PrintCompareResult(radicalSign, dataForCompare[0], dataForCompare[1]);
        }

        private IList<string> RequestDataByUser()
        {
            var numericalRoot = RequestUserInput(DataType.Numerical, "Enter the number under the root");
            var power = RequestUserInput(DataType.Power, "Enter the root stem");
            var accuracy = RequestUserInput(DataType.Accuracy, "Enter a calculation accuracy from 0 to 1");

            return new List<string> { numericalRoot, power, accuracy };
        }

        private IRadicalSign CreateRadicalSign(string numericalRoot, string power, string accuracy)
        {
            var provider = new NumberFormatInfo
            {
                CurrencyDecimalSeparator = "."
            };
            var parsedNumericalRoot = Convert.ToDouble(numericalRoot, provider);
            var parsedPower = Convert.ToInt32(power);
            var parsedAccuracy = Convert.ToDouble(accuracy, provider);

            return new RadicalSign(parsedNumericalRoot, parsedPower, parsedAccuracy);
        }

        private IList<double> PrepareDataForCompare(IRadicalSign radicalSign)
        {
            var radicalSignMethodNewton = Calculator.CalculateRadicalSign(radicalSign);
            var radicalSignMathPow = Calculator.CalculateRootNumber(radicalSign);

            return new List<double> { radicalSignMethodNewton, radicalSignMathPow };
        }

        private void PrintCompareResult(IRadicalSign radicalSign, double radicalSignMethodNewton, double radicalSignMathPow)
        {
            _view.WriteLine(radicalSign.ToString());
            _view.WriteLine($"Newton's method is {Math.Round(radicalSignMethodNewton, Digits)}");
            _view.WriteLine("Check");
            _view.WriteLine($"{radicalSign.Root} to degree {radicalSign.Power} equally {Math.Round(radicalSignMathPow, Digits)}");
            _view.WaitForAnyKeyPress();
        }

        private string RequestUserInput(DataType dataType, string welcomeMessage)
        {
            var correctInput = false;
            var userInput = string.Empty;

            while (!correctInput)
            {
                userInput = _view.ReadLine(welcomeMessage);
                correctInput = ValidateUserInput(dataType, userInput);
            }
            return userInput;
        }

        private bool ValidateUserInput(DataType param, string userInput)
        {
            var correctInput = Validator.ValidateInput(userInput, param);
            if (!correctInput) _view.ShowErrorMessageUserInput();

            return correctInput;
        }
    }
}
