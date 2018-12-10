using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using NewtonsMethod.View;
using System;
using System.Collections.Generic;

namespace NewtonsMethod
{
    public class Startup
    {
        private IProgramView _view;
        private const int DIGITS = 5;

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
            string numericalRoot, power, accurancy;

            numericalRoot = RequestUserInput(DataType.Numerical, "Enter the number under the root");
            power = RequestUserInput(DataType.Power, "Enter the root stem");
            accurancy = RequestUserInput(DataType.Аccurancy, "Enter a calculation accuracy from 0 to 1");

            return new List<string> { numericalRoot, power, accurancy };
        }

        private IRadicalSign CreateRadicalSign(string numericalRoot, string power, string accurancy)
        {
            var dataParser = new DataParser();
            var parsedNumericalRoot = dataParser.ParseDouble(numericalRoot);
            var parsedPower = dataParser.ParseInt(power);
            var parsedAccurancy = dataParser.ParseDouble(accurancy);

            return new RadicalSign(parsedNumericalRoot, parsedPower, parsedAccurancy);
        }

        private IList<double> PrepareDataForCompare(IRadicalSign radicalSign)
        {
            var calculator = new Calculator();
            var radicalSignMethodNewton = calculator.CalculateRadicalSign(radicalSign);
            double radicalSignMathPow = calculator.CalculateMathPow(radicalSign);

            return new List<double> { radicalSignMethodNewton, radicalSignMathPow };
        }

        private void PrintCompareResult(IRadicalSign radicalSign, double radicalSignMethodNewton, double radicalSignMathPow)
        {
            _view.WriteLine(radicalSign.ToString());
            _view.WriteLine($"Newton's method is {Math.Round(radicalSignMethodNewton, DIGITS)}");
            _view.WriteLine("Check");
            _view.WriteLine($"{radicalSign.Root} to degree {radicalSign.Power} equally {Math.Round(radicalSignMathPow, DIGITS)}");
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
