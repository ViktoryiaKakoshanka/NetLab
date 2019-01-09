using FirstLessonConsoleApp.Model;
using FirstLessonConsoleApp.View;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLessonConsoleApp.Menu
{
    public class ReadCoordinatesFromFileMenuItem : MenuItem
    {
        private readonly string _path;

        public ReadCoordinatesFromFileMenuItem(int orderNumber, string text, IView view, string filePath) : base(orderNumber, text, view)
        {
            _path = filePath;
        }

        public override void Execute()
        {
            var coordinates = new List<Coordinate>();

            using (var streamReader = new StreamReader(_path, Encoding.Default))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var coordinate = CoordinatesHelper.ParseUserInputToCoordinate(line);

                    if (coordinate != null)
                    {
                        coordinates.Add(coordinate);
                    }
                }
            }

            GetView().PrintCoordinates(coordinates);
        }
    }
}
