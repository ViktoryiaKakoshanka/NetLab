using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimerApplication.Annotations;
using TimerApplication.Timer;

namespace TimerApplication.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private TimerModel _timerModel;
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public TimerModel TimerModel
        {
            get => _timerModel;
            set
            {
                _timerModel = value;
                OnPropertyChanged();
            }
        }
        
        public TimerViewModel()
        {
            TimerModel = new TimerModel(new MyTimer());
        }

        public TimerViewModel(TimerModel timerModel)
        {
            TimerModel = timerModel;
        }

        public RelayCommand StartTimer
        {
            get { return new RelayCommand(obj => TimerModel.MyTimer.RunTimer(TimerModel.NumberOfSeconds)); }
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}