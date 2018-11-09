using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorProgram.Model
{
    public sealed class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public double Length
        {
            get
            {
                return Math.Round(Math.Sqrt(X * X + Y * Y + Z * Z), 3);
            }
        }
        
        public  Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector(double x, double y, double z): this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Vector vector) : this()
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.X += vector2.X;
            result.Y += vector2.Y;
            result.Z += vector2.Z;

            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.X -= vector2.X;
            result.Y -= vector2.Y;
            result.Z -= vector2.Z;

            return result;
        }

        public static Vector operator *(double numeric, Vector vector)
        {
            return new Vector(vector.X * numeric, vector.Y * numeric, vector.Z * numeric);
        }

        public static Vector operator *(Vector vector, double numeric)
        {
            return numeric * vector;
        }

        public static Vector operator *(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X * vector2.X, vector1.Y * vector2.Y, vector1.Z * vector2.Z);
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            var result = (vector1.X == vector2.X && vector1.Y == vector2.Y && vector1.Z == vector2.Z);
            return result;
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }

        public double AngleBetweenVectors(Vector vector)
        {
            var dividend = X * vector.X + Y * vector.Y + Z + vector.Z;
            var divisor1 = Math.Sqrt(X * X + Y * Y + Z * Z);
            var divisor2 = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
            return Math.Round(dividend / (divisor1 * divisor2), 3);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
