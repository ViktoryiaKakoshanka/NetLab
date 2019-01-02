using PolynomialProgram.Model;

namespace PolynomialProgram.View
{
    public interface IView
    {
        string RequestInput(string message);
        void Exit();
        void ShowErrorMessage();
        void ShowResultOfPolynomialsProduct(Polynomial first, Polynomial second, Polynomial result);
        void ShowResultsOfPolynomialSum(
            Polynomial first,
            Polynomial second,
            Polynomial sumResult,
            Polynomial differenceResult);

        void ShowResultOfProductPolynomialByConstant(Polynomial polynomial, double multiplier, Polynomial result);
        void ShowPolynomials(Polynomial first, Polynomial second);
    }
}