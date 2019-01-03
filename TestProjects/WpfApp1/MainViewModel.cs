using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Annotations;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _clicks;
        
        public int Clicks
        {
            get => _clicks;
            set
            {
                _clicks = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Clicks++;
                }, (obj)=> Clicks < 10);
            }
        }
    }
}
