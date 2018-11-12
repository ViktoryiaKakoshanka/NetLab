using FirstLessonConsoleApp.Model;

namespace FirstLessonWPFApplication.Controller
{
    class FormattedСoordinate
    {
        public string FormatedMethod(string userInput)
        {
            var coordinate = new Coordinate();
            
            coordinate = CoordinatesHelper.ParseUserInputToCoordinate(userInput);
            if (coordinate != null)
            {
                return coordinate.ToString();
            }
            return string.Empty;
        }
    }
}
