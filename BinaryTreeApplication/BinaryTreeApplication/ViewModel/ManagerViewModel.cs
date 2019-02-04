using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using BinaryTreeApplication.Annotations;
using BinaryTreeApplication.Model;
using BinaryTreeApplication.Services;

namespace BinaryTreeApplication.ViewModel
{
    public class ManagerViewModel : INotifyPropertyChanged
    {
        public BinaryTree<StudentTestRegister> Data { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IDialogService _dialogService;
        private readonly IFileService<StudentTestRegister> _fileService;

        private RelayCommand _readCommand;
        private RelayCommand _saveAsCommand;

        public ManagerViewModel() : this (new DialogService(), new FileService<StudentTestRegister>())
        {
        }

        public ManagerViewModel(IDialogService dialogService, IFileService<StudentTestRegister> fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
        }

        public RelayCommand ReadCommand
        {
            get
            {
                return _readCommand ?? (_readCommand = new RelayCommand(obj => ReadFile() ));
            }
        }

        public RelayCommand SaveAsCommand
        {
            get
            {
                return _saveAsCommand ?? (_saveAsCommand = new RelayCommand(obj => SaveAs() ));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ReadFile()
        {
            if (_dialogService.ShowOpenFileDialog() != true)
            {
                return;
            }

            try
            {
                Data = _fileService.Read(_dialogService.FilePath);
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

        private void SaveAs()
        {
            if (_dialogService.ShowSaveFileDialog() != true)
            {
                return;
            }
            try
            {
                _fileService.Save(_dialogService.FilePath, Data);
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
    }
}