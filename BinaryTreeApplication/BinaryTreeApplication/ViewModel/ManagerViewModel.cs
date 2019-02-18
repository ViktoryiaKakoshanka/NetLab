using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using BinaryTreeApplication.Annotations;
using BinaryTreeApplication.Helpers;
using BinaryTreeApplication.Model;
using BinaryTreeApplication.Services;

namespace BinaryTreeApplication.ViewModel
{
    public class ManagerViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;
        private readonly IFileService<Register> _fileService;

        private RelayCommand _readTreeCommand;
        private RelayCommand _saveAsTreeCommand;
        private RelayCommand _findMarkCommand;
        private RelayCommand _showAllPointsCommand;
        private RelayCommand _showRecordsDependingOnNumberCommand;
        private RelayCommand _generateRegistersCommand;

        private List<Register> _registers;
        private List<Register> _displayedRegisters;

        public List<Register> DisplayedRegisters
        {
            get => _displayedRegisters;
            set
            {
                _displayedRegisters = value;
                OnPropertyChanged();
            }
        }

        public int MarkForSearch { private get; set; }
        public int NumberOfRecords { get; set; }

        public int SelectedColumnHeader { get; set; }
        public ObservableCollection<string> ColumnHeaders { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        

        public ManagerViewModel() : this (new DialogService(), new FileService<Register>())
        {
        }

        public ManagerViewModel(IDialogService dialogService, IFileService<Register> fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
            ColumnHeaders = ManagerViewModelHelper.GenerateNamesOfFields();
        }

        public RelayCommand ReadCommand
        {
            get { return _readTreeCommand ?? (_readTreeCommand = new RelayCommand(obj => { ReadFile(); })); }
        }

        public RelayCommand SaveAsCommand
        {
            get { return _saveAsTreeCommand ?? (_saveAsTreeCommand = new RelayCommand(obj => SaveAs())); }
        }

        public RelayCommand FindMarkCommand
        {
            get { return _findMarkCommand ?? (_findMarkCommand = new RelayCommand(obj => FindMark())); }
        }

        public RelayCommand ShowAllPointsCommand
        {
            get { return _showAllPointsCommand ?? (_showAllPointsCommand = new RelayCommand(obj => ShowAllRecords())); }
        }

        public RelayCommand ShowRecordsDependingOnNumberCommand
        {
            get
            {
                return _showRecordsDependingOnNumberCommand ?? (_showRecordsDependingOnNumberCommand =
                           new RelayCommand(obg => ShowRecordsDependingOnNumber()));
            }
        }

        public RelayCommand GenerateRegistersCommand
        {
            get
            {
                return _generateRegistersCommand ?? (_generateRegistersCommand = new RelayCommand(obj =>
                           {
                               FillDataDisplayed(ManagerViewModelHelper.GenerateDataTree());
                           }));
            }
        }

        public RelayCommand MoveUpFieldCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SelectedColumnHeader == 0)
                    {
                        return;
                    }

                    ColumnHeaders.Move(SelectedColumnHeader, SelectedColumnHeader - 1);
                });
            }
        }

        public RelayCommand MoveDownFieldCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (ColumnHeaders.Count == SelectedColumnHeader + 1)
                    {
                        return;
                    }

                    ColumnHeaders.Move(SelectedColumnHeader, SelectedColumnHeader + 1);
                });
            }
        }

        public RelayCommand SortByColumnsCommand
        {
            get { return new RelayCommand(obj => SortByColumns()); }
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
                FillDataDisplayed(_fileService.Read(_dialogService.FilePath));
            }
            catch (IOException e)
            {
                _dialogService.ShowMessage($"{e.Message}\nChoose another file");
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage($"An error has occurred.\n{e.Message}");
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
                _fileService.Save(_dialogService.FilePath, _registers.ToTree());
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

        private void FindMark()
        {
            DisplayedRegisters = DisplayedRegisters.FindAll(s => s.Mark == MarkForSearch);
        }

        private void ShowAllRecords()
        {
            DisplayedRegisters = _registers;
        }

        private void ShowRecordsDependingOnNumber()
        {
            if (NumberOfRecords > 0)
            {
                DisplayedRegisters = _registers.Take(NumberOfRecords).ToList();
                return;
            }

            ShowAllRecords();
        }

        private void SortByColumns()
        {
           var orderedRegisters = DisplayedRegisters.OrderBy(register => RegisterHelper.GetProperty(register, ColumnHeaders[0]));
           
           foreach (var nameProperty in ColumnHeaders.Skip(1))
           {
               orderedRegisters.ThenBy(s => RegisterHelper.GetProperty(s, nameProperty));
           }

           DisplayedRegisters = orderedRegisters.ToList();
        }
        
        private void FillDataDisplayed(BinaryTree<Register> tree)
        {
            _registers = tree.ToList();
            DisplayedRegisters = _registers;
        }
    }
}