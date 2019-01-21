using FirstLessonConsoleApp.Model;

namespace FirstLessonWPFApplication
{
    internal static class Formatter
    {
        public static string FormatCoordinates(string userInput)
        {
            var coordinate = CoordinatesHelper.ParseUserInputToCoordinate(userInput);
            return coordinate != null ? coordinate.ToString() : string.Empty;
        }
    }
}
