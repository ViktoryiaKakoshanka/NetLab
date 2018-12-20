using PolynomialProgram.Model;
using PolynomialProgram.View;

namespace PolynomialProgram
{
    internal static class ProgramRunnerHelper
    {
        public static void PerformSimpleActionsWithPolynomials(Polynomial first, Polynomial second, IView view)
        {
            var sumResult = first + second;
            var subtractResult = first - second;
            var multiplicationResult = first * second;

            view.ShowSimpleActionsWithPolynomialsResults(first, second, sumResult, subtractResult, multiplicationResult);
        }

        public static void MultiplyPolynomialByConstant(Polynomial polynomial, double multiplier, IView view)
        {
            var result = polynomial * multiplier;

            view.ShowMultiplicationNumberByPolynomial(polynomial, multiplier, result);
        }
    }
}