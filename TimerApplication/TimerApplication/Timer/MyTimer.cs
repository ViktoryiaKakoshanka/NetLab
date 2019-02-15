using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApplication.Timer
{
    public class MyTimer
    {
        public int InitialNumberSeconds { get; set; }

        public event EventHandler<int> TimerFinished;
        public event EventHandler<int> UpdateRemainedTime;

        private int _remainedNumberSeconds;
        
        public void RunTimer(int durationInMilliseconds = 1000)
        {
            Task.Factory.StartNew(() =>
            {
                for (var restOfSeconds = InitialNumberSeconds; restOfSeconds >= 0; restOfSeconds--)
                {
                    _remainedNumberSeconds = restOfSeconds;
                    MyTimerOnUpdateRemainingTime();

                    Thread.Sleep(durationInMilliseconds);
                }
                MyTimerOnTimerFinished();
            });
        }
        
        private void MyTimerOnTimerFinished()
        {
            TimerFinished?.Invoke(this, InitialNumberSeconds);
        }

        private void MyTimerOnUpdateRemainingTime()
        {
            UpdateRemainedTime?.Invoke(this, _remainedNumberSeconds);
        }
    }
}
