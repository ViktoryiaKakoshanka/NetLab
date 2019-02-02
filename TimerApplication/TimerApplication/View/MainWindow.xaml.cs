using System.Windows;
using TimerApplication.Followers;
using TimerApplication.ViewModel;

namespace TimerApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var timerViewModel = new TimerViewModel();
            new Follower1(timerViewModel.Timer);
            new Follower2(timerViewModel.Timer);
            new Follower3(timerViewModel.Timer);

            DataContext = timerViewModel;
        }
    }
}
