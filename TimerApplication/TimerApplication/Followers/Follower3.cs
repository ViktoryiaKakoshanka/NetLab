using System.Windows;
using TimerApplication.Timer;

namespace TimerApplication.Followers
{
    public class Follower3
    {
        public Follower3(MyTimer timer)
        {
            timer.EndTimerEventHandler += ShowNewMessage;
        }

        public static void ShowNewMessage(object sender, TimerEventAgs e)
        {
            MessageBox.Show($"User set {e.UserCount} seconds.", "Follower3");
        }
    }
}
