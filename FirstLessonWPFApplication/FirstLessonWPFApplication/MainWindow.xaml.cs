using System.Collections.Generic;
using Microsoft.Win32;
using System.Windows;

namespace FirstLessonWPFApplication
{
    /// <summary>
    /// Interaction Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Point of entry
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void FormattedCoordinatesFileOnClick(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog();
            var readLines = new List<string>();
            
            if (openFile.ShowDialog() == true)
            {
                readLines = CoordinatesFromFile.ReadFileInListbox(openFile.FileName);
            }
            FormattedCoordinatesOutputFromFile(readLines);
        }
        
        private void FormattedCoordinatesOutputOnClick(object sender, RoutedEventArgs e)
        {
            var userInput = tbInputCoordinates.Text;
            if(userInput != string.Empty)
            {
                listbxOutputCoordinates.Items.Add(Format.СoordinatesFormat(userInput));
            }
            else
            {
                MessageBox.Show("Enter the coordinates");
            }
        }

        /// <summary>
        /// Call formatting on the coordinate line read from the file
        /// </summary>
        public void FormattedCoordinatesOutputFromFile(List<string> lines)
        {
            foreach (var field in lines)
            {
                listbxOutputCoordinates.Items.Add(Format.СoordinatesFormat(field));
            }
        }
    }
}
