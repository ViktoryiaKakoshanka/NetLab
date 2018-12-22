using PolynomialProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolynomialProgram.Helpers
{
    public static class PolynomialHelper
    {
        public static Polynomial Sum(Polynomial first, Polynomial second)
        {
            return CallPolynomialSum(first, second, (a, b) => a + b);
        }

        public static Polynomial Subtract(Polynomial first, Polynomial second)
        {
            return CallPolynomialSum(first, second, (a, b) => a - b);
        }

        public static Polynomial Multiply(Polynomial first, Polynomial second)
        {
            var resultMonomials = new Dictionary<int, double>();
            var resultMaxPower = first.Power + second.Power;

            foreach (var firstMonomial in first.Monomials)
            {
                foreach (var secondMonomial in second.Monomials)
                {
                    var currentValue = firstMonomial.Value * secondMonomial.Value;
                    var currentPower = firstMonomial.Key + secondMonomial.Key;

                    if (resultMonomials.ContainsKey(currentPower))
                    {
                        resultMonomials[currentPower] += currentValue;
                    }
                    else
                    {
                        resultMonomials.Add(currentPower, currentValue);
                    }
                }
            }

            resultMonomials = resultMonomials.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            return new Polynomial(resultMaxPower, resultMonomials);
        }

        public static Polynomial MultiplyByConstant(Polynomial polynomial, double number)
        {
            var monomials = polynomial.Monomials.ToDictionary(pair => pair.Key, pair => pair.Value * number);
            return new Polynomial(polynomial.Power, monomials);
        }
        
        private static double GetCoefficient(Polynomial first, int i)
        {
            return first.Monomials.ContainsKey(i) ? first.Monomials[i] : 0D;
        }

        private static Polynomial CallPolynomialSum(Polynomial first, Polynomial second, Func<double, double, double> sum)
        {
            var maxPower = Math.Max(first.Power, second.Power);
            var monomials = Enumerable.Range(0, maxPower + 1).ToDictionary(x => x, x => sum(GetCoefficient(first, x), GetCoefficient(second, x)));
            
            return new Polynomial(maxPower, monomials).CorrectPolynomial();
        }
    }
}