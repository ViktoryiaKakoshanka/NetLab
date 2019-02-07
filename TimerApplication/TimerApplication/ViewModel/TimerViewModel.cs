using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimerApplication.Annotations;
using TimerApplication.Timer;

namespace TimerApplication.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private ITimer _myTimer;
        private int _currentNumberOfSeconds;
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public int NumberOfSeconds { get; set; }
        public int CurrentNumberOfSeconds
        {
            get { return _currentNumberOfSeconds; }
            set
            {
                _currentNumberOfSeconds = value;
                OnPropertyChanged();
            }
        }
        
        public TimerViewModel() : this(new MyTimer())
        {
        }

        public TimerViewModel(ITimer timer)
        {
            _myTimer = timer;
            _myTimer.UpdateRemainingTime += (sender, e) =>
            {
                CurrentNumberOfSeconds = ((ITimer) sender).RemainNumberSeconds;
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