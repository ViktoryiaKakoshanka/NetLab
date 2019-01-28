using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerApplication.Followers;
using TimerApplication.ViewModel;

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
