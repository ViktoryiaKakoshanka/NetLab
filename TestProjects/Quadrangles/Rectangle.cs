using System;

namespace Quadrangles
{
    public class Rectangle : Quadrangle
    {
        private double _edge;

        public double Edge
        {
            get => _edge;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{value} cannot be the edge of a rectangle.\nThe edge of the quadrangle must be positive and greater than 0.");
                }

                _edge = value;
            }
        }

        public Rectangle(double firstEdge, double secondEdge) : base(firstEdge)
        {
            Edge = secondEdge;
        }

        public override double CalculatePerimeter()
        {
            return (MainEdge + Edge) * 2;
        }

        public override double CalculateSquare()
        {
            return MainEdge * Edge;
        }
    }
}
