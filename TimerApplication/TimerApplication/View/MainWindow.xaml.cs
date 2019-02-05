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
            var timerModel = new TimerModel(timer);
            var timerViewModel = new TimerViewModel(timerModel);
            new Follower1(timer);
            new Follower2(timer);
            new Follower3(timer);

            DataContext = timerViewModel;
        }
    }
}
