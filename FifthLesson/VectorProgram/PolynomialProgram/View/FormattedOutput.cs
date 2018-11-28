using PolynomialProgram.Model;
using System.Collections.Generic;
using VectorProgram.View;

namespace PolynomialProgram.View
{
    public class FormattedOutput
    {
        private IConsoleView _view;

        public FormattedOutput(IConsoleView view)
        {
            _view = view;
        }

        public void ShowPolynomials(IList<Polynomial> initialPolynomials)
        {
            _view.WriteLine("Your polynomials:");

            foreach (var polynomial in initialPolynomials)
            {
                _view.WriteLine(polynomial.ToString());
            }
        }

        public void ShowSimpleActionsWithPolynomialsResults(
            Polynomial first,
            Polynomial second,
            Polynomial sumPolynomials, 
            Polynomial differencePolynomials, 
            Polynomial multiplicationPolynomials)
        {
            _view.WriteLine($"{first} + {second} = {sumPolynomials}");
            _view.WriteLine($"{first} - {second} = {differencePolynomials}");
            _view.WriteLine($"{first} * {second} = {multiplicationPolynomials}");
        }

        public void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result)
        {
            _view.WriteLine($"{polynomial} * {multiplier} = {result}");
        }
    }
}
