using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WpfMVVMSum.Annotations;

namespace WpfMVVMSum.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int _clicks;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Clicks
        {
            get => _clicks;
            set
            {
                _clicks = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    Clicks++;
                }
            });
        }
    }
}
