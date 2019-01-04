using System.Windows;

namespace TimerApplication.Followers
{
    public static class Follower3
    {
        public static void ShowMessage()
        {
            MessageBox.Show("class Follower3");
        }
        
        public static void ShowNewMessage(object sender, EndTimerEventAgs e)
        {
            MessageBox.Show($"class Follower3 : ShowNewMessage(object sender, EndTimerEventAgs e) = {e.UserCount}");
        }
    }
}
