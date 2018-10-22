using System.Globalization;

namespace FirstLessonConsoleApp.Model
{
    public class CoordinatesHelper
    {
        public static Coordinate ParseUserInputToCoordinate(string input)
        {
            var parts = input.Split(',');

            if(parts.Length != 2)
            {
                return null;
            }

            var x = 0.0;
            var y = 0.0;

            if(!double.TryParse(parts[0], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out x) || !double.TryParse(parts[1], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out y))
            {
                return null;
            }

            return new Coordinate(x, y);
        }
    }
}
