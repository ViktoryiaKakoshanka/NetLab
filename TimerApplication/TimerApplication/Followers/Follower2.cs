using System.Windows;
using TimerApplication.Timer;

namespace TimerApplication.Followers
{
    public class Follower2
    {
        public Follower2(MyTimer timer)
        {
            timer.EndTimerEventHandler += ShowNewMessage;
        }

        public static void ShowNewMessage(object sender, TimerEventAgs e)
        {
            MessageBox.Show($"User set {e.UserCount} seconds.", "Follower2");
        }
    }
}
