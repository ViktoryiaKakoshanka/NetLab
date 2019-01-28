using System;

namespace TimerApplication
{
    public class EndTimer
    {
        public event EventHandler<EndTimerEventAgs> EndTimerEventHandler;

        public void OnEndTimer(object sender, EndTimerEventAgs e)
        {
            EndTimerEventHandler?.Invoke(sender, e);
        }
    }
}
