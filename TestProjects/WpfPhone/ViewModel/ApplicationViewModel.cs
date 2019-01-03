using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfPhone.Annotations;
using WpfPhone.DialogService;
using WpfPhone.FileService;
using WpfPhone.Model;

namespace WpfPhone.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IFileService _fileService;
        private readonly IDialogService _dialogService;

        private Phone _selectedPhone;
        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _openCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Phone> Phones { get; set; }

        public Phone SelectedPhone
        {
            get => _selectedPhone;
            set
            {
                if (Equals(value, _selectedPhone))
                {
                    return;
                }
                _selectedPhone = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    var phone = new Phone();
                    Phones.Insert(0, phone);
                    SelectedPhone = phone;
                }));
            }
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new RelayCommand(obj =>
                           {
                               if (obj is Phone phone)
                               {
                                   Phones.Remove(phone);
                               }
                           },
                           obj => Phones.Count > 0));
            }
        }

        public RelayCommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (_dialogService.SaveFileDialog() != true)
                    {
                        return;
                    }
                    _fileService.Save(_dialogService.FilePath, Phones.ToList());
                    _dialogService.ShowMessage("File saved.");
                }
                catch
                {
                    _dialogService.ShowMessage("File not saved.");
                }
            })); }
        }

        public RelayCommand OpenCommand
        {
            get { return _openCommand ?? (_openCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (_dialogService.OpenFileDialog() != true)
                    {
                        return;
                    }

                    var phones = _fileService.Open(_dialogService.FilePath);
                    Phones.Clear();
                    foreach (var phone in phones)
                    {
                        Phones.Add(phone);
                    }
                    _dialogService.ShowMessage("File open.");
                }
                catch
                {
                    _dialogService.ShowMessage("File is closed");
                }
            })); }
        }

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;

            Phones = new ObservableCollection<Phone>
            {
                new Phone {Title = "iPhone 7", Company = "Apple", Price = 56000},
                new Phone {Title = "Galaxy S7 Edge", Company = "Samsung", Price = 60000},
                new Phone {Title = "Elite x3", Company = "HP", Price = 56000},
                new Phone {Title = "Mi5S", Company = "Xiaomi", Price = 35000}
            };
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}