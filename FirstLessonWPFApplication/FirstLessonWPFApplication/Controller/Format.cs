using FirstLessonConsoleApp.Model;

namespace FirstLessonWPFApplication.Controller
{
    internal static class Format
    {
        public static string FormatСoordinates(string userInput)
        {
            var coordinate = CoordinatesHelper.ParseUserInputToCoordinate(userInput);
            return coordinate != null ? coordinate.ToString() : string.Empty;
        }
    }
}
