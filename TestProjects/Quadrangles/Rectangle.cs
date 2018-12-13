namespace Quadrangles
{
    internal class Rectangle : Figure
    {
        public Rectangle(double sideFirst, double sideSecond, double sideThird, double sideFourth) : base(sideFirst, sideSecond, sideThird, sideFourth)
        {
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
