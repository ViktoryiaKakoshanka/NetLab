using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using WorkWithFiles.Properties;

namespace WorkWithFiles.ViewModel
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        private string _text;
        private readonly IDialogService _dialogService;
        private readonly IFileService _fileService;

        private RelayCommand _openCommand;
        private RelayCommand _saveAsCommand;
        private RelayCommand _saveCommand;

        public string Text
        {
            get => _text;
            set
            {
                if (value == _text)
                {
                    return;
                }

                _text = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenCommand
        {
            get { return _openCommand ?? (_openCommand = new RelayCommand(obj => OpenFile())); }
        }

        public RelayCommand SaveAs
        {
            get { return _saveAsCommand ?? (_saveAsCommand = new RelayCommand(obj => SaveFileAs())); }
        }

        public RelayCommand Save
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(obj => SaveFile())); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationViewModel() : this (new DialogService(), new FileService())
        {
        }

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenFile()
        {
            if (_dialogService.ShowOpenFileDialog() != true)
            {
                return;
            }

            try
            {
                Text = _fileService.ReadFile(_dialogService.FilePath);
            }
            catch (IOException e)
            {
                _dialogService.ShowMessage($"{e.Message}\nChoose another file.");
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage($"An error has occurred.\n{e.Message}");
            }
        }

        private void SaveFileAs()
        {
            if (_dialogService.ShowSaveFileDialog() != true)
            {
                return;
            }

            try
            {
                _fileService.Save(_dialogService.FilePath, _text);
            }
            catch (ArgumentNullException)
            {
                _dialogService.ShowMessage("File was not selected");
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage($"An error has occurred.\n{e.Message}");
            }
        }

        private void SaveFile()
        {
            try
            {
                _fileService.Save(_dialogService.FilePath, _text);
            }
            catch (ArgumentNullException)
            {
                _dialogService.ShowMessage("File was not selected.");
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage($"An error has occurred.\n{e.Message}");
            }
        }
    }
}
