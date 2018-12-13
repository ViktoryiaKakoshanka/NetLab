namespace Quadrangles
{
    internal abstract class Figure
    {
        public double SideFirst { get; }
        public double SideSecond { get; }
        public double SideThird { get; }
        public double SideFourth { get; }

        protected Figure(double sideFirst, double sideSecond, double sideThird, double sideFourth)
        {
            SideFirst = sideFirst;
            SideSecond = sideSecond;
            SideThird = sideThird;
            SideFourth = sideFourth;
        }

        public abstract double CalculatePerimeter();
        public abstract double CalculateSquare();
    }
}
