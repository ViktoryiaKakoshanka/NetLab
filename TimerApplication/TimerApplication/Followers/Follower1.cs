using System.Windows;

namespace TimerApplication.Followers
{
    public static class Follower1
    {
        public static void ShowMessage()
        {
            MessageBox.Show("class Follower1");
        }

        public static void ShowNewMessage(object sender, EndTimerEventAgs e)
        {
            MessageBox.Show($"class Follower1 : ShowNewMessage(object sender, EndTimerEventAgs e) = {e.UserCount}");
        }
    }
}
