using System;
using VectorProgram.Controller;

namespace VectorProgram.Model
{
    public class Vector : IEquatable<Vector>
    {
        #region Properties
        public double FirstCoordinate { get; private set; }
        public double SecondCoordinate { get; private set; }
        public double ThirdCoordinate { get; private set; }
        public double Length
        {
            get
            {
                return Math.Round(Math.Sqrt(Math.Pow(FirstCoordinate, 2) + Math.Pow(SecondCoordinate, 2) + Math.Pow(ThirdCoordinate, 2)), 3);
            }
        }
        #endregion

        #region Construcrots
        public Vector(double coordinateFirst, double coordinateSecond, double coordinateThird)
        {
            FirstCoordinate = coordinateFirst;
            SecondCoordinate = coordinateSecond;
            ThirdCoordinate = coordinateThird;
        }

        public Vector() : this(0, 0, 0) { }

        public Vector(Vector vector) : this(vector.FirstCoordinate, vector.SecondCoordinate, vector.ThirdCoordinate) { }
        #endregion

        #region override ToString() GetHashCode() Equals() 
        public override string ToString()
        {
            return $"({FirstCoordinate}, {SecondCoordinate}, {ThirdCoordinate})";
        }

        public override int GetHashCode() => GetHashCodeHelper(
               new int[]
               {
                   FirstCoordinate.GetHashCode(),
                   SecondCoordinate.GetHashCode(),
                   ThirdCoordinate.GetHashCode()
               }
            );

        public override bool Equals(object obj) => this.Equals((Vector)obj);
        #endregion

        #region operators + - * == !=
        public static Vector operator +(Vector first, Vector second)
        {
            var result = new Vector(first);

            result.FirstCoordinate += second.FirstCoordinate;
            result.SecondCoordinate += second.SecondCoordinate;
            result.ThirdCoordinate += second.ThirdCoordinate;

            return result;
        }

        public static Vector operator -(Vector first, Vector second)
        {
            var result = new Vector(first);

            result.FirstCoordinate -= second.FirstCoordinate;
            result.SecondCoordinate -= second.SecondCoordinate;
            result.ThirdCoordinate -= second.ThirdCoordinate;

            return result;
        }

        public static Vector operator *(double numeric, Vector vector)
        {
            return new Vector(vector.FirstCoordinate * numeric, vector.SecondCoordinate * numeric, vector.ThirdCoordinate * numeric);
        }

        public static Vector operator *(Vector vector, double numeric)
        {
            return numeric * vector;
        }

        public static Vector operator *(Vector first, Vector second)
        {
            return new Vector(first.FirstCoordinate * second.FirstCoordinate, first.SecondCoordinate * second.SecondCoordinate, first.ThirdCoordinate * second.ThirdCoordinate);
        }

        public static bool operator ==(Vector first, Vector second) => Equals(first, second);

        public static bool operator !=(Vector first, Vector second) => !Equals(first, second);
        #endregion

        public virtual bool Equals(Vector other)
        {
            if ((object)this == (object)other) return true;
            if ((object)other == null) return false;
            if (GetType() != other.GetType()) return false;
            return EqualsHelper(this, other);
        }

        public static bool Equals(Vector first, Vector second) => first?.Equals(second) ?? (object)first == (object)second;

        public double AngleBetweenVectors(Vector vector)
        {
            var angle = VectorHelper.AngleBetweenVectors(this, vector);
            return Math.Round(angle, 3);
        }

        public static string VectorMultiplicate(Vector first, Vector second)
        {
            return VectorHelper.VectorMultiplicate(first, second);
        }

        protected static int GetHashCodeHelper(int[] hashCodeProperties)
        {
            if ((object)hashCodeProperties == null || hashCodeProperties.Length == 0) return 0;

            var result = hashCodeProperties[0];

            for (int i = 1; i < hashCodeProperties.Length; i++)
            {
                result = unchecked(result * 397) ^ hashCodeProperties[i];
            }

            return result;
        }

        protected static bool EqualsHelper(Vector first, Vector second) =>
            first.FirstCoordinate == second.FirstCoordinate &&
            first.SecondCoordinate == second.SecondCoordinate &&
            first.ThirdCoordinate == second.ThirdCoordinate;


    }
}
