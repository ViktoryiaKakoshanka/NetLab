namespace Quadrangles
{
    internal class Parallelogram : Figure
    {
        public double Height { get; }

        public Parallelogram(double sideFirst, double sideSecond, double sideThird, double sideFourth, double height) : base(sideFirst, sideSecond, sideThird, sideFourth)
        {
            Height = height;
        }

        public override double CalculatePerimeter()
        {
            return (SideFirst + SideSecond) * 2;
        }

        public override double CalculateSquare()
        {
            return SideFirst * SideSecond;
        }
    }
}
