using System;

namespace TimerApplication
{
    public class EndTimerEventAgs : EventArgs
    {
        public EndTimerEventAgs(int userCount)
        {
            UserCount = userCount;
        }

        public int UserCount { get; }
    }
}