using PolynomialProgram.Model;
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

        public void ShowInputedPolynomials(Polynomial first, Polynomial second)
        {
            _view.WriteLine("Your first polynomial:");
            _view.WriteLine(first.ToString());

            _view.WriteLine("Your second polynomial:");
            _view.WriteLine(second.ToString());
        }

        public void ShowSimpleActionsWithPolynomialsResults(
            Polynomial sumPolynomials, 
            Polynomial differencePolynomials, 
            Polynomial multiplicationPolynomials, 
            Polynomial multiplicationNumberByPolynomial)
        {
            _view.WriteLine($"Sum: {sumPolynomials}");
            _view.WriteLine($"Difference: {differencePolynomials}");
            _view.WriteLine($"Multiplication polynomials: {multiplicationPolynomials}");
            _view.WriteLine($"Multiplication first polynomial by : {multiplicationNumberByPolynomial}");
        }
    }
}
