using System;

namespace Quadrangles
{
    public class Parallelogram : Rectangle
    {
        private double _angle;

        private double Angle
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

        public Parallelogram(double firstEdge, double secondEdge, double angle) : base(firstEdge, secondEdge)
        {
            Angle = angle;
        }
        
        public override double CalculateSquare()
        {
            var radians = Math.PI * Angle / 180D;
            return base.CalculateSquare() * Math.Sin(radians);
        }
    }
}