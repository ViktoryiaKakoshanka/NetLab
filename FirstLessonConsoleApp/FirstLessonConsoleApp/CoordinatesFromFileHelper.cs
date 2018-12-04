using FirstLessonConsoleApp.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLessonConsoleApp
{
    public static class CoordinatesFromFileHelper
    {
        public static ICollection<Coordinate> ReadCoordinatesFromFile(string filePath)
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
            Coordinate coordinate;

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();

                if (CoordinateHelper.TryParseCoordinate(line, out coordinate))
                {
                    coordinates.Add(coordinate);
                }
            }

            return coordinates;
        }
    }
}
