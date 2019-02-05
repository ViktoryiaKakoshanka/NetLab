using System.Windows;
using TimerApplication.Timer;

namespace TimerApplication.Followers
{
    public class Follower1
    {
        private readonly string _name;

        public Follower1(string followerName, MyTimer timer)
        {
            _name = followerName;
            timer.EndTimerEventHandler += (sender, e) => 
                { MessageBox.Show($"User set {e.UserCount} seconds.", _name); };
        }
    }
}
