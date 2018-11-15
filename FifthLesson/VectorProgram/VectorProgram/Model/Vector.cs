using System;
using VectorProgram.Controller;

namespace VectorProgram.Model
{
    public class Vector : IEquatable<Vector>
    {
        public double FirstCoordinate { get; private set; }
        public double SecondCoordinate { get; private set; }
        public double ThirdCoordinate { get; private set; }
        public double Length
        {
            get => Math.Round(Math.Sqrt(Math.Pow(FirstCoordinate, 2) + Math.Pow(SecondCoordinate, 2) + Math.Pow(ThirdCoordinate, 2)), 3);
        }
        
        public Vector(double coordinateFirst, double coordinateSecond, double coordinateThird)
        {
            FirstCoordinate = coordinateFirst;
            SecondCoordinate = coordinateSecond;
            ThirdCoordinate = coordinateThird;
        }
        
        public Vector(Vector vector) : this(vector.FirstCoordinate, vector.SecondCoordinate, vector.ThirdCoordinate) { }

        public double CalculateAngleBetweenVectors(Vector vector)
        {
            var angle = VectorHelper.CalculateAngleBetweenVectors(this, vector);
            return Math.Round(angle, 3);
        }

        public double CalculateModuleVector(Vector vector) => VectorHelper.CalculateModuleVector(vector);
        
        public override string ToString() => $"({FirstCoordinate}, {SecondCoordinate}, {ThirdCoordinate})";

        public override int GetHashCode()
        {
            var hashCodeProperties = new int[]
                {
                    FirstCoordinate.GetHashCode(),
                    SecondCoordinate.GetHashCode(),
                    ThirdCoordinate.GetHashCode()
                };

            var result = hashCodeProperties[0];

            for (int i = 1; i < hashCodeProperties.Length; i++)
            {
                result = unchecked(result * 397) ^ hashCodeProperties[i];
            }

            return result;
        }

        public override bool Equals(object obj) => this.Equals(obj as Vector);
  
        public bool Equals(Vector other)
        {
            if ((object)this == (object)other) return true;
            if ((object)other == null) return false;
            if (GetType() != other.GetType()) return false;
            var ValueСomparison = FirstCoordinate == other.FirstCoordinate && SecondCoordinate == other.SecondCoordinate && ThirdCoordinate == other.ThirdCoordinate;
            return ValueСomparison;
        }

        public static bool Equals(Vector first, Vector second)
        {
            return (first != null) ? first.Equals(second) : (object)first == (object)second;
        }

        public static Vector operator +(Vector first, Vector second)
        {
            first.FirstCoordinate += second.FirstCoordinate;
            first.SecondCoordinate += second.SecondCoordinate;
            first.ThirdCoordinate += second.ThirdCoordinate;

            return first;
        }

        public static Vector operator -(Vector first, Vector second)
        {
            first.FirstCoordinate -= second.FirstCoordinate;
            first.SecondCoordinate -= second.SecondCoordinate;
            first.ThirdCoordinate -= second.ThirdCoordinate;

            return first;
        }

        public static Vector operator *(double numeric, Vector vector)
        {
            vector.FirstCoordinate *= numeric;
            vector.SecondCoordinate *= numeric;
            vector.ThirdCoordinate *= numeric;
            return vector;
        }

        public static Vector operator *(Vector vector, double numeric)
        {
            return numeric * vector;
        }

        public static double operator *(Vector first, Vector second)
        {
            return first.FirstCoordinate * second.FirstCoordinate + first.SecondCoordinate * second.SecondCoordinate + first.ThirdCoordinate * second.ThirdCoordinate;
        }

        public static bool operator ==(Vector first, Vector second) => Equals(first, second);

        public static bool operator !=(Vector first, Vector second) => !Equals(first, second);
  
        public static Vector CalculateVectorMultiplicate(Vector first, Vector second) =>  VectorHelper.CalculateVectorMultiplicate(first, second);
    }
}
