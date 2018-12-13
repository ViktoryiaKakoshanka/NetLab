using PolynomialProgram.Model;

namespace PolynomialProgram.View
{
    public interface IView
    {
        string ReadLine(string message);
        void Exit();
        void WriteErrorMessage();
        void ShowSimpleActionsWithPolynomialsResults(
            Polynomial first,
            Polynomial second,
            Polynomial sumPolynomials,
            Polynomial differencePolynomials,
            Polynomial multiplicationPolynomials);

        void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result);
    }
}
