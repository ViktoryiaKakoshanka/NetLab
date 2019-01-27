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

            /*var timerViewModel = new TimerViewModel();

            timerViewModel.EndTimer += Follower1.ShowMessage;
            timerViewModel.EndTimer += Follower2.ShowMessage;
            timerViewModel.EndTimer += Follower3.ShowMessage;

            timerViewModel.EndTimerEventHandler += Follower1.ShowNewMessage;

            DataContext = timerViewModel;*/
        }
    }
}
