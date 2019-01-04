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
        
        private void FormattedCoordinatesFileOnClick(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog();
            
            if (openFile.ShowDialog() == true)
            {
                _file.ReadFileInListbox(openFile.FileName);
            }
            FormattedCoordinatesOutputFromFile();
        }
        
        private void FormattedCoordinatesOutputOnClick(object sender, RoutedEventArgs e)
        {
            var userInput = tbInputCoordinates.Text;
            if(userInput != string.Empty)
            {
                listbxOutputCoordinates.Items.Add(Format.FormatСoordinates(userInput));
            }
            else
            {
                MessageBox.Show("Enter the coordinates");
            }
        }

        /// <summary>
        /// Call formatting on the coordinate line read from the file
        /// </summary>
        public void FormattedCoordinatesOutputFromFile()
        {
            foreach (var field in _file.GetListCoordinatesFromFile())
            {
                listbxOutputCoordinates.Items.Add(Format.FormatСoordinates(field));
            }
        }
    }
}
