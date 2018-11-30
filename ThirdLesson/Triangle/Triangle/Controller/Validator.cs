using System.Globalization;

namespace TriangleLib.Controller
{
    public class Validator
    {
        public static bool TryParseSideLength(string userInput, out double side)
        {
            var correctNumberFormat = userInput.Replace(",", ".");

            return double.TryParse(correctNumberFormat, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out side);
        }

        public static bool TriangleExists(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            var firstSideValid = firstSideLength < secondSideLength + thirdSideLength;
            var secondSideValid = secondSideLength < firstSideLength + thirdSideLength;
            var thirdSideValid = thirdSideLength < firstSideLength + secondSideLength;

            return firstSideValid && secondSideValid && thirdSideValid;
        }
    }
}