using System;
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
        
        public delegate void SomeMethod();

        public event SomeMethod EndTimer = () => {};
        public event EventHandler<EndTimerEventAgs> EndTimerEventHandler;

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
            get { return new RelayCommand(obj =>
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

                        EndTimer();
                        EndTimerEventHandler?.Invoke(this, eventAgs);
                    }
                });
            });}
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}