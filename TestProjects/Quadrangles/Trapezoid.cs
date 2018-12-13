namespace Quadrangles
{
    internal class Trapezoid : Figure
    {
        public double Height { get; }

        public Trapezoid(double baseFirst, double baseSecond, double sideLeft, double sideRight, double height) : base(baseFirst, baseSecond, sideLeft, sideRight)
        {
            Height = height;
        }

        public override double CalculatePerimeter()
        {
            return SideFirst + SideSecond + SideThird + SideFourth;
        }

        public override double CalculateSquare()
        {
            return (SideFirst + SideSecond) / 2 * Height;
        }
    }
}