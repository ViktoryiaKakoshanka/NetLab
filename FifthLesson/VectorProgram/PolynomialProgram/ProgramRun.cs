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
        private IProcessingUserInput _userInput;
        private View.FormattedOutput _formattedOutput;
        private Polynomial[] _polynomials = new Polynomial[2];

        public void Run(IConsoleView view)
        {
            _view = view;
            _userInput = new ProcessingUserInput(_view);
            _formattedOutput = new View.FormattedOutput(_view);

            Initialize();
            _formattedOutput.ShowInputedPolynomials(_polynomials[0], _polynomials[1]);

            //CreateAndShowPolynomials();
            var multiplier = GetUserMultiplier();
            SimpleActionsWithPolynomials(multiplier);

            _view.ReadKey();
        }

        private void Initialize()
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

            _polynomials[0] = new Polynomial(2, monomialsFirst);
            _polynomials[1] = new Polynomial(5, monomialsSecond);
        }

        private void CreateAndShowPolynomials()
        {
            CreatePolynomials();
            _formattedOutput.ShowInputedPolynomials(_polynomials[0], _polynomials[1]);
        }

        private void SimpleActionsWithPolynomials(double multiplier)
        {
            var sumResult = GetSumPolynomials();
            var differenceResult = GetDifferencePolynomials();
            var multiplicationPolynomialsResult = GetMultiplicationPolynomials();
            var multiplicationNumberByPolynomialResult = GetMultiplicationNumberByPolynomial(multiplier);
            
            _formattedOutput.ShowSimpleActionsWithPolynomialsResults(sumResult, differenceResult, multiplicationPolynomialsResult, multiplicationNumberByPolynomialResult);
        }
        
        private void CreatePolynomials()
        {
            _polynomials[0] = GetUserPolynomial();
            _polynomials[1] = GetUserPolynomial();
        }
        
        private Polynomial GetSumPolynomials() => _polynomials[0] + _polynomials[1];

        private Polynomial GetDifferencePolynomials() => _polynomials[0] - _polynomials[1];

        private Polynomial GetMultiplicationPolynomials() => _polynomials[0] * _polynomials[1];

        private Polynomial GetMultiplicationNumberByPolynomial(double multiplier) => _polynomials[0] * multiplier;

        private Polynomial GetUserPolynomial()
        {
            var power = GetUserPower();
            var monomials = (power != 0) ? GetUserMonomials(power) : null;

            return new Polynomial(power, monomials);
        }

        private int GetUserPower()
        {
            var userInput = _userInput.RequestUserInput(DataType.Power, "Enter power:");
            return DataParser.ParseToInt(userInput);
        }

        private int GetUserMultiplier()
        {
            var userInput = _userInput.RequestUserInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseToInt(userInput);
        }
        
        private IDictionary<int, double> GetUserMonomials(int power)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();
            string userInput;
            double currentMonomial;

            for (int i = power; i >= 1; i--)
            {
                userInput = _userInput.RequestUserInput(DataType.Monomial, $"Enter monomial in {i} power:");
                currentMonomial = DataParser.ParseToDouble(userInput);
                resultMonomials.Add(i, currentMonomial);
            }

            return resultMonomials;
        }

    }
}
