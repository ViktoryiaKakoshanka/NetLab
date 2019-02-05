using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimerApplication.Annotations;
using TimerApplication.Timer;

namespace TimerApplication.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private int _numberOfSeconds = 10;
        private int _currentNumberOfSeconds;

        private readonly MyTimer _timer;

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
        }

        public TimerViewModel(MyTimer timer)
        {
            _timer = timer;
            _timer.UpdateTimeEventHandler += Update;
        }

        public RelayCommand StartTimer
        {
            get { return new RelayCommand(obj => _timer.RunTimer(_numberOfSeconds));}
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void Update(object sender ,int restOfSeconds)
        {
            CurrentNumberOfSeconds = restOfSeconds;
        }
    }
}