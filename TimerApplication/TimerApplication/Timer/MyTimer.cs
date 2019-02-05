using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApplication.Timer
{
    public class MyTimer : ITimer
    {
        public event EventHandler EndTimerEventHandler;
        public event EventHandler UpdateRestTimeEventHandler;

        public int InitialNumberSeconds { get; set; }
        public int RestNumberSeconds { get; private set; }

        public void OnEndTimer(object sender)
        {
            EndTimerEventHandler?.Invoke(sender, EventArgs.Empty);
        }

        public void OnUpdateRestTime(object sender)
        {
            UpdateRestTimeEventHandler?.Invoke(sender, EventArgs.Empty);
        }

        public void RunTimer(int durationInMilliseconds = 1000)
        {
            Task.Factory.StartNew(() =>
            {
                for (var restSeconds = InitialNumberSeconds; restSeconds >= 0; restSeconds--)
                {
                    RestNumberSeconds = restSeconds;
                    OnUpdateRestTime(this);

                    Thread.Sleep(durationInMilliseconds);
                }
                OnEndTimer(this);
            });
        }
    }
}
