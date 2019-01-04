using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BinaryTreeApplication.Model;
using BinaryTreeApplication.ViewModel;

namespace BinaryTreeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           var a = new ManagerViewModel(new DialogService(), new FileService<List<StudentTestRegister>>());
           DataContext = a;

           a.Qwe();

           var tree1 = new BinaryTree<StudentTestRegister>(3, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 3));
           tree1.Insert(5, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 5));
           tree1.Insert(2, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 2));
           tree1.Insert(9, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 9));
           tree1.Insert(7, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 7));


            var tree = new ObservableCollection<BinaryTree<StudentTestRegister>>()
           {
               new BinaryTree<StudentTestRegister>(3, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 3)),
               new BinaryTree<StudentTestRegister>(tree1.Insert(5, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 5))),
               new BinaryTree<StudentTestRegister>(tree1.Insert(1, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 5))),
               new BinaryTree<StudentTestRegister>(tree1.Insert(9, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 5))),
               new BinaryTree<StudentTestRegister>(tree1.Insert(6, new StudentTestRegister(new Test(new Guid(), "DataBase"), new Student(new Guid(), "Alex"), DateTime.Today, 5))),
           };
        }

    }
}
