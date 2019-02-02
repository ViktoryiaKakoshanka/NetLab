using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApplication.Timer
{
    public class MyTimer
    {
        private readonly ITimerUpdate _timerUpdate;

        public MyTimer(ITimerUpdate timerUpdate = null)
        {
            _timerUpdate = timerUpdate;
        }

        public event EventHandler<EndTimerEventAgs> EndTimerEventHandler;

        public void OnEndTimer(object sender, EndTimerEventAgs e)
        {
            EndTimerEventHandler?.Invoke(sender, e);
        }

        public void RunTimer(int numberOfSeconds, int durationInMilliseconds = 1000)
        {
            var eventAgs = new EndTimerEventAgs(numberOfSeconds);

            Task.Factory.StartNew(() =>
            {
                for (var i = numberOfSeconds; i >= 0; i--)
                {
                    _timerUpdate?.Update(i);
                    Thread.Sleep(durationInMilliseconds);
                    if (i != 0)
                    {
                        continue;
                    }

                    OnEndTimer(this, eventAgs);
                }
            });
        }
    }
}
