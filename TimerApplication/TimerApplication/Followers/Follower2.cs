using System.Windows;

namespace TimerApplication.Followers
{
    public class Follower2
    {
        public Follower2(EndTimer timer)
        {
            timer.EndTimerEventHandler += ShowNewMessage;
        }

        public static void ShowNewMessage(object sender, EndTimerEventAgs e)
        {
            MessageBox.Show($"class Follower2 : ShowNewMessage(object sender, EndTimerEventAgs e) = {e.UserCount}");
        }
    }
}
