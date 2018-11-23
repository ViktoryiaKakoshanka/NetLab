﻿using System;
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

        public Vector() { }

        public Vector(double coordinateFirst, double coordinateSecond, double coordinateThird)
        {
            FirstCoordinate = coordinateFirst;
            SecondCoordinate = coordinateSecond;
            ThirdCoordinate = coordinateThird;
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

        public static Vector operator *(double numeric, Vector vector)
        {
            return new Vector
            {
                FirstCoordinate = vector.FirstCoordinate * numeric,
                SecondCoordinate = vector.SecondCoordinate * numeric,
                ThirdCoordinate = vector.ThirdCoordinate * numeric
            };
        }

        public static Vector operator *(Vector vector, double numeric)
        {
            return numeric * vector;
        }
        
        public static bool operator ==(Vector first, Vector second) => first.Equals(second);

        public static bool operator !=(Vector first, Vector second) => !first.Equals(second);
    }
}
