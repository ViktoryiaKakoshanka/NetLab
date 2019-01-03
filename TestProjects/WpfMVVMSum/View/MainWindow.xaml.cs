using System.Windows;
using WpfMVVMSum.ViewModels;

namespace WpfMVVMSum
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
