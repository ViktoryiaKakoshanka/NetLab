using System.Windows;

namespace TimerApplication.Followers
{
    public class Follower1
    {
        public Follower1(EndTimer timer)
        {
            timer.EndTimerEventHandler += ShowNewMessage;
        }

        public void ShowNewMessage(object sender, EndTimerEventAgs e)
        {
            MessageBox.Show($"class Follower1 : ShowNewMessage(object sender, EndTimerEventAgs e) = {e.UserCount}");
        }
    }
}
