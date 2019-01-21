using FirstLessonConsoleApp.Model;

namespace FirstLessonWPFApplication
{
    internal static class Format
    {
        public static string CoordinatesFormat(string userInput)
        {
            var coordinate = CoordinatesHelper.ParseUserInputToCoordinate(userInput);
            return coordinate != null ? coordinate.ToString() : string.Empty;
        }
    }
}
