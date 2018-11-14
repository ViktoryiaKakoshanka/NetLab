using System;

namespace VectorProgram.Model
{
    public sealed class Vector
    {
        public double FirstCoordinate { get; private set; }
        public double SecondCoordinate { get; private set; }
        public double ThirdCoordinate { get; private set; }

        public double Length
        {
            get
            {
                return Math.Round(Math.Sqrt(FirstCoordinate * FirstCoordinate + SecondCoordinate * SecondCoordinate + ThirdCoordinate * ThirdCoordinate), 3);
            }
        }

        public Vector(double coordinateFirst, double coordinateSecond, double coordinateThird)
        {
            FirstCoordinate = coordinateFirst;
            SecondCoordinate = coordinateSecond;
            ThirdCoordinate = coordinateThird;
        }

        public Vector() : this(0, 0, 0) { }

        public Vector(Vector vector) : this(vector.FirstCoordinate, vector.SecondCoordinate, vector.ThirdCoordinate) { }

        public override string ToString()
        {
            return $"({FirstCoordinate}, {SecondCoordinate}, {ThirdCoordinate})";
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.FirstCoordinate += vector2.FirstCoordinate;
            result.SecondCoordinate += vector2.SecondCoordinate;
            result.ThirdCoordinate += vector2.ThirdCoordinate;

            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.FirstCoordinate -= vector2.FirstCoordinate;
            result.SecondCoordinate -= vector2.SecondCoordinate;
            result.ThirdCoordinate -= vector2.ThirdCoordinate;

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

        public static Vector operator *(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.FirstCoordinate * vector2.FirstCoordinate, vector1.SecondCoordinate * vector2.SecondCoordinate, vector1.ThirdCoordinate * vector2.ThirdCoordinate);
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            var result = (vector1.FirstCoordinate == vector2.FirstCoordinate && vector1.SecondCoordinate == vector2.SecondCoordinate && vector1.ThirdCoordinate == vector2.ThirdCoordinate);
            return result;
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }

        public double AngleBetweenVectors(Vector vector)
        {
            var dividend = FirstCoordinate * vector.FirstCoordinate + SecondCoordinate * vector.SecondCoordinate + ThirdCoordinate + vector.ThirdCoordinate;
            var divisor1 = Math.Sqrt(FirstCoordinate * FirstCoordinate + SecondCoordinate * SecondCoordinate + ThirdCoordinate * ThirdCoordinate);
            var divisor2 = Math.Sqrt(vector.FirstCoordinate * vector.FirstCoordinate + vector.SecondCoordinate * vector.SecondCoordinate + vector.ThirdCoordinate * vector.ThirdCoordinate);
            return Math.Round(dividend / (divisor1 * divisor2), 3);
        }

        public override bool Equals(object obj)
        {
            return GetType().Equals(obj);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }
    }
}
