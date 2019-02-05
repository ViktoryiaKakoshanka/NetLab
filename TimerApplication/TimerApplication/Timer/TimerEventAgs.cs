using System;

namespace TimerApplication.Timer
{
    public class TimerEventAgs : EventArgs
    {
        public int UserCount { get; }

        public TimerEventAgs(int userCount)
        {
            UserCount = userCount;
        }
    }
}