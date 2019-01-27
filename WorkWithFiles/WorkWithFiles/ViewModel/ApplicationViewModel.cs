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
                if (Equals(value, _text))
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

        public ApplicationViewModel() : this(new DialogService(), new FileService())
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
            try
            {
                if (_dialogService.ShowOpenFileDialog() != true)
                {
                    return;
                }

                Text = _fileService.Open(_dialogService.FilePath);
                _dialogService.ShowMessage("File open.");
            }
            catch (IOException e)
            {
                _dialogService.ShowMessage($"{e.Message}\nChoose another file");
            }
            catch (Exception)
            {
                _dialogService.ShowMessage("File is closed.");
            }
        }

        private void SaveFileAs()
        {
            try
            {
                if (_dialogService.ShowSaveFileDialog() != true)
                {
                    return;
                }

                _fileService.Save(_dialogService.FilePath, _text);
                _dialogService.ShowMessage("File save.");
            }
            catch (ArgumentNullException)
            {
                _dialogService.ShowMessage("No text to write.");
            }
            catch
            {
                _dialogService.ShowMessage("File is closed.");
            }
        }

        private void SaveFile()
        {
            try
            {
                _fileService.Save(_dialogService.FilePath, _text);
                _dialogService.ShowMessage("File save.");
            }
            catch (ArgumentNullException)
            {
                _dialogService.ShowMessage("The file has not been opened.");
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage($"File is closed.\n{e.Message}");
            }
        }
    }
}
