using System;
using PolynomialProgram.Model;
using System.Collections.Generic;
using PolynomialProgram.View;
using PolynomialProgram.Controller;

namespace PolynomialProgram
{
    public class ProgramRunner
    {
        private readonly IView _view;

        public ProgramRunner(IView view)
        {
            _view = view;
        }

        public void Run()
        {
            var firstPolynomial = RequestPolynomial();
            var secondPolynomial = RequestPolynomial();

            _view.ShowPolynomials(firstPolynomial, secondPolynomial);

            ProgramRunnerHelper.PerformSimpleActionsWithPolynomials(firstPolynomial, secondPolynomial, _view);
            var multiplier = RequestMultiplier();
            ProgramRunnerHelper.MultiplyPolynomialByConstant(firstPolynomial, multiplier, _view);

            _view.Exit();
        }
        
        private Polynomial RequestPolynomial()
        {
            var power = RequestPower();
            var monomial = power != 0 ? RequestMonomials(power) : null;

            return new Polynomial(power, monomial);
        }

        private int RequestPower()
        {
            var userInput = RequestInput(DataType.Power, "Enter power:");
            return Convert.ToInt32(userInput);
        }

        private double RequestMultiplier()
        {
            var userInput = RequestInput(DataType.Multiplier, "Enter multiplier:");
            return Convert.ToDouble(userInput);
        }
        
        private IDictionary<int, double> RequestMonomials(int power)
        {
            var resultMonomials = new Dictionary<int, double>();

            for (var i = power; i >= 1; i--)
            {
                var userInput = RequestInput(DataType.Monomial, $"Enter monomial in {i} power:");
                var currentMonomial = DataParser.ParseDouble(userInput);
                
                if ((int)currentMonomial != 0)
                {
                    resultMonomials.Add(i, currentMonomial);
                }
            }

            return resultMonomials;
        }

        private string RequestInput(DataType dataType, string welcomeMessage)
        {
            var userInput = string.Empty;
            var isUserInputCorrect = false;

            while (!isUserInputCorrect)
            {
                userInput = _view.ReadLine(welcomeMessage);
                isUserInputCorrect = ValidateUserInput(dataType, userInput);
            }

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
