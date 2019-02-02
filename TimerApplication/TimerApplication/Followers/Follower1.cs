using System.Windows;
using TimerApplication.Timer;

namespace TimerApplication.Followers
{
    public class Follower1
    {
        public Follower1(MyTimer timer)
        {
            timer.EndTimerEventHandler += ShowNewMessage;
        }

        public void ShowNewMessage(object sender, TimerEventAgs e)
        {
            MessageBox.Show($"User set {e.UserCount} seconds.", "Follower1");
        }
    }
}
