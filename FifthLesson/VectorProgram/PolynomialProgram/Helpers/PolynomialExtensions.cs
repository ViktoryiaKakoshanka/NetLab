using System.Linq;
using PolynomialProgram.Model;

namespace PolynomialProgram.Helpers
{
    public static class PolynomialExtensions
    {

        public static Polynomial CorrectPolynomial(this Polynomial polynomial)
        {
            foreach (var keyValuePair in polynomial.Monomials.OrderByDescending(x => x.Key))
            {
                if (!keyValuePair.Value.IsEqual(0))
                {
                    break;
                }
                polynomial.Monomials.Remove(keyValuePair);
                polynomial.Power--;
            }

            return new Polynomial(polynomial.Power, polynomial.Monomials);
        }
    }
}
