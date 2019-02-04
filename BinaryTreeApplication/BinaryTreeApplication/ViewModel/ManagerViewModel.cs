using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
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

        public BinaryTree<StudentTestRegister> TestTree1 { get; set; }
        
        public string nameStudent { get; set; }

        class TestStudent
        {
            public string Name { get; set; }
            public int Group { get; set; }
            public int Mark { get; set; }

            public TestStudent(string name, int @group, int mark)
            {
                Name = name;
                Group = group;
                Mark = mark;
            }
        }

        public void TestStudents()
        {
            var students12 = new List<TestStudent>()
            {
                new TestStudent("St1", 1, 2),
                new TestStudent("St1", 2, 9),
                new TestStudent("St1", 1, 2),
                new TestStudent("St1", 3, 9),
                new TestStudent("St1", 2, 5),
                new TestStudent("St1", 1, 7),
                new TestStudent("St1", 3, 5),
                new TestStudent("St1", 1, 2),
                new TestStudent("St1", 2, 3),
                new TestStudent("St1", 1, 1),
                new TestStudent("St1", 1, 2),
            };

            var a = students12.GroupBy(s => s.Group).Select(g => new
            {
                Group = g.Key,
                AverageMark = g.Average(s => s.Mark)
            });
        }


        public void Qwe()
        {
            var tests = CreateCatalogTests();
            var students = CreateCatalogStudents();
            var registers = CreateCatalogRegisters(tests, students);

            TestTree1 = TestTree();

            //var qwe = students.OrderBy(x => x.NameStudent);

            var groupByMarks = registers.GroupBy(r => r.Mark)
                                        .Select(x => new
                                        {
                                            Mark = x.Key,
                                            Data = x.Select(q => q).ToList()
                                        });
            var groupByMarks1 = registers.GroupBy(r => r.Mark)
                .Select(x => new
                {
                    Mark = x.Key,
                    Data = x.GroupBy(g => g.TestPassed.Name).Select(q => new
                        {
                            Test = q.Key,
                            Stud = q.Select(a => a.Date + " - " + a.Student.Name)
                        })
                });
            var eee = new StringBuilder();
            foreach (var markData in groupByMarks1)
            {
                foreach (var testStudents in markData.Data)
                {
                    foreach (var testStudent in testStudents.Stud)
                    {
                        eee.Append($"\n {markData.Mark} = {testStudents.Test} = {testStudent}");
                    }
                }
            }

            var tree = new BinaryTree<List<StudentTestRegister>>();

            MessageBox.Show(eee.ToString());

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
            
            //var mark3 = tree.Find(3).Value.Select(x=> string.Concat(x.Student.NameStudent, " => ", x.TestPassed.NameStudent, " => ", x.Mark).ToString());

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

        private static IList<StudentTestRegister> CreateCatalogRegisters(IList<Test> tests, IList<Student> students)
        {
            var qqq = new List<StudentTestRegister>();
            var random = new Random();
            qqq.AddRange(from test in tests from student in students select new StudentTestRegister(test, student, DateTime.Today, random.Next(3, 7)));

            return qqq;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BinaryTree<StudentTestRegister> TestTree()
        {
            var tree = new BinaryTree<StudentTestRegister>(3,
                new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"),
                    DateTime.Today, 3));
            tree.Insert(5, new StudentTestRegister(
                            new Test(new Guid(), "DataBase"), 
                            new Student(new Guid(), "Alex"),
                            DateTime.Today, 5));
            tree.Insert(2, new StudentTestRegister(
                            new Test(new Guid(), "DataBase"), 
                            new Student(new Guid(), "Alex"),
                            DateTime.Today, 2));
            tree.Insert(9, new StudentTestRegister(
                            new Test(new Guid(), "DataBase"), 
                            new Student(new Guid(), "Alex"),
                            DateTime.Today, 9));
            tree.Insert(7, new StudentTestRegister(
                            new Test(new Guid(), "DataBase"), 
                            new Student(new Guid(), "Alex"),
                            DateTime.Today, 7));
            
            return tree;
        }

    }
}