using FirstLessonConsoleApp.Model;
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
        private List<string> listCoordinates = new List<string>();
        private readonly OpenFileDialog openFile = new OpenFileDialog();
        
        /// <summary>
        /// Точка входа
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
        /// Считывание строк из файла в listCoordinates
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

                FormattedOutputListСoordinates(listCoordinates);
            }
        }
        
        /// <summary>
        /// Вызов форматирования на строку координат считанных из textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatedCoordinatesOutput_Click(object sender, RoutedEventArgs e)
        {
            var userInput = tbInputCoordinates.Text;
            FormattedСoordinateOutput(userInput);
        }

        /// <summary>
        /// Вызов форматирования на каждую строку координат считанных из файла
        /// </summary>
        /// <param name="fields">список координат считанных из файла</param>
        public void FormattedOutputListСoordinates(List<string> fields)
        {
            foreach(var field in fields)
            {
                FormattedСoordinateOutput(field);
            }
        }


        /// <summary>
        /// Форматированный вывод координат в listbox
        /// </summary>
        /// <param name="userInput">строка координат для обработки</param>
        public void FormattedСoordinateOutput(string userInput)
        {
            var coordinate = new Coordinate();

            if (coordinate != null)
            {
                coordinate = CoordinatesHelper.ParseUserInputToCoordinate(userInput);
                if (coordinate != null)
                {
                    listbxOutputCoordinates.Items.Add(coordinate.ToString());
                }
            }
        }
    }
}
