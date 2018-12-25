using FirstLessonConsoleApp.Model;
using FirstLessonConsoleApp.View;
using System.Collections.Generic;

namespace FirstLessonConsoleApp.Menu
{
    public class CoordinatesFromConsoleMenuItem : MenuItem
    {
<<<<<<< HEAD:FirstLessonConsoleApp/FirstLessonConsoleApp/Menu/ReadCoordinatesFromConsoleMenuItem.cs
        public ReadCoordinatesFromConsoleMenuItem(int orderNumber, string text, IView view) : base(orderNumber, text, view) { }
=======
        public CoordinatesFromConsoleMenuItem(int orderNumber, string text, IView view) : base(orderNumber, text, view) { }
>>>>>>> master:FirstLessonConsoleApp/FirstLessonConsoleApp/Menu/CoordinatesFromConsoleMenuItem.cs

        public override void Execute()
        {
            Coordinate coordinate;
            var coordinates = new List<Coordinate>();

            GetView().PrintMessage("Enter the coordinates:");

            do
            {
                var userInput = GetView().ReadLine();

                if (CoordinateHelper.TryParseCoordinate(userInput, out coordinate))
                {
                    coordinates.Add(coordinate);
                }
            } while (coordinate != null);

            GetView().PrintCoordinates(coordinates);
        }
    }
}
