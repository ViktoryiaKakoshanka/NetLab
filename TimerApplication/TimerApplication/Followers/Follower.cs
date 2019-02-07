using System.Windows;
using TimerApplication.Timer;

namespace TimerApplication.Followers
{
    public class Follower
    {
        private readonly string _name;

        public Follower(string followerName, ITimer timer)
        {
            _name = followerName;
            timer.TimerFinished += (sender, e) =>
            {
                var userNumberSeconds = ((ITimer) sender).InitialNumberSeconds;
                MessageBox.Show($"User set {userNumberSeconds} seconds.", _name); 
            };
        }
    }
}
