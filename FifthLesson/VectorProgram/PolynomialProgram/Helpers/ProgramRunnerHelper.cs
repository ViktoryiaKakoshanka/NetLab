using PolynomialProgram.Model;
using PolynomialProgram.View;

namespace PolynomialProgram.Helpers
{
    internal static class ProgramRunnerHelper
    {
        public static void PerformSimpleActionsWithPolynomials(Polynomial first, Polynomial second, IView view)
        {
            var sumResult = first + second;
            var subtractResult = first - second;

            view.ShowSimpleActionsWithPolynomialsResults(first, second, sumResult, subtractResult);
        }

        public static void ExecutePolynomialsMultiplication(Polynomial first, Polynomial second, IView view)
        {
            var result = first * second;

            view.ShowResultOfPolynomialsMultiplication(first, second, result);
        }

        public static void MultiplyPolynomialByConstant(Polynomial polynomial, double multiplier, IView view)
        {
            var result = polynomial * multiplier;

            view.ShowMultiplicationNumberByPolynomial(polynomial, multiplier, result);
        }
    }
}