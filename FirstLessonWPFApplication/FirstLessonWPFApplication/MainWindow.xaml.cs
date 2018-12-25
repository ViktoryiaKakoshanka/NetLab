<<<<<<< HEAD
﻿using FirstLessonWPFApplication.Controller;
=======
﻿using FirstLessonConsoleApp;
using FirstLessonConsoleApp.Model;
>>>>>>> master
using Microsoft.Win32;
using System.Windows;
using System.Linq;

namespace FirstLessonWPFApplication
{
    /// <summary>
    /// Interaction Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
<<<<<<< HEAD
        private readonly CoordinatesFromFile _file = new CoordinatesFromFile();

=======
>>>>>>> master
        /// <summary>
        /// Point of entry
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
<<<<<<< HEAD
        private void FormatedCoordinatesFileOnClick(object sender, RoutedEventArgs e)
=======
        private void ReadCoordinatesFromFileOnClick(object sender, RoutedEventArgs e)
>>>>>>> master
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
<<<<<<< HEAD
                _file.ReadFileInListbox(openFile.FileName);
=======
                var coordinatesFromFile = CoordinatesFromFileHelper.ReadCoordinatesFromFile(openFile.FileName);
                coordinatesFromFile.ToList().ForEach(x => listbxOutputCoordinates.Items.Add(x));
>>>>>>> master
            }
        }


        /// <summary>
        /// Call formatting on the coordinate line read from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
<<<<<<< HEAD
        private void FormatedCoordinatesOutputOnClick(object sender, RoutedEventArgs e)
        {
            var userInput = tbInputCoordinates.Text;
            if(userInput != string.Empty)
            {
                listbxOutputCoordinates.Items.Add(new Format().FormatСoordinates(userInput));
            }
            else
            {
                MessageBox.Show("Enter the coordinates");
            }
        }

        /// <summary>
        /// Call formatting on the coordinate line read from the file
        /// </summary>
        public void FormatedCoordinatesOutputFromFile()
        {
            foreach (var field in _file.GetListCoordinatesFromFile())
            {
                listbxOutputCoordinates.Items.Add(new Format().FormatСoordinates(field));
=======
        private void ReadCoordinatesFromTextBoxOnClick(object sender, RoutedEventArgs e)
        {
            var userInput = tbInputCoordinates.Text;
            Coordinate coordinate;

            if (!CoordinateHelper.TryParseCoordinate(userInput, out coordinate))
            {
                MessageBox.Show("Wrong coordinates format", "Error");
                return;
>>>>>>> master
            }

            listbxOutputCoordinates.Items.Add(coordinate);
        }
    }
}
