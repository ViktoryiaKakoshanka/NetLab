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

            view.ShowResultsOfPolynomialSum(first, second, sumResult, subtractResult);
        }

        public static void ExecutePolynomialsMultiplication(Polynomial first, Polynomial second, IView view)
        {
            var result = first * second;

            view.ShowResultOfPolynomialsProduct(first, second, result);
        }

        public static void MultiplyPolynomialByConstant(Polynomial polynomial, double multiplier, IView view)
        {
            var result = polynomial * multiplier;

            view.ShowResultOfProductPolynomialByConstant(polynomial, multiplier, result);
        }
    }
}