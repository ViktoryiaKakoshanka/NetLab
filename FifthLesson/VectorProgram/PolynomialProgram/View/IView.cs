using PolynomialProgram.Model;

namespace PolynomialProgram.View
{
    public interface IView
    {
        string RequestInput(string message);
        void Exit();
        void ShowErrorMessage();
        void ShowResultOfPolynomialsMultiplication(Polynomial first, Polynomial second, Polynomial result);
        void ShowSimpleActionsWithPolynomialsResults(
            Polynomial first,
            Polynomial second,
            Polynomial sumResult,
            Polynomial differenceResult);

        void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result);
        void ShowPolynomials(Polynomial first, Polynomial second);
    }
}