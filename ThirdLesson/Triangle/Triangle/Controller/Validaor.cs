using System.Globalization;

namespace TriangleLib.Controller
{
    public class Validator
    {
        public static double TryParseSide(string side)
        {
            side = side.Replace(",", ".");

            double.TryParse(side, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out var parsedSide);
            return parsedSide;
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