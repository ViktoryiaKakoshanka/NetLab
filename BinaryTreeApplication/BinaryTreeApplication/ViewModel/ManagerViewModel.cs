using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using BinaryTreeApplication.Annotations;
using BinaryTreeApplication.Model;
using BinaryTreeApplication.Services;

namespace BinaryTreeApplication.ViewModel
{
    public class ManagerViewModel : INotifyPropertyChanged
    {
        private BinaryTree<StudentTestRegister> _tree;
        private List<StudentTestRegister> _readData;
        private List<StudentTestRegister> _dataDisplayed;

        public int MarkForSearch { private get; set; }

        public List<StudentTestRegister> DataDisplayed
        {
            get { return _dataDisplayed; }
            set
            {
                _dataDisplayed = value;
                OnPropertyChanged();
            }
        }

        public List<string> ColumnHeaders { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IDialogService _dialogService;
        private readonly IFileService<StudentTestRegister> _fileService;

        private RelayCommand _readCommand;
        private RelayCommand _saveAsCommand;
        private RelayCommand _findMarkCommand;

        public ManagerViewModel() : this (new DialogService(), new FileService<StudentTestRegister>())
        {
        }

        public ManagerViewModel(IDialogService dialogService, IFileService<StudentTestRegister> fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
            //GenerateDataTree();
            GenerateNamesOfFields();
        }

        public RelayCommand ReadCommand
        {
            get
            {
                return _readCommand ?? (_readCommand = new RelayCommand(obj =>
                {
                    ReadFile();
                }));
            }
        }

        public RelayCommand SaveAsCommand { get { return _saveAsCommand ?? (_saveAsCommand = new RelayCommand(obj => SaveAs())); } }

        public RelayCommand FindMarkCommand
        {
            get
            {
                return _findMarkCommand ?? (_findMarkCommand = new RelayCommand(obj => FindMark()));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FindMark()
        {
            DataDisplayed = _readData?.FindAll(s => s.Mark == MarkForSearch);
        }

        private void SortByColumns()
        {
            
        }

        private void ReadFile()
        {
            if (_dialogService.ShowOpenFileDialog() != true)
            {
                return;
            }

            try
            {
                _tree = _fileService.Read(_dialogService.FilePath);
                _readData = _tree.ToList();
                DataDisplayed = _readData;
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
                _fileService.Save(_dialogService.FilePath, _tree);
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
        
        private void GenerateDataTree()
        {
            _tree = new BinaryTree<StudentTestRegister>(StudentTestRegister.GenerateNewRegister());
            for (var i = 0; i < 15; i++)
            {
                _tree.Insert(StudentTestRegister.GenerateNewRegister());
            }
        }

        private void GenerateNamesOfFields()
        {
            ColumnHeaders = new List<string>();
            var a = StudentTestRegister.GenerateNewRegister();
            ColumnHeaders.Add(nameof(a.TestName));
            ColumnHeaders.Add(nameof(a.Student));
            ColumnHeaders.Add(nameof(a.Date));
            ColumnHeaders.Add(nameof(a.Mark));
        }
    }
}