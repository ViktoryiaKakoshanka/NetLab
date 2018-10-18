using FirstLessonConsoleApp.Model;
using FirstLessonWPFApplication.Controller;
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
        private CoordinatesFromFile file = new CoordinatesFromFile();

        /// <summary>
        /// Точка входа
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выбрать файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatedCoordinatesFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            
            if (openFile.ShowDialog() == true)
            {
                file.ReadFileInListbox(openFile.FileName);
            }
            FormatedCoordinatesOutputFromFile();
        }

        
        /// <summary>
        /// Вызов форматирования на строку координат считанных из textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatedCoordinatesOutput_Click(object sender, RoutedEventArgs e)
        {
            var userInput = tbInputCoordinates.Text;
            if(userInput != string.Empty)
            {
                listbxOutputCoordinates.Items.Add(new FormattedСoordinate().FormatedMethod(userInput));
            }
            else
            {
                MessageBox.Show("Введите координаты");
            }
        }

        /// <summary>
        /// Вызов форматирования на строку координат считанных из файла
        /// </summary>
        public void FormatedCoordinatesOutputFromFile()
        {
            foreach (var field in file.GetListCoordinatesFromFile())
            {
                listbxOutputCoordinates.Items.Add(new FormattedСoordinate().FormatedMethod(field));
            }
        }
    }
}
