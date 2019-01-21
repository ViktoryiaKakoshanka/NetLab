using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FirstLessonWPFApplication
{
    internal static class CoordinatesFromFile
    {
        public static List<string> ReadFileInListbox(string pathFile)
        {
            var readLines = File.ReadAllLines(pathFile);
            return readLines.ToList();
        }
    }
}
