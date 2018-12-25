using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using NewtonsMethod.View;
using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Globalization;
=======
>>>>>>> master

namespace NewtonsMethod
{
    public class Startup
    {
<<<<<<< HEAD
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
=======
        private const int DECIMAL_PLACES = 5;

        private IProgramView _programView;
        private double _radicant, _accuracy;
        private int _degree;

        public Startup(IProgramView programView)
        {
            _programView = programView;
        }

        public void RunProgram()
        {
            Initialize();

            var calculator = new Calculator();
            var rootByNewtonMethod = calculator.CalculateRoot(_degree, _radicant, _accuracy);
            _programView.WriteLine($"Root by Newton's method with accuracy {_accuracy}: {Math.Round(rootByNewtonMethod, DECIMAL_PLACES)}");

            var isValidRoot = calculator.ValidateRoot(rootByNewtonMethod, _degree, _radicant, _accuracy);
            _programView.WriteLine($"Is valid calculated root: {isValidRoot}");

            _programView.WaitForAnyKeyPress();
        }

        private void Initialize()
        {
            RequestRadicant();
            RequestDegree();
            RequestAccuracy();
        }

        private void RequestAccuracy()
        {
            var accuracyString = RequestUserInput(DataType.Аccurancy, "Enter accuracy from 0 to 1");
            _accuracy = DataParser.ParseDouble(accuracyString);
        }
>>>>>>> master

        private void RequestDegree()
        {
            var degreeString = RequestUserInput(DataType.Power, "Enter root degree");
            _degree = DataParser.ParseInt(degreeString);
        }

<<<<<<< HEAD
        private void PrintCompareResult(IRadicalSign radicalSign, double radicalSignMethodNewton, double radicalSignMathPow)
        {
            _view.WriteLine(radicalSign.ToString());
            _view.WriteLine($"Newton's method is {Math.Round(radicalSignMethodNewton, Digits)}");
            _view.WriteLine("Check");
            _view.WriteLine($"{radicalSign.Root} to degree {radicalSign.Power} equally {Math.Round(radicalSignMathPow, Digits)}");
            _view.WaitForAnyKeyPress();
=======
        private void RequestRadicant()
        {
            var radicantString = RequestUserInput(DataType.Numerical, "Enter radicand");
            _radicant = DataParser.ParseDouble(radicantString);
>>>>>>> master
        }

        private string RequestUserInput(DataType dataType, string welcomeMessage)
        {
            var correctInput = false;
            var userInput = string.Empty;

            while (!correctInput)
            {
<<<<<<< HEAD
                userInput = _view.ReadLine(welcomeMessage);
                correctInput = ValidateUserInput(dataType, userInput);
=======
                userInput = _programView.ReadLine(welcomeMessage);
                correctInput = ValidateUserInput(method, userInput);
>>>>>>> master
            }
            return userInput;
        }

        private bool ValidateUserInput(DataType param, string userInput)
        {
            var correctInput = Validator.ValidateInput(userInput, param);
            if (!correctInput) _programView.ShowErrorMessageUserInput();

            return correctInput;
        }
    }
}
