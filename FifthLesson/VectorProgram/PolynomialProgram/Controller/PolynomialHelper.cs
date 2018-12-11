using PolynomialProgram.Model;
using System;
using System.Collections.Generic;

namespace PolynomialProgram.Controller
{
    public static class PolynomialHelper
    {
        public static Polynomial CalculateSumPolynomials(Polynomial first, Polynomial second)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();

            var maxPower = Math.Max(first.Power, second.Power);

            for (int i = 0; i <= maxPower; i++)
            {
                var firstMonomial = (first.Monomials.ContainsKey(i)) ? first.Monomials[i] : 0;
                var secondMonomial = (second.Monomials.ContainsKey(i)) ? second.Monomials[i] : 0;
                var sumMonomials = firstMonomial + secondMonomial;

                resultMonomials.Add(i, sumMonomials);
            }
            return new Polynomial(maxPower, resultMonomials);
        }

        public static Polynomial CalculateDifferencePolynomials(Polynomial first, Polynomial second)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();

            var maxPower = Math.Max(first.Power, second.Power);

            for (int i = 0; i <= maxPower; i++)
            {
                var firstValue = (first.Monomials.ContainsKey(i)) ? first.Monomials[i] : 0;
                var secondValue = (second.Monomials.ContainsKey(i)) ? second.Monomials[i] : 0;
                var differenceMonomial = firstValue - secondValue;

                resultMonomials.Add(i, differenceMonomial);
            }
            return new Polynomial(maxPower, resultMonomials);
        }

        public static Polynomial CalculateMultiplicationPolynomials(Polynomial first, Polynomial second)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();
            var resultPower = first.Power + second.Power;
            var maxPower = Math.Max(first.Power, second.Power);

            for (int i = 0; i <= maxPower; i++)
            {
                var firstValue = (first.Monomials.ContainsKey(i)) ? first.Monomials[i] : 0;
                for (int j = 0; j <= maxPower; j++)
                {
                    var secondtValue = (second.Monomials.ContainsKey(j)) ? second.Monomials[j] : 0;
                    var currentValue = firstValue * secondtValue;
                    var currentPower = i + j;

                    if (resultMonomials.ContainsKey(currentPower))
                        resultMonomials[currentPower] += currentValue;
                    else
                        resultMonomials.Add(currentPower, currentValue);
                }
            }

            return new Polynomial(resultPower, resultMonomials);
        }

        public static Polynomial MultiplyNumberByPolynomial(Polynomial polynomial, double number)
        {
            var resultPolynomial = new Polynomial(polynomial);

            for (int key = 0; key <= polynomial.Power; key++)
            {
                polynomial.Monomials[key] *= number;
            }

            return resultPolynomial;
        }
    }
}
