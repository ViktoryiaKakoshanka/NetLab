using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstLessonWPFApplication.Controller
{
    class CoordinatesFromFile
    {
        private readonly OpenFileDialog openFile = new OpenFileDialog();
        private List<string> listCoordinatesFromFile = new List<string>();


        public void OpenFile()
        {
            openFile.ShowDialog();
            openFile.FileOk += OnOpenFileDialogOK;
        }
        
        /// <summary>
        /// Считывание строк из файла в listCoordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnOpenFileDialogOK(object sender, CancelEventArgs e)
        {
            string pathFile = openFile.FileName;

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
