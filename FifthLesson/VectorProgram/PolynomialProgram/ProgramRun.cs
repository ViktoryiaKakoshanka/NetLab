using PolynomialProgram.Model;
using System.Collections.Generic;
using VectorProgram.Controller;
using VectorProgram.Model;
using VectorProgram.View;
using VectorProgram.UserInput;

namespace PolynomialProgram
{
    public class ProgramRun
    {
        private IConsoleView _view;
        private IUserInputProcessor _userInput;
        private View.FormattedOutput _formattedOutput;
        private List<Polynomial> _polynomials = new List<Polynomial>();

        public void Run(IConsoleView view)
        {
            _view = view;
            _userInput = new ProcessingUserInput(_view);
            _formattedOutput = new View.FormattedOutput(_view);

            InitializeDefaultPolinomials();
            _formattedOutput.ShowInputedPolynomials(_polynomials);

            //CallPolynomials();
            var multiplier = RequestUserMultiplier();
            CallSimpleActionsWithPolynomials(multiplier);

            _view.PressKeyToContinue();
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
            _polynomials.Add(RequestUserPolynomial());
            _polynomials.Add(RequestUserPolynomial());
        }
        
        private Polynomial GetSumPolynomials() => _polynomials[0] + _polynomials[1];

        private Polynomial GetDifferencePolynomials() => _polynomials[0] - _polynomials[1];

        private Polynomial GetMultiplicationPolynomials() => _polynomials[0] * _polynomials[1];
        
        private Polynomial RequestUserPolynomial()
        {
            var power = RequestUserPower();
            var monomials = (power != 0) ? RequestUserMonomials(power) : null;

            return new Polynomial(power, monomials);
        }

        private int RequestUserPower()
        {
            var userInput = _userInput.RequestUserInput(DataType.Power, "Enter power:");
            return DataParser.ParseInt(userInput);
        }

        private int RequestUserMultiplier()
        {
            var userInput = _userInput.RequestUserInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseInt(userInput);
        }
        
        private IDictionary<int, double> RequestUserMonomials(int power)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();
            string userInput;
            double currentMonomial;

            for (int i = power; i >= 1; i--)
            {
                userInput = _userInput.RequestUserInput(DataType.Monomial, $"Enter monomial in {i} power:");
                currentMonomial = DataParser.ParseDouble(userInput);
                resultMonomials.Add(i, currentMonomial);
            }

            return resultMonomials;
        }

    }
}
