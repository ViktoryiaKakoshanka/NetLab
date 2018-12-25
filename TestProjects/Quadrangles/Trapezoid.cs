using System;

namespace Quadrangles
{
    public class Trapezoid : Quadrangle
    {
        public Trapezoid(double leftEdge, double topBase, double rightEdge, double bottomBase) : base(leftEdge, topBase, rightEdge, bottomBase)
        {
            if (!IsValid(leftEdge, topBase, rightEdge, bottomBase))
            {
                throw new ArgumentException("There is no such trapezoid.");
            }
        }

        public override double CalculateSquare()
        {
            var height = CalculateHeight();
            return (FourthEdge + SecondEdge) / 2 * height;
        }
        
        private static bool IsValid(double leftEdge, double topBase, double rightEdge, double bottomBase)
        {
            if (IsEquals(topBase, bottomBase))
            {
                return false;
            }
            return leftEdge + rightEdge > Math.Abs(bottomBase - topBase);
        }

        private double CalculateHeight()
        {
            var a = Math.Pow(FourthEdge - SecondEdge, 2) + Math.Pow(FirstEdge, 2) - Math.Pow(ThirdEdge, 2);
            var b = 2 * (FourthEdge - SecondEdge);
            var height = Math.Sqrt(Math.Pow(FirstEdge, 2) - Math.Pow(a/b, 2));
            return height;
        }

        public static bool IsEquals(double first, double second, double delta = 0.001)
        {
            return Math.Abs(first - second) <= delta;
        }
    }
}