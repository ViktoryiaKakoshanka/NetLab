using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Markup;
using BinaryTreeApplication.Annotations;
using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.ViewModel
{
    public class ManagerViewModel : INotifyPropertyChanged
    {
        private readonly DialogService _dialogService;
        private readonly FileService<List<StudentTestRegister>> _fileService;

        private RelayCommand _openCommand;
        private RelayCommand _saveAsCommand;


        public BinaryTree<List<StudentTestRegister>> Data
        {
            get;
            set;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ManagerViewModel(DialogService dialogService, FileService<List<StudentTestRegister>> fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ?? (_openCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (_dialogService.OpenFileDialog() != true)
                        {
                            return;
                        }

                        Data = _fileService.Open(_dialogService.FilePath);
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
                }));
            }
        }

        public RelayCommand SaveAs
        {
            get
            {
                return _saveAsCommand ?? (_saveAsCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (_dialogService.SaveFileDialog() != true)
                        {
                            return;
                        }

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
                }));
            }
        }










        public void Qwe()
        {
            var tests = CreateCatalogTests();
            var students = CreateCatalogStudents();
            var registers = CreateCatalogRegisters(tests, students);

           //var qwe = students.OrderBy(x => x.Name);
            
            var groupByMarks = registers.GroupBy(r => r.Mark)
                                        .Select(x => new
                                        {
                                            Mark = x.Key,
                                            Data = x.Select(q => q).ToList()
                                        });

            var tree = new BinaryTree<List<StudentTestRegister>>();

            foreach (var item in groupByMarks)
            {
                tree.Insert(item.Mark, item.Data);
            }

            //Data = tree;

            if (_dialogService.SaveFileDialog() != true)
            {
                return;
            }

            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(_dialogService.FilePath, FileMode.Create))
            {
                formatter.Serialize(fileStream, tree);
            }


            if (_dialogService.OpenFileDialog() != true)
            {
                return;
            }

            using (var fileStream = new FileStream(_dialogService.FilePath, FileMode.Open))
            {
                Data = (BinaryTree<List<StudentTestRegister>>)formatter.Deserialize(fileStream);
            }
            
            //var mark3 = tree.Find(3).Value.Select(x=> string.Concat(x.Student.Name, " => ", x.TestPassed.Name, " => ", x.Mark).ToString());

        }


        private static IList<Student> CreateCatalogStudents()
        {
            var catalogStudents = new List<Student>
            {
                new Student(Guid.NewGuid(), "Alice"),
                new Student(Guid.NewGuid(), "Alex"),
                new Student(Guid.NewGuid(), "Serge"),
                new Student(Guid.NewGuid(), "Max"),
                new Student(Guid.NewGuid(), "Victor"),
                new Student(Guid.NewGuid(), "Mia")
            };
            return catalogStudents;
        }

        private static IList<Test> CreateCatalogTests()
        {
            var catalogTests = new List<Test>
            {
                new Test(Guid.NewGuid(), "DataBase"),
                new Test(Guid.NewGuid(), "Algorithms"),
                new Test(Guid.NewGuid(), "Math")
            };
            return catalogTests;
        }

        private static IEnumerable<StudentTestRegister> CreateCatalogRegisters(IList<Test> tests, IList<Student> students)
        {
            var random = new Random();
            return students.Select(student => new StudentTestRegister(tests[0], student, DateTime.Today, random.Next(1, 10))).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}