using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TimerApplication.Annotations;

namespace TimerApplication.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private int _userCount = 10;
        private int _currentCount;
        private readonly EndTimerRecorder _endTimerRecorder;
      
        public event PropertyChangedEventHandler PropertyChanged;

        public int CurrentCount
        {
            get => _currentCount;
            set
            {
                _currentCount = value;
                OnPropertyChanged();
            }
        }

        public int UserCount
        {
            get => _userCount;
            set
            {
                _userCount = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand StartTimer
        {
            get { return new RelayCommand(obj => RunTimer());}
        }

        public TimerViewModel()
        {
            _endTimerRecorder = new EndTimerRecorder();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RunTimer()
        {
            var eventAgs = new EndTimerEventAgs(UserCount);

            Task.Factory.StartNew(() =>
            {
                for (var i = UserCount; i >= 0; i--)
                {
                    CurrentCount = i;
                    Thread.Sleep(1000);
                    if (i != 0)
                    {
                        continue;
                    }

                    _endTimerRecorder.EndTimer.OnEndTimer(this, eventAgs);
                }
            });
        }
    }
}