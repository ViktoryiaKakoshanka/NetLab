using System;
using PolynomialProgram.Helpers;

namespace VectorProgram.Model
{
    public struct Vector : IEquatable<Vector>
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() => $"({X}, {Y}, {Z})";

        public override int GetHashCode()
        {
            var firstHashCode = X.GetHashCode();
            var secondHashCode = Y.GetHashCode();
            var thirdHashCode = Z.GetHashCode();
            
            var result = firstHashCode;
            result = unchecked(result * 397) ^ secondHashCode;
            result = unchecked(result * 397) ^ thirdHashCode;
            
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return GetType() == obj.GetType() && Equals((Vector)obj);
        }
  
        public bool Equals(Vector other)
        {
            return X.IsEqual(other.X) && Y.IsEqual(other.Y) && Z.IsEqual(other.Z);
        }
        
        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
        }

        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector(first.X - second.X, first.Y - second.Y, first.Z - second.Z);
        }

        public static Vector operator *(double number, Vector vector)
        {
            return new Vector(vector.X * number, vector.Y * number, vector.Z * number);
        }

        public static Vector operator *(Vector vector, double number)
        {
            return number * vector;
        }
        
        public static bool operator ==(Vector first, Vector second) => first.Equals(second);

        public static bool operator !=(Vector first, Vector second) => !first.Equals(second);
    }
}