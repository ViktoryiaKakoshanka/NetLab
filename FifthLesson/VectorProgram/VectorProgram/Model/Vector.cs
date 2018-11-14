using System;

namespace VectorProgram.Model
{
    public sealed class Vector
    {
        public double CoordinateFirst { get; private set; }
        public double CoordinateSecond { get; private set; }
        public double CoordinateThird { get; private set; }

        public double Length
        {
            get
            {
                return Math.Round(Math.Sqrt(CoordinateFirst * CoordinateFirst + CoordinateSecond * CoordinateSecond + CoordinateThird * CoordinateThird), 3);
            }
        }

        public Vector()
        {
            CoordinateFirst = 0;
            CoordinateSecond = 0;
            CoordinateThird = 0;
        }

        public Vector(double coordinateFirst, double coordinateSecond, double coordinateThird) : this()
        {
            CoordinateFirst = coordinateFirst;
            CoordinateSecond = coordinateSecond;
            CoordinateThird = coordinateThird;
        }

        public Vector(Vector vector) : this()
        {
            CoordinateFirst = vector.CoordinateFirst;
            CoordinateSecond = vector.CoordinateSecond;
            CoordinateThird = vector.CoordinateThird;
        }

        public override string ToString()
        {
            return $"({CoordinateFirst}, {CoordinateSecond}, {CoordinateThird})";
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.CoordinateFirst += vector2.CoordinateFirst;
            result.CoordinateSecond += vector2.CoordinateSecond;
            result.CoordinateThird += vector2.CoordinateThird;

            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.CoordinateFirst -= vector2.CoordinateFirst;
            result.CoordinateSecond -= vector2.CoordinateSecond;
            result.CoordinateThird -= vector2.CoordinateThird;

            return result;
        }

        public static Vector operator *(double numeric, Vector vector)
        {
            return new Vector(vector.CoordinateFirst * numeric, vector.CoordinateSecond * numeric, vector.CoordinateThird * numeric);
        }

        public static Vector operator *(Vector vector, double numeric)
        {
            return numeric * vector;
        }

        public static Vector operator *(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.CoordinateFirst * vector2.CoordinateFirst, vector1.CoordinateSecond * vector2.CoordinateSecond, vector1.CoordinateThird * vector2.CoordinateThird);
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            var result = (vector1.CoordinateFirst == vector2.CoordinateFirst && vector1.CoordinateSecond == vector2.CoordinateSecond && vector1.CoordinateThird == vector2.CoordinateThird);
            return result;
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }

        public double AngleBetweenVectors(Vector vector)
        {
            var dividend = CoordinateFirst * vector.CoordinateFirst + CoordinateSecond * vector.CoordinateSecond + CoordinateThird + vector.CoordinateThird;
            var divisor1 = Math.Sqrt(CoordinateFirst * CoordinateFirst + CoordinateSecond * CoordinateSecond + CoordinateThird * CoordinateThird);
            var divisor2 = Math.Sqrt(vector.CoordinateFirst * vector.CoordinateFirst + vector.CoordinateSecond * vector.CoordinateSecond + vector.CoordinateThird * vector.CoordinateThird);
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
