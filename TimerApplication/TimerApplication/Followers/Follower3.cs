using System.Windows;

namespace TimerApplication.Followers
{
    public class Follower3
    {
        public Follower3(EndTimer timer)
        {
            timer.EndTimerEventHandler += ShowNewMessage;
        }

        public static void ShowNewMessage(object sender, EndTimerEventAgs e)
        {
            MessageBox.Show($"class Follower3 : ShowNewMessage(object sender, EndTimerEventAgs e) = {e.UserCount}");
        }
    }
}
