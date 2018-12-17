using System;

namespace Quadrangles
{
    public abstract class Quadrangle
    {
        private double _firstEdge;
        private double _secondEdge;
        private double _thirdEdge;
        private double _fourthEdge;

        public double FirstEdge
        {
            get => _firstEdge;
            private set => _firstEdge = ValidateEdge(value);
        }

        public double SecondEdge
        {
            get => _secondEdge;
            private set => _secondEdge = ValidateEdge(value);
        }

        public double ThirdEdge
        {
            get => _thirdEdge;
            private set => _thirdEdge = ValidateEdge(value);
        }

        public double FourthEdge
        {
            get => _fourthEdge;
            private set => _fourthEdge = ValidateEdge(value);
        }

        protected Quadrangle(double firstEdge, double secondEdge, double thirdEdge, double fourthEdge)
        {
            FirstEdge = firstEdge;
            SecondEdge = secondEdge;
            ThirdEdge = thirdEdge;
            FourthEdge = fourthEdge;
        }

        public double CalculatePerimeter()
        {
            return FirstEdge + SecondEdge + ThirdEdge + FourthEdge;
        }

        public abstract double CalculateSquare();

        private static double ValidateEdge(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{value} cannot be the edge of a quadrilateral.\nThe edge of the quadrangle must be positive and greater than 0.");
            }

            return value;
        }
    }
}