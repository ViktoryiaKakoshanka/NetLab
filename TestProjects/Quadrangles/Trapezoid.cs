using System;

namespace Quadrangles
{
    public class Trapezoid : Quadrangle
    {
        private double _topBase;
        private double _leftEdge;
        private double _rightEdge;

        public double TopBase
        {
            get => _topBase;
            set
            {
                if (value <= 0)
                {
                    throw GetNewArgumentException(value);
                }

                _topBase = value;
            }
        }

        public double LeftEdge
        {
            get => _leftEdge;
            set
            {
                if (value <= 0)
                {
                    throw GetNewArgumentException(value);
                }

                _leftEdge = value;
            }
        }

        public double RightEdge
        {
            get => _rightEdge;
            set
            {
                if (value <= 0)
                {
                    throw GetNewArgumentException(value);
                }

                _rightEdge = value;
            }
        }

        public double Height { get; }

        public Trapezoid(double bottomBase, double topBase, double leftEdge, double rightEdge) :
            base(bottomBase)
        {
            if (!IsTrapezoid(bottomBase, topBase, leftEdge, rightEdge))
            {
                throw new ArgumentException("There is no such trapezoid.");
            }
            _topBase = topBase;
            _leftEdge = leftEdge;
            _rightEdge = rightEdge;
            Height = CalculateHeight();
        }

        public override double CalculatePerimeter()
        {
            return MainEdge + TopBase + LeftEdge + RightEdge;
        }

        public override double CalculateSquare()
        {
            return (MainEdge + TopBase) / 2 * Height;
        }

        private static ArgumentException GetNewArgumentException(double value)
        {
            return new ArgumentException(
                $"{value} cannot be the edge of a trapezoid.\nThe edge of the quadrangle must be positive and greater than 0.");
        }

        private static bool IsTrapezoid(double bottomBase, double topBase, double leftEdge, double rightEdge)
        {
            if (topBase == bottomBase)
            {
                return false;
            }
            return leftEdge + rightEdge > bottomBase - topBase;
        }

        private double CalculateHeight()
        {
            

            var a = Math.Pow(MainEdge - TopBase, 2) + Math.Pow(LeftEdge, 2) - Math.Pow(RightEdge, 2);
            var b = 2 * (MainEdge - TopBase);
            var height = Math.Sqrt(Math.Pow(LeftEdge, 2) - Math.Pow(a/b, 2));
            return height;
        }
    }
}