using PolynomialProgram.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PolynomialProgram.Model
{
    public class Polynomial : IEquatable<Polynomial>
    {
        public int Power { get; }
        public IDictionary<int, double> Monomials { get; }

        public Polynomial(int power, IDictionary<int, double> monomials)
        {
            Power = power;
            Monomials = monomials;
        }

        public Polynomial(Polynomial polynomial) : this(polynomial.Power, polynomial.Monomials) { }

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Power != other.Power)
            {
                return false;
            }

            var result = Monomials.Keys.All(k => other.Monomials.ContainsKey(k) && Monomials[k].IsEquals(other.Monomials[k]));
            return result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return GetType() == obj.GetType() && Equals((Polynomial)obj);
        }

        public override int GetHashCode()
        {
            var firstHashCode = Power.GetHashCode();
            var secondHashCode = Monomials.Sum(x => Convert.ToInt32(x.Value) ^ 397);

            return unchecked(firstHashCode * 397) ^ secondHashCode;
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var key = Power; key >= 0; key--)
            {
                if (Monomials.ContainsKey(key))
                {
                    result += FormatCoefficientForOutput(Monomials[key]) + FormatPowerForOutput(key);
                }
            }
            return result;
        }

        public static bool operator ==(Polynomial first, Polynomial second) => first != null && first.Equals(second);

        public static bool operator !=(Polynomial first, Polynomial second) => first != null && !first.Equals(second);

        public static Polynomial operator +(Polynomial first, Polynomial second) => PolynomialHelper.Sum(first, second);

        public static Polynomial operator -(Polynomial first, Polynomial second) => PolynomialHelper.Subtract(first, second);

        public static Polynomial operator *(Polynomial first, Polynomial second) => PolynomialHelper.Multiply(first, second);

        public static Polynomial operator *(Polynomial polynomial, double number) => PolynomialHelper.MultiplyByConstant(polynomial, number);

        public static Polynomial operator *(double number, Polynomial polynomial) => polynomial * number;
        
        private static string FormatCoefficientForOutput(double coefficient)
        {
            if (coefficient.IsEquals(1))
            {
                return string.Empty;
            }
            return coefficient < 0 ? coefficient.ToString(CultureInfo.CurrentCulture) : $"+{coefficient}";
        }

        private static string FormatPowerForOutput(int value)
        {
            if (value == 0)
            {
                return string.Empty;
            }
            return value != 1 ? $"x^{value}" : string.Empty;
        }

        
    }
}
