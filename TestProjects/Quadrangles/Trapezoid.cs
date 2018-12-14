using System;

namespace Quadrangles
{
    public class Trapezoid : Quadrangle
    {
        private double _topBase;
        private double _leftEdge;
        private double _rightEdge;
        private double _height;

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

        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                {
                    throw GetNewArgumentException(value);
                }

                _height = value;
            }
        }

        public Trapezoid(double bottomBase, double topBase, double leftEdge, double rightEdge, double height) :
            base(bottomBase)
        {
            _topBase = topBase;
            _leftEdge = leftEdge;
            _rightEdge = rightEdge;
            _height = height;
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
    }
}