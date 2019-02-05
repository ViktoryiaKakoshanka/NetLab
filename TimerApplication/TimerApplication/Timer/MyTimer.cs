using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApplication.Timer
{
    public class MyTimer
    {
        public event EventHandler<TimerEventAgs> EndTimerEventHandler;
        public event EventHandler<int> UpdateTimeEventHandler;
        
        public void OnEndTimer(object sender, TimerEventAgs e)
        {
            EndTimerEventHandler?.Invoke(sender, e);
        }

        public void OnUpdateTime(object sender, int time)
        {
            UpdateTimeEventHandler?.Invoke(sender, time);
        }

        public void RunTimer(int numberOfSeconds, int durationInMilliseconds = 1000)
        {
            var eventAgs = new TimerEventAgs(numberOfSeconds);

            Task.Factory.StartNew(() =>
            {
                for (var seconds = numberOfSeconds; seconds >= 0; seconds--)
                {
                    OnUpdateTime(this, seconds);
                    Thread.Sleep(durationInMilliseconds);
                }
                OnEndTimer(this, eventAgs);
            });
        }
    }
}
