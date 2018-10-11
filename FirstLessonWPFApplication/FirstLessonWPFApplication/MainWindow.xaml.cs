using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

namespace FirstLessonWPFApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listCoordinates = new List<string>();
        string[] coordinates = new string[2];
        double coordinateX, coordinateY;
        string resultFormating;
        readonly OpenFileDialog openFile = new OpenFileDialog();
        
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            openFile.FileOk += OnOpenFileDialogOK;
        }

        /// <summary>
        /// Выбрать файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatedCoordinatesFile_Click(object sender, RoutedEventArgs e)
        {
            openFile.ShowDialog();
        }

        /// <summary>
        /// считывание строк из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenFileDialogOK(object sender, CancelEventArgs e)
        {
            string pathFile = openFile.FileName;

            using (StreamReader instanceStreamReader = new StreamReader(pathFile, Encoding.Default))
            {
                string coordinatePair;
                while ((coordinatePair = instanceStreamReader.ReadLine()) != null)
                {
                    listCoordinates.Add(coordinatePair);
                }

                FormattedСoordinateOutput(listCoordinates);
            }
        }

        /// <summary>
        /// Форматированный вывод координат в listbox
        /// </summary>
        /// <param name="fields">строки из файла</param>
        void FormattedСoordinateOutput(List<string> fields)
        {
            foreach (var field in fields)
            {
                coordinates = field.Split(',');
                coordinateX = Convert.ToDouble(coordinates[0].Replace('.', ','));
                coordinateY = Convert.ToDouble(coordinates[1].Replace('.', ','));

                resultFormating = "X: " + String.Format("{0:#.####}", coordinateX) + " Y: " + String.Format("{0:#.####}", coordinateY);
                listbxOutputCoordinates.Items.Add(resultFormating);
            }
        }

        /// <summary>
        /// Форматированный вывод координат в listbox, данные из textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatedCoordinatesOutput_Click(object sender, RoutedEventArgs e)
        {
            string coordinatePair = tbInputCoordinates.Text;
                        
            coordinates = coordinatePair.Split(',');
            coordinateX = Convert.ToDouble(coordinates[0].Replace('.', ','));
            coordinateY = Convert.ToDouble(coordinates[1].Replace('.', ','));

            resultFormating = "X: "+ String.Format("{0:#.####}", coordinateX) + " Y: " + String.Format("{0:#.####}", coordinateY);
            listbxOutputCoordinates.Items.Add(resultFormating);
        }
    }
}
