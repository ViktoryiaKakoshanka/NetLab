using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using NewtonsMethod.View;
using System;

namespace NewtonsMethod
{
    public class Startup
    {
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

        private void RequestDegree()
        {
            var degreeString = RequestUserInput(DataType.Power, "Enter root degree");
            _degree = DataParser.ParseInt(degreeString);
        }

        private void RequestRadicant()
        {
            var radicantString = RequestUserInput(DataType.Numerical, "Enter radicand");
            _radicant = DataParser.ParseDouble(radicantString);
        }

        private string RequestUserInput(DataType method, string welcomeMessage)
        {
            var correctInput = false;
            var userInput = string.Empty;

            while (!correctInput)
            {
                userInput = _programView.ReadLine(welcomeMessage);
                correctInput = ValidateUserInput(method, userInput);
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
