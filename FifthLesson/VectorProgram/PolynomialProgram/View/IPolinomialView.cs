using PolynomialProgram.Model;
using System.Collections.Generic;

namespace PolynomialProgram.View
{
    public interface IPolinomialView
    {
        void ShowPolynomials(IList<Polynomial> initialPolynomials);

        void ShowSimpleActionsWithPolynomialsResults(
            Polynomial first,
            Polynomial second,
            Polynomial sumPolynomials,
            Polynomial differencePolynomials,
            Polynomial multiplicationPolynomials);

        void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result);
    }
}
