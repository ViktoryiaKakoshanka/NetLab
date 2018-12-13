using System;

namespace Quadrangles
{
    internal class Square : Figure
    {
        internal Square(double sideFirst, double sideSecond, double sideThird, double sideFourth) : base(sideFirst, sideSecond, sideThird, sideFourth)
        {
        }

        public override double CalculatePerimeter()
        {
            return SideFirst * 4.0;
        }

        public override double CalculateSquare()
        {
            return Math.Pow(SideFirst, 2);
        }
    }
}