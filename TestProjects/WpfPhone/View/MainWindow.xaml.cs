using System.Windows;
using WpfPhone.DialogService;
using WpfPhone.FileService;
using WpfPhone.ViewModel;

namespace WpfPhone
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new JsonFileService());
        }
    }
}
