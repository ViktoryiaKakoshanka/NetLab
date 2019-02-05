using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimerApplication.Annotations;
using TimerApplication.Timer;

namespace TimerApplication
{
    public class TimerModel : INotifyPropertyChanged
    {
        private int _numberOfSeconds = 10;
        private int _currentNumberOfSeconds;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public MyTimer MyTimer { get; }

        public int CurrentNumberOfSeconds
        {
            get => _currentNumberOfSeconds;
            set
            {
                _currentNumberOfSeconds = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfSeconds
        {
            get => _numberOfSeconds;
            set
            {
                _numberOfSeconds = value;
                OnPropertyChanged();
            }
        }
        
        public TimerModel(MyTimer timer)
        {
            MyTimer = timer;
            MyTimer.UpdateTimeEventHandler += Update;
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Update(object sender, int restOfSeconds)
        {
            CurrentNumberOfSeconds = restOfSeconds;
        }
    }
}