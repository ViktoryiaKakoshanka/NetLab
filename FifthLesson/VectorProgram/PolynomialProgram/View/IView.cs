using PolynomialProgram.Model;

namespace PolynomialProgram.View
{
    public interface IView
    {
        string ReadLine(string message);
        void Exit();
        void ShowErrorMessage();
        void ShowSimpleActionsWithPolynomialsResults(
            Polynomial first,
            Polynomial second,
            Polynomial sumResult,
            Polynomial differenceResult,
            Polynomial multiplicationResult);

        void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result);
        void ShowPolynomials(Polynomial first, Polynomial second);
    }
}
