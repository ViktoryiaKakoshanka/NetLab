using System.Windows;
using TimerApplication.Followers;
using TimerApplication.Timer;
using TimerApplication.ViewModel;

namespace TimerApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var timer = new MyTimer();
            var timerViewModel = new TimerViewModel(timer);
            new Follower("First follower", timer);
            new Follower("Second follower", timer);

            DataContext = timerViewModel;
        }
    }
}
