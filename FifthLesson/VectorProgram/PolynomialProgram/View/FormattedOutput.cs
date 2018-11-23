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

        public void ShowInputedPolynomials(IList<Polynomial> initialPolynomials)
        {
            _view.WriteLine("Your first polynomial:");
            _view.WriteLine(initialPolynomials[0].ToString());

            _view.WriteLine("Your second polynomial:");
            _view.WriteLine(initialPolynomials[1].ToString());
        }

        public void ShowSimpleActionsWithPolynomialsResults(
            IList<Polynomial> initialPolynomials,
            Polynomial sumPolynomials, 
            Polynomial differencePolynomials, 
            Polynomial multiplicationPolynomials)
        {
            _view.WriteLine($"{initialPolynomials[0]} + {initialPolynomials[1]} = {sumPolynomials}");
            _view.WriteLine($"{initialPolynomials[0]} - {initialPolynomials[1]} = {differencePolynomials}");
            _view.WriteLine($"{initialPolynomials[0]} * {initialPolynomials[1]} = {multiplicationPolynomials}");
        }

        public void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result)
        {
            _view.WriteLine($"{polynomial} * {multiplier} = {result}");
        }
    }
}
