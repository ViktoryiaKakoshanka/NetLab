using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimerApplication.Annotations;
using TimerApplication.Timer;

namespace TimerApplication.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged, ITimerUpdate
    {
        private int _numberOfSeconds = 10;
        private int _currentNumberOfSeconds;

        public MyTimer Timer { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        
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

        public TimerViewModel()
        {
            Timer = new MyTimer(this);
        }

        public RelayCommand StartTimer
        {
            get { return new RelayCommand(obj => Timer.RunTimer(_numberOfSeconds));}
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void Update(int restOfSeconds)
        {
            CurrentNumberOfSeconds = restOfSeconds;
        }
    }
}