using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FirstLessonWPFApplication.Controller
{
    class CoordinatesFromFile
    {
        private List<string> listCoordinatesFromFile = new List<string>();

        public void ReadFileInListbox(string pathFile)
        {
            using (StreamReader instanceStreamReader = new StreamReader(pathFile, Encoding.Default))
            {
                string coordinatePair;
                while ((coordinatePair = instanceStreamReader.ReadLine()) != null)
                {
                    listCoordinatesFromFile.Add(coordinatePair);
                }
            }
        }

        public List<string> GetListCoordinatesFromFile()
        {
            return listCoordinatesFromFile;
        }
    }
}
