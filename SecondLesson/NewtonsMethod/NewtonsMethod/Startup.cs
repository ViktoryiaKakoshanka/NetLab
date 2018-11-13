using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using NewtonsMethod.View;
using System;

namespace NewtonsMethod
{
    public class Startup
    {
        private IProgramView _view;
        private IRadicalSign _radicalSign = null;

        public void RunProgram(IProgramView programView)
        {
            _view = programView;

            var dataByUser = InitializeDataByUser();
            _radicalSign = ParseAndCreateRadicalSign(dataByUser);

            var dataForCompare = PrepareDataForCompare();
            PrintCompareResult(dataForCompare);
        }

        private string[] InitializeDataByUser()
        {
            string numericalRoot, power, accurancy;

            numericalRoot = RequestUserInput(InputedParams.Numerical, "Enter the number under the root");
            power = RequestUserInput(InputedParams.Power, "Enter the root stem");
            accurancy = RequestUserInput(InputedParams.Аccurancy, "Enter a calculation accuracy from 0 to 1");

            return new[] { numericalRoot, power, accurancy };
        }

        private IRadicalSign ParseAndCreateRadicalSign(string[] dataByUser)
        {
            var dataParser = new DataParser();
            var parsedNumericalRoot = dataParser.ParseStringToDouble(dataByUser[0]);
            var parsedPower = dataParser.ParseStringToInt(dataByUser[1]);
            var parsedAccurancy = dataParser.ParseStringToDouble(dataByUser[2]);

            return new RadicalSign(parsedNumericalRoot, parsedPower, parsedAccurancy);
        }

        private double[] PrepareDataForCompare()
        {
            var calc = new Calculator();
            double radicalSignMethodNewton = calc.CalculateRadicalSign(_radicalSign);
            double radicalSignMathPow = calc.CalculateMathPow(_radicalSign);

            return new[] { radicalSignMethodNewton, radicalSignMathPow };
        }

        private void PrintCompareResult(double[] dataForCompare)
        {
            _view.WriteLine(_radicalSign.ToString());
            _view.WriteLine($"Newton's method is {Math.Round(dataForCompare[0], 5)}");
            _view.WriteLine("Check");
            _view.WriteLine($"{_radicalSign.Result} to degree {_radicalSign.Power} equally {Math.Round(dataForCompare[1], 5)}");
            _view.ReadKeyTrue();
        }

        private string RequestUserInput(InputedParams method, string welcomeMessage)
        {
            var correctInput = false;
            var userInput = string.Empty;

            while (!correctInput)
            {
                userInput = _view.ReadLine(welcomeMessage);
                correctInput = ValidateUserInput(method, userInput);
            }
            return userInput;
        }

        private bool ValidateUserInput(InputedParams param, string userInput)
        {
            var correctInput = Validator.ValidateInput(userInput, param);
            if (!correctInput) _view.ShowErrorMessageUserInput();

            return correctInput;
        }
    }
}
