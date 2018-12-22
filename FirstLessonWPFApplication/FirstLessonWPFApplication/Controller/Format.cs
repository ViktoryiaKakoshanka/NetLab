using FirstLessonConsoleApp.Model;

namespace FirstLessonWPFApplication.Controller
{
    class Format
    {
        public string FormatСoordinates(string userInput)
        {
            var coordinate = CoordinatesHelper.ParseUserInputToCoordinate(userInput);
            return coordinate != null ? coordinate.ToString() : string.Empty;
        }
    }
}
