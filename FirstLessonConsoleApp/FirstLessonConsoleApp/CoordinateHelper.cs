using FirstLessonConsoleApp.Model;
using System.Globalization;

namespace FirstLessonConsoleApp
{
    public static class CoordinateHelper
    {
        public static bool TryParseCoordinate(string input, out Coordinate coordinate)
        {
            string[] parts;

            if (!TrySplitCoordinateParts(input, out parts))
            {
                coordinate = null;
                return false;
            }

            return TryParseCoordinateParts(parts, out coordinate);
        }

        private static bool TrySplitCoordinateParts(string input, out string[] parts)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                parts = null;
                return false;
            }

            parts = input.Split(',');

            if (parts.Length != 2)
            {
                parts = null;
                return false;
            }

            return true;
        }

        private static bool TryParseCoordinateParts(string[] parts, out Coordinate coordinate)
        {
            var x = 0.0;
            var y = 0.0;

            if (!TryParseDouble(parts[0], out x) || !TryParseDouble(parts[1], out y))
            {
                coordinate = null;
                return false;
            }

            coordinate = new Coordinate(x, y);
            return true;
        }

        private static bool TryParseDouble(string value, out double parsedValue)
        {
            return double.TryParse(value, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out parsedValue);
        }
    }
}
