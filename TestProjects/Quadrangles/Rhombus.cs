namespace Quadrangles
{
    internal class Rhombus : Figure
    {
        public double DiagonalFirst { get; }
        public double DiagonalSecond { get; }

        public Rhombus(double sideFirst, double sideSecond, double sideThird, double sideFourth, double diagonalFirst, double diagonalSecond) 
            : base(sideFirst, sideSecond, sideThird, sideFourth)
        {
            DiagonalFirst = diagonalFirst;
            DiagonalSecond = diagonalSecond;
        }

        public override double CalculatePerimeter()
        {
            return (SideFirst + SideSecond) * 2;
        }

        public override double CalculateSquare()
        {
            return DiagonalFirst * DiagonalSecond / 2;
        }
    }
}
