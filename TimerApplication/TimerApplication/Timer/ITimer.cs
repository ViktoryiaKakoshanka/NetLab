using System;

namespace TimerApplication.Timer
{
    public interface ITimer
    {
        int InitialNumberSeconds { get; set; }
        int RestNumberSeconds { get; }

        event EventHandler EndTimerEventHandler;
        event EventHandler UpdateRestTimeEventHandler;

        void OnEndTimer(object sender);
        void OnUpdateRestTime(object sender);

        void RunTimer(int durationInMilliseconds = 1000);
    }
}
