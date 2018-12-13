using PolynomialProgram.Model;
using PolynomialProgram.View;

namespace PolynomialProgram
{
    internal static class ProgramRunnerHelper
    {

        public static void CallSimpleActionsWithPolynomials(Polynomial first, Polynomial second, IView view)
        {
            var sumPolynomials = first + second;
            var differencePolynomials = first - second;
            var multiplicationPolynomials = first * second;

            view.ShowSimpleActionsWithPolynomialsResults(first, second, sumPolynomials, differencePolynomials, multiplicationPolynomials);
        }

        public static void CallMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, IView view)
        {
            var result = polynomial * multiplier;

            view.ShowMultiplicationNumberByPolynomial(polynomial, multiplier, result);
        }
    }
}
