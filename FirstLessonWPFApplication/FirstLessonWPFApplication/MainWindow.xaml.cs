using FirstLessonWPFApplication.Controller;
using Microsoft.Win32;
using System.Windows;

namespace FirstLessonWPFApplication
{
    /// <summary>
    /// Interaction Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CoordinatesFromFile _file = new CoordinatesFromFile();

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
        private void FormatedCoordinatesFileOnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            
            if (openFile.ShowDialog() == true)
            {
                _file.ReadFileInListbox(openFile.FileName);
            }
            FormatedCoordinatesOutputFromFile();
        }


        /// <summary>
        /// Call formatting on the coordinate line read from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
        }
    }
}
