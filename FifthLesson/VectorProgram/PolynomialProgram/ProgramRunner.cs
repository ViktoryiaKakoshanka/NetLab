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
        private readonly IList<Polynomial> _polynomials = new List<Polynomial>();

        public ProgramRunner(IView view)
        {
            _view = view;
        }

        public void Run()
        {
            var firstPolynomial = RequestPolynomial();
            var secondPolynomial = RequestPolynomial();

            ProgramRunnerHelper.CallSimpleActionsWithPolynomials(firstPolynomial, secondPolynomial, _view);
            var multiplier = RequestMultiplier();
            ProgramRunnerHelper.CallMultiplicationNumberByPolynomial(firstPolynomial, multiplier, _view);

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

        private int RequestMultiplier()
        {
            var userInput = RequestInput(DataType.Multiplier, "Enter multiplier:");
            return Convert.ToInt32(userInput);
        }
        
        private IDictionary<int, double> RequestMonomials(int power)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();

            for (var i = power; i >= 1; i--)
            {
                var userInput = RequestInput(DataType.Monomial, $"Enter monomial in {i} power:");
                var currentMonomial = DataParser.ParseDouble(userInput);
                
                if (Convert.ToInt32(currentMonomial) != 0)
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
                _view.WriteErrorMessage();
            }

            return isUserInputCorrect;
        }
    }
}
