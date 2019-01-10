namespace TriangleLib.Model
{
    public class Triangle
    {
        public double FirstEdge { get; }
        public double SecondEdge { get; }
        public double ThirdEdge { get; }
        
        public Triangle(double firstEdge, double secondEdge, double thirdEdge)
        {
            FirstEdge = firstEdge;
            SecondEdge = secondEdge;
            ThirdEdge = thirdEdge;
        }
        
        public override string ToString() => FirstEdge + ", " + SecondEdge + ", " + ThirdEdge;
    }
}