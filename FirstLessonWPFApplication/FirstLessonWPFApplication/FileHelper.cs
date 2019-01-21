using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FirstLessonWPFApplication
{
    internal static class FileHelper
    {
        public static List<string> ReadFile(string pathFile)
        {
            var readLines = File.ReadAllLines(pathFile);
            return readLines.ToList();
        }
    }
}
