using System;

namespace Quadrangles
{
    public class Rhombus : Square
    {
        private double _angle;

        private double Angle
        {
            get => _angle;
            set
            {
                if (value <= 0 || value >= 180)
                {
                    throw new ArgumentException($"{value} cannot be the angle of a rhombus.\nThe tilt angle must be greater than 0 and less than 180.");
                }

                _angle = value;
            }
        }

        public Rhombus(double edge, double angle) : base(edge)
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