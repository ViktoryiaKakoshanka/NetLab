using System;

namespace Quadrangles
{
    public class Parallelogram : Quadrangle
    {
        private double _angle;

        public double Angle
        {
            get => _angle;
            set
            {
                if (value <= 0 || value >= 180)
                {
                    throw new ArgumentException($"{value} cannot be the angle of a parallelogram.\nThe tilt angle must be greater than 0 and less than 180.");
                }

                _angle = value;
            }
        }

        public Parallelogram(double firstEdge, double secondEdge, double angle) : base(firstEdge, secondEdge, firstEdge, secondEdge)
        {
            Angle = angle;
        }
        
        public override double CalculateSquare()
        {
            var radians = Math.PI * Angle / 180D;
            return FirstEdge * SecondEdge * Math.Sin(radians);
        }
    }
}