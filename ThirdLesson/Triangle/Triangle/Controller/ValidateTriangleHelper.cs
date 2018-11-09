using System.Globalization;

namespace TriangleLib.Controller
{
    public class ValidateTriangleHelper
    {
        public static double TryParseInputtingSide(string maybeSide)
        {
            double side = 0.0;
            double.TryParse(maybeSide.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out side);
            return side;
        }

        public static bool ValidateTriangle(double firstSide, double secondSide, double thirdSide)
        {
            return ((firstSide <= secondSide + thirdSide) && (secondSide <= firstSide + thirdSide) && (thirdSide <= firstSide + secondSide));
        }
    }
}