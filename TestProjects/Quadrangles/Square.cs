using System;

namespace Quadrangles
{
    public class Square : Quadrangle
    {
        public Square(double edge) : base(edge)
        {
        }

        public override double CalculatePerimeter()
        {
            return MainEdge * 4.0;
        }

        public override double CalculateSquare()
        {
            return Math.Pow(MainEdge, 2);
        }
    }
}