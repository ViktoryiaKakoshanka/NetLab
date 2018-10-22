using FirstLessonConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
