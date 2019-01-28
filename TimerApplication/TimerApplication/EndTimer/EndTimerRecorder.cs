using TimerApplication.Followers;

namespace TimerApplication
{
    public class EndTimerRecorder
    {
        public EndTimer EndTimer { get; }

        public EndTimerRecorder()
        {
            var endTimer = new EndTimer();
            EndTimer = endTimer;
            new Follower1(endTimer);
            new Follower2(endTimer);
            new Follower3(endTimer);
        }
    }
}
