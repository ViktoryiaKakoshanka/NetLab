using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FirstLessonWPFApplication.Controller
{
    internal class CoordinatesFromFile
    {
        private readonly List<string> _listCoordinatesFromFile = new List<string>();

        public void ReadFileInListbox(string pathFile)
        {
            using (var instanceStreamReader = new StreamReader(pathFile, Encoding.Default))
            {
                string coordinatePair;
                while ((coordinatePair = instanceStreamReader.ReadLine()) != null)
                {
                    _listCoordinatesFromFile.Add(coordinatePair);
                }
            }
        }

        public List<string> GetListCoordinatesFromFile()
        {
            return _listCoordinatesFromFile;
        }
    }
}
