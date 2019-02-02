using System;

namespace TimerApplication
{
    public class EndTimerEventAgs : EventArgs
    {
        public int UserCount { get; }

        public EndTimerEventAgs(int userCount)
        {
            UserCount = userCount;
        }
    }
}