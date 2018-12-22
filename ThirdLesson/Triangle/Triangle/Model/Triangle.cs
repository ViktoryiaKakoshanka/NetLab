namespace TriangleLib.Model
{
    public class Triangle
    {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }
        
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }
        
        public override string ToString() => FirstSide + ", " + SecondSide + ", " + ThirdSide;
    }
}