using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimerApplication.Annotations;
using TimerApplication.Timer;

namespace TimerApplication.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private readonly MyTimer _myTimer;
        private int _currentNumberOfSeconds;
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public int NumberOfSeconds { get; set; }
        public int CurrentNumberOfSeconds
        {
            get => _currentNumberOfSeconds;
            set
            {
                _currentNumberOfSeconds = value;
                OnPropertyChanged();
            }
        }
        
        public TimerViewModel() : this(new MyTimer())
        {
        }

        public TimerViewModel(MyTimer timer)
        {
            _myTimer = timer;
            _myTimer.UpdateRemainedTime += (sender, remaindNumberSeconds) =>
            {
                CurrentNumberOfSeconds = remaindNumberSeconds;
            };
        }

        public RelayCommand StartTimer
        {
            get { return new RelayCommand(obj =>
            {
                _myTimer.InitialNumberSeconds = NumberOfSeconds;
                _myTimer.RunTimer();
            }); }
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}