using PolynomialProgram.Model;
using PolynomialProgram.View;
using System.Collections.Generic;
using VectorProgram.Controller;
using VectorProgram.Model;

namespace PolynomialProgram
{
    public class ProgramRun
    {
        private IConsoleView _view;
        private Polynomial[] _polynomials = new Polynomial[2];
        public void Run(IConsoleView view)
        {
            _view = view;

            Initialize();
            ShowInputedPolynomials();

            //CreateAndShowPolynomials();
            var multiplier = GetUserMultiplier();
            ShowResultsSimpleActionsWithPolynomials(multiplier);

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
            ShowInputedPolynomials();
        }

        private void ShowResultsSimpleActionsWithPolynomials(double multiplier)
        {
            _view.WriteLine($"Sum: {GetSumPolynomials()}");
            _view.WriteLine($"Difference: {GetDifferencePolynomials()}");
            _view.WriteLine($"Multiplication polynomials: {GetMultiplicationPolynomials()}");
            _view.WriteLine($"Multiplication first polynomial by : {GetMultiplicationNumberByPolynomial(multiplier)}");
        }
        
        private void CreatePolynomials()
        {
            _polynomials[0] = GetUserPolynomial();
            _polynomials[1] = GetUserPolynomial();
        }

        private void ShowInputedPolynomials()
        {
            _view.WriteLine("Your first polynomial:");
            _view.WriteLine(_polynomials[0].ToString());

            _view.WriteLine("Your second polynomial:");
            _view.WriteLine(_polynomials[1].ToString());
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
            var userInput = RequestUserInput(DataType.Power, "Enter power:");
            return DataParser.ParseToInt(userInput);
        }

        private int GetUserMultiplier()
        {
            var userInput = RequestUserInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseToInt(userInput);
        }
        
        private IDictionary<int, double> GetUserMonomials(int power)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();
            string userInput;
            double currentMonomial;

            for (int i = power; i >= 1; i--)
            {
                userInput = RequestUserInput(DataType.Monomial, $"Enter monomial in {i} power:");
                currentMonomial = DataParser.ParseToDouble(userInput);
                resultMonomials.Add(i, currentMonomial);
            }

            return resultMonomials;
        }

        private string RequestUserInput(DataType dataType, string welcomeMessage)
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
            var isUserInputCorrect = false;
            isUserInputCorrect = Validator.ValidateInput(dataType, userInput);
            if (!isUserInputCorrect) _view.WriteErrorMessage();
            return isUserInputCorrect;
        }

    }
}
