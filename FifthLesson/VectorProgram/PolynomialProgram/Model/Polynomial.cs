using PolynomialProgram.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PolynomialProgram.Model
{
    public class Polynomial : IEquatable<Polynomial>
    {
        public int Power { get; set; }
        public IDictionary<int, double> Monomials { get; }

        public Polynomial(int power, IDictionary<int, double> monomials)
        {
            Power = power;
            Monomials = monomials;
        }
        
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Power == other.Power && Monomials.Keys.All(k => other.Monomials.ContainsKey(k) && Monomials[k].IsEqual(other.Monomials[k]));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Polynomial);
        }

        public override int GetHashCode()
        {
            var firstHashCode = Power.GetHashCode();
            var secondHashCode = Monomials.Aggregate(0, (current, pair) => current ^ (int)pair.Value);

            return unchecked(firstHashCode * 397) ^ secondHashCode;
        }

        public override string ToString()
        {
            return String.Concat(Monomials.Select(GetMonomial).Reverse().ToList());
        }

        public static bool operator ==(Polynomial first, Polynomial second) => first != null && first.Equals(second);

        public static bool operator !=(Polynomial first, Polynomial second) => first != null && !first.Equals(second);

        public static Polynomial operator +(Polynomial first, Polynomial second) => PolynomialHelper.Sum(first, second);

        public static Polynomial operator -(Polynomial first, Polynomial second) => PolynomialHelper.Subtract(first, second);

        public static Polynomial operator *(Polynomial first, Polynomial second) => PolynomialHelper.Multiply(first, second);

        public static Polynomial operator *(Polynomial polynomial, double number) => PolynomialHelper.MultiplyByConstant(polynomial, number);

        public static Polynomial operator *(double number, Polynomial polynomial) => polynomial * number;


        private static string GetMonomial(KeyValuePair<int, double> pair)
        {
            return !pair.Value.IsEqual(0) ? FormatCoefficientForOutput(pair.Value) + FormatPowerForOutput(pair.Key) : String.Empty;
        }

        private static string FormatCoefficientForOutput(double coefficient)
        {
            if (coefficient.IsEqual(1))
            {
                return String.Empty;
            }
            return coefficient < 0 ? coefficient.ToString(CultureInfo.CurrentCulture) : $"+{coefficient}";
        }

        private static string FormatPowerForOutput(int power)
        {
            if (power == 0)
            {
                return String.Empty;
            }
            return power != 1 ? $"x^{power}" : "x";
        }
    }
}
