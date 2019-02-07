using System;

namespace TimerApplication.Timer
{
    public interface ITimer
    {
        int InitialNumberSeconds { get; set; }
        int RemainNumberSeconds { get; }

        event EventHandler TimerFinished;
        event EventHandler UpdateRemainingTime;

        void RunTimer(int durationInMilliseconds = 1000);
    }
}
