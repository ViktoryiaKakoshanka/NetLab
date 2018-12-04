using FirstLessonConsoleApp;
using FirstLessonConsoleApp.Model;
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
        private void ReadCoordinatesFromFileOnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                var coordinatesFromFile = CoordinatesFromFileHelper.ReadCoordinatesFromFile(openFile.FileName);
                coordinatesFromFile.ToList().ForEach(x => listbxOutputCoordinates.Items.Add(x));
            }
        }


        /// <summary>
        /// Call formatting on the coordinate line read from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadCoordinatesFromTextBoxOnClick(object sender, RoutedEventArgs e)
        {
            var userInput = tbInputCoordinates.Text;
            Coordinate coordinate;

            if (!CoordinateHelper.TryParseCoordinate(userInput, out coordinate))
            {
                MessageBox.Show("Wrong coordinates format", "Error");
                return;
            }

            listbxOutputCoordinates.Items.Add(coordinate);
        }
    }
}
