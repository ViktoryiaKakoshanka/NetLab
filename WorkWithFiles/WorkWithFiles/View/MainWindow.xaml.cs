using System.Windows;
using WorkWithFiles.ViewModel;

namespace WorkWithFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new DialogService(), new FileService());
        }
    }
}

