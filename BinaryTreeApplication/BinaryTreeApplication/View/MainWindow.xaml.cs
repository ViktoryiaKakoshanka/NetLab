using System.Collections.Generic;
using System.Windows;
using BinaryTreeApplication.Model;
using BinaryTreeApplication.ViewModel;

namespace BinaryTreeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           var a = new ManagerViewModel(new DialogService(), new FileService<List<StudentTestRegister>>());
           DataContext = a;

           a.Qwe();
        }

    }
}
