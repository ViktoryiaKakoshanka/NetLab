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
            var file = new CoordinatesFromFile();
            file.OpenFile();
            foreach (var field in file.GetListCoordinatesFromFile())
            {
                listbxOutputCoordinates.Items.Add(new FormattedСoordinate().FormatedFirstMethod(field));
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
            listbxOutputCoordinates.Items.Add(new FormattedСoordinate().FormatedFirstMethod(userInput));
        }
                
    }
}
