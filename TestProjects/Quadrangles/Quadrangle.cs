using System;

namespace Quadrangles
{
    public abstract class Quadrangle
    {
        private double _mainEdge;

        public double MainEdge
        {
            get => _mainEdge;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{value} cannot be the edge of a quadrilateral.\nThe edge of the quadrangle must be positive and greater than 0.");
                }
                _mainEdge = value;
            }
        }

        protected Quadrangle(double edge)
        {
            MainEdge = edge;
        }

        public abstract double CalculatePerimeter();
        public abstract double CalculateSquare();
    }
}