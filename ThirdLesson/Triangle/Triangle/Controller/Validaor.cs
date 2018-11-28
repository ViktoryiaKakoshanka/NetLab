using System.Globalization;

namespace TriangleLib.Controller
{
    public class Validator
    {
        public static double TryParseInputtingSide(string maybeSide)
        {
            double side = 0.0;
            double.TryParse(maybeSide.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out side);
            return side;
        }

        public static bool ValidateTriangle(double firstSide, double secondSide, double thirdSide)
        {
            var isDisparityFirstSide = firstSide <= secondSide + thirdSide;
            var isDisparitySecondSide = secondSide <= firstSide + thirdSide;
            var isDisparityThirdSide = thirdSide <= firstSide + secondSide;

            return isDisparityFirstSide && isDisparitySecondSide && isDisparityThirdSide;
        }
    }
}