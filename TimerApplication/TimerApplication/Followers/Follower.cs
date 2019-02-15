using System.Windows;
using TimerApplication.Timer;

namespace TimerApplication.Followers
{
    public class Follower
    {
        public Follower(string followerName, MyTimer timer)
        {
            timer.TimerFinished += (sender, initialNumberSeconds) =>
            {
                MessageBox.Show($"User set {initialNumberSeconds} seconds.", followerName); 
            };
        }
    }
}