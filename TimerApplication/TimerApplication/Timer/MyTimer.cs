using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApplication.Timer
{
    public class MyTimer : ITimer
    {
        public event EventHandler TimerFinished;
        public event EventHandler UpdateRemainingTime;

        public int InitialNumberSeconds { get; set; }
        public int RemainNumberSeconds { get; private set; }
        
        public void RunTimer(int durationInMilliseconds = 1000)
        {
            Task.Factory.StartNew(() =>
            {
                for (var restOfSeconds = InitialNumberSeconds; restOfSeconds >= 0; restOfSeconds--)
                {
                    RemainNumberSeconds = restOfSeconds;
                    MyTimerOnUpdateRemainingTime(this);

                    Thread.Sleep(durationInMilliseconds);
                }
                MyTimerOnTimerFinished(this);
            });
        }
        
        private void MyTimerOnTimerFinished(object sender)
        {
            TimerFinished?.Invoke(sender, EventArgs.Empty);
        }

        private void MyTimerOnUpdateRemainingTime(object sender)
        {
            UpdateRemainingTime?.Invoke(sender, EventArgs.Empty);
        }
    }
}
