using System.Windows;
using TimerApplication.Timer;

namespace TimerApplication.Followers
{
    public class Follower
    {
        public Follower(string followerName, ITimer timer)
        {
            timer.TimerFinished += (sender, e) =>
            {
                var userNumberSeconds = ((ITimer) sender).InitialNumberSeconds;
                MessageBox.Show($"User set {userNumberSeconds} seconds.", followerName); 
            };
        }
    }
}
