using PolynomialProgram.Model;
using System.Collections.Generic;
using VectorProgram.Controller;
using VectorProgram.Model;
using VectorProgram.View;
using VectorProgram.UserInput;
using ViewFormattedOutput = PolynomialProgram.View.FormattedOutput;

namespace PolynomialProgram
{
    public class ProgramRun
    {
        private IConsoleView _view;
        private IUserInputProcessor _userInput;
        private ViewFormattedOutput _formattedOutput;
        private List<Polynomial> _polynomials = new List<Polynomial>();

        public void Run(IConsoleView view)
        {
            _view = view;
            _userInput = new UserInputProcessor(_view);
            _formattedOutput = new ViewFormattedOutput(_view);

            InitializeDefaultPolinomials();
            _formattedOutput.ShowInputedPolynomials(_polynomials);

            //CallPolynomials();
            var multiplier = RequestMultiplier();
            CallSimpleActionsWithPolynomials(multiplier);

            _view.WaitForAnyKeyPress();
        }

        private void InitializeDefaultPolinomials()
        {
            var monomialsFirst = new Dictionary<int, double>()
            {
                {0, -5},
                {1, 0},
                {2, 3},
            };

            var monomialsSecond = new Dictionary<int, double>()
            {
                {0, 4},
                {1, 0},
                {2, -3},
                {3, 0},
                {4, 0},
                {5, -0.5},
            };

            _polynomials.Add(new Polynomial(2, monomialsFirst));
            _polynomials.Add(new Polynomial(2, monomialsSecond));
        }

        private void CallPolynomials()
        {
            CreatePolynomials();
            _formattedOutput.ShowInputedPolynomials(_polynomials);
        }

        private void CallSimpleActionsWithPolynomials(double multiplier)
        {
            var sumResult = GetSumPolynomials();
            var differenceResult = GetDifferencePolynomials();
            var multiplicationPolynomialsResult = GetMultiplicationPolynomials();
            
            _formattedOutput.ShowSimpleActionsWithPolynomialsResults(_polynomials, sumResult, differenceResult, multiplicationPolynomialsResult);
        }

        private void CallMultiplicationNumberByPolynomial(double multiplier)
        {
            var result = _polynomials[0] * multiplier;

            _formattedOutput.ShowMultiplicationNumberByPolynomial(_polynomials[0], multiplier, result);
        }

        private void CreatePolynomials()
        {
            _polynomials.Add(RequestPolynomial());
            _polynomials.Add(RequestPolynomial());
        }
        
        private Polynomial GetSumPolynomials() => _polynomials[0] + _polynomials[1];

        private Polynomial GetDifferencePolynomials() => _polynomials[0] - _polynomials[1];

        private Polynomial GetMultiplicationPolynomials() => _polynomials[0] * _polynomials[1];
        
        private Polynomial RequestPolynomial()
        {
            var power = RequestPower();
            var monomials = (power != 0) ? RequestMonomials(power) : null;

            return new Polynomial(power, monomials);
        }

        private int RequestPower()
        {
            var userInput = _userInput.RequestInput(DataType.Power, "Enter power:");
            return DataParser.ParseInt(userInput);
        }

        private int RequestMultiplier()
        {
            var userInput = _userInput.RequestInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseInt(userInput);
        }
        
        private IDictionary<int, double> RequestMonomials(int power)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();
            string userInput;
            double currentMonomial;

            for (int i = power; i >= 1; i--)
            {
                userInput = _userInput.RequestInput(DataType.Monomial, $"Enter monomial in {i} power:");
                currentMonomial = DataParser.ParseDouble(userInput);
                resultMonomials.Add(i, currentMonomial);
            }

            return resultMonomials;
        }

    }
}
