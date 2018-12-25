using System.Globalization;

namespace TriangleLib.Controller
{
    public class Validator
    {
<<<<<<< HEAD:ThirdLesson/Triangle/Triangle/Controller/Validaor.cs
        public static double TryParseSide(string side)
        {
            side = side.Replace(",", ".");

            double.TryParse(side, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out var parsedSide);
            return parsedSide;
=======
        public static bool TryParseSideLength(string userInput, out double side)
        {
            var correctNumberFormat = userInput.Replace(",", ".");

            return double.TryParse(correctNumberFormat, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out side);
>>>>>>> master:ThirdLesson/Triangle/Triangle/Controller/Validator.cs
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