using System.Globalization;

namespace FirstLessonConsoleApp.Model
{
    public static class CoordinatesHelper
    {
        public static Coordinate ParseUserInputToCoordinate(string input)
        {
            var parts = input.Split(',');

            if(parts.Length != 2)
            {
                return null;
            }

            const NumberStyles numberStyle = NumberStyles.Number;
            var culture = CultureInfo.CreateSpecificCulture("en-US");

            if (!double.TryParse(parts[0], numberStyle, culture, out var x) || !double.TryParse(parts[1], numberStyle, culture, out var y))
            {
                return null;
            }

            return new Coordinate(x, y);
        }
    }
}
