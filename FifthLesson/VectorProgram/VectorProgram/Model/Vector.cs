using System;
using PolynomialProgram.Controller;

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

        public Vector(Vector vector) : this(vector.X, vector.Y, vector.Z)
        {
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

        public static double CalculateAngle(Vector first, Vector second)
        {
            var scalarProduct = CalculateScalarProduct(first, second);
            var firstModule = CalculateModule(first);
            var secondModule = CalculateModule(second);

            return scalarProduct / (firstModule * secondModule);
        }

        public static Vector CalculateVectorProduct(Vector first, Vector second)
        {
            var arrayOfOrts = CreateArrayOfOrts(first, second);

            var determinantOne = CalculateDeterminant(arrayOfOrts[0]);
            var determinantTwo = CalculateDeterminant(arrayOfOrts[1]);
            var determinantThree = CalculateDeterminant(arrayOfOrts[2]);

            return new Vector(determinantOne, determinantTwo, determinantThree);
        }

        public static double CalculateScalarProduct(Vector first, Vector second)
        {
            return first.X * second.X + first.Y * second.Y + first.Z * second.Z;
        }

        private static double CalculateModule(Vector vector)
        {
            var result = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
            return Math.Abs(result);
        }

        private static double[][,] CreateArrayOfOrts(Vector first, Vector second)
        {
            var arrayOfOrts = new[]
            {
                new[,]
                {
                    { first.Y, first.Z },
                    { second.Y, second.Z },
                },
                new[,]
                {
                    { first.X, first.Z },
                    { second.X, second.Z }
                },
                new[,]
                {
                    { first.X, first.Y },
                    { second.X, second.Y }
                }
            };
            return arrayOfOrts;
        }

        private static double CalculateDeterminant(double[,] array)
        {
            return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
        }

    }
}