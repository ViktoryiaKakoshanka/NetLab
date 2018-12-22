using FirstLessonConsoleApp.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLessonConsoleApp
{
    public static class CoordinatesFromFileHelper
    {
<<<<<<< HEAD:FirstLessonConsoleApp/FirstLessonConsoleApp/Menu/ReadCoordinatesFromFileMenuItem.cs
        private readonly string _path;

        public ReadCoordinatesFromFileMenuItem(int orderNumber, string text, IView view, string filePath) : base(orderNumber, text, view)
=======
        public static ICollection<Coordinate> ReadCoordinatesFromFile(string filePath)
>>>>>>> master:FirstLessonConsoleApp/FirstLessonConsoleApp/CoordinatesFromFileHelper.cs
        {
            ICollection<Coordinate> coordinates = new List<Coordinate>();

            using (var streamReader = new StreamReader(filePath, Encoding.Default))
            {
                coordinates = ReadCoordinatesFromStreamReader(streamReader);
            }

            return coordinates;
        }

        private static ICollection<Coordinate> ReadCoordinatesFromStreamReader(StreamReader streamReader)
        {
            var coordinates = new List<Coordinate>();
<<<<<<< HEAD:FirstLessonConsoleApp/FirstLessonConsoleApp/Menu/ReadCoordinatesFromFileMenuItem.cs
=======
            Coordinate coordinate;
>>>>>>> master:FirstLessonConsoleApp/FirstLessonConsoleApp/CoordinatesFromFileHelper.cs

            while (!streamReader.EndOfStream)
            {
<<<<<<< HEAD:FirstLessonConsoleApp/FirstLessonConsoleApp/Menu/ReadCoordinatesFromFileMenuItem.cs
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var coordinate = CoordinatesHelper.ParseUserInputToCoordinate(line);
=======
                var line = streamReader.ReadLine();
>>>>>>> master:FirstLessonConsoleApp/FirstLessonConsoleApp/CoordinatesFromFileHelper.cs

                if (CoordinateHelper.TryParseCoordinate(line, out coordinate))
                {
                    coordinates.Add(coordinate);
                }
            }

            return coordinates;
        }
    }
}
