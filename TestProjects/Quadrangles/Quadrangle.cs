using System;

namespace Quadrangles
{
    public abstract class Quadrangle
    {
        public double FirstEdge { get; }

        public double SecondEdge { get; }

        public double ThirdEdge { get; }

        public double FourthEdge { get; }

        protected Quadrangle(double firstEdge, double secondEdge, double thirdEdge, double fourthEdge)
        {
            FirstEdge = firstEdge;
            SecondEdge = secondEdge;
            ThirdEdge = thirdEdge;
            FourthEdge = fourthEdge;
            ValidateEdges();
        }

        public double CalculatePerimeter()
        {
            return FirstEdge + SecondEdge + ThirdEdge + FourthEdge;
        }

        public abstract double CalculateSquare();

        private void ValidateEdges()
        {
            if (FirstEdge <= 0 || SecondEdge <= 0 || ThirdEdge <= 0|| FourthEdge <= 0)
            {
                throw new ArgumentException("The edge of the quadrangle must be positive and greater than 0.");
            }
        }
    }
}