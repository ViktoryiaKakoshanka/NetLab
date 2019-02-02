using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApplication.Timer
{
    public class MyTimer
    {
        private readonly ITimerUpdate _timerUpdate;
        
        public event EventHandler<TimerEventAgs> EndTimerEventHandler;

        public MyTimer(ITimerUpdate timerUpdate = null)
        {
            _timerUpdate = timerUpdate;
        }

        public void OnEndTimer(object sender, TimerEventAgs e)
        {
            EndTimerEventHandler?.Invoke(sender, e);
        }

        public void RunTimer(int numberOfSeconds, int durationInMilliseconds = 1000)
        {
            var eventAgs = new TimerEventAgs(numberOfSeconds);

            Task.Factory.StartNew(() =>
            {
                for (var seconds = numberOfSeconds; seconds >= 0; seconds--)
                {
                    _timerUpdate?.Update(seconds);
                    Thread.Sleep(durationInMilliseconds);
                }
                OnEndTimer(this, eventAgs);
            });
        }
    }
}
