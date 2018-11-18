using PolynomialProgram.Comtroller;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolynomialProgram.Model
{
    public class Polynomial : IEquatable<Polynomial>
    {
        public int Power { get; set; }
        public IDictionary<int, double> Monomials { get; set; }

        public Polynomial(int power, IDictionary<int, double> monomials)
        {
            Power = power;
            Monomials = monomials;
        }

        public Polynomial(Polynomial polynomial) : this(polynomial.Power, polynomial.Monomials) { }

        public override string ToString()
        {
            var result = string.Empty;
            for (int key = Power; key >= 0; key--)
            {
                if (Monomials[key] == 0) continue;
                result += FormatedValues(Monomials[key]) + FormatedPowerForOutput(key);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return (this.GetType() != obj.GetType()) ? false : this.Equals((Polynomial)obj);
        }

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Power != other.Power) return false;
            var result = Monomials.Keys.All(k => other.Monomials.ContainsKey(k) && object.Equals(Monomials[k], other.Monomials[k]));
            return true;
        }

        public override int GetHashCode()
        {
            var firstHashCode = Power.GetHashCode();
            var secondHashCode = Monomials.Sum(x => x.Value).GetHashCode();

            var result = unchecked(firstHashCode * 397) ^ secondHashCode;
            return result;
        }

        public static bool operator ==(Polynomial first, Polynomial second) => Equals(first, second);

        public static bool operator !=(Polynomial first, Polynomial second) => !Equals(first, second);

        public static Polynomial operator +(Polynomial first, Polynomial second) => PolynomialHelper.CalculateSumPolynomials(first, second);

        public static Polynomial operator -(Polynomial first, Polynomial second) => PolynomialHelper.CalculateDifferencePolynomials(first, second);

        public static Polynomial operator *(Polynomial first, Polynomial second) => PolynomialHelper.CalculateMultiplicationPolynomials(first, second);

        public static Polynomial operator *(Polynomial polynomial, double number) => PolynomialHelper.MultiplyNumberByPolynomial(polynomial, number);

        public static Polynomial operator *(double number, Polynomial polynomial) => polynomial * number;

        private string FormatedValues(double value)
        {
            if (value == 1) return string.Empty;
            return (value < 0) ? value.ToString() : $"+{value}";
        }

        private string FormatedPowerForOutput(int value)
        {
            if (value == 0) return string.Empty;
            return (value != 1) ? $"x^{value}" : string.Empty;
        }


    }
}
