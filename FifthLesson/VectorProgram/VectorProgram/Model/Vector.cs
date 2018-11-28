using System;

namespace VectorProgram.Model
{
    public class Vector : IEquatable<Vector>
    {
        private int digits = 3;

        public double FirstCoordinate { get; private set; }
        public double SecondCoordinate { get; private set; }
        public double ThirdCoordinate { get; private set; }
        public double Length
        {
            get => Math.Round(Math.Sqrt(Math.Pow(FirstCoordinate, 2) + Math.Pow(SecondCoordinate, 2) + Math.Pow(ThirdCoordinate, 2)), digits);
        }

        public Vector() { }

        public Vector(double firstCoordinate, double secondCoordinate, double thirdCoordinate)
        {
            FirstCoordinate = firstCoordinate;
            SecondCoordinate = secondCoordinate;
            ThirdCoordinate = thirdCoordinate;
        }
        
        public Vector(Vector vector) : this(vector.FirstCoordinate, vector.SecondCoordinate, vector.ThirdCoordinate) { }
                
        public override string ToString() => $"({FirstCoordinate}, {SecondCoordinate}, {ThirdCoordinate})";

        public override int GetHashCode()
        {
            var firstHashCode = FirstCoordinate.GetHashCode();
            var secondHashCode = SecondCoordinate.GetHashCode();
            var thirdHashCode = ThirdCoordinate.GetHashCode();
            
            var result = firstHashCode;
            result = unchecked(result * 397) ^ secondHashCode;
            result = unchecked(result * 397) ^ thirdHashCode;
            
            return result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return (this.GetType() != obj.GetType()) ? false : this.Equals((Vector)obj);
        }
  
        public bool Equals(Vector other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var ValueСomparison = FirstCoordinate == other.FirstCoordinate && SecondCoordinate == other.SecondCoordinate && ThirdCoordinate == other.ThirdCoordinate;
            return ValueСomparison;
        }
        
        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector
            {
                FirstCoordinate = first.FirstCoordinate + second.FirstCoordinate,
                SecondCoordinate = first.SecondCoordinate + second.SecondCoordinate,
                ThirdCoordinate = first.ThirdCoordinate + second.ThirdCoordinate
            };
        }

        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector
            {
                FirstCoordinate = first.FirstCoordinate - second.FirstCoordinate,
                SecondCoordinate = first.SecondCoordinate - second.SecondCoordinate,
                ThirdCoordinate = first.ThirdCoordinate - second.ThirdCoordinate
            };
        }

        public static Vector operator *(double number, Vector vector)
        {
            return new Vector
            {
                FirstCoordinate = vector.FirstCoordinate * number,
                SecondCoordinate = vector.SecondCoordinate * number,
                ThirdCoordinate = vector.ThirdCoordinate * number
            };
        }

        public static Vector operator *(Vector vector, double number)
        {
            return number * vector;
        }
        
        public static bool operator ==(Vector first, Vector second) => first.Equals(second);

        public static bool operator !=(Vector first, Vector second) => !first.Equals(second);
    }
}
