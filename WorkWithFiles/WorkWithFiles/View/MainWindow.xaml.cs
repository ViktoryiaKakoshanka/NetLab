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

            IDialogService dialogService = new DialogService();
            IFileService fileService = new FileService();
            DataContext = new ApplicationViewModel(dialogService, fileService);
        }
    }
}

