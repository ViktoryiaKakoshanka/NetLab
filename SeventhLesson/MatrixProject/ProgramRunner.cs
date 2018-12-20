using System;
using MatrixProject.Controller;
using MatrixProject.View;

namespace MatrixProject
{
    public class ProgramRunner
    {
        private readonly IView _view;

        public ProgramRunner(IView view)
        {
            _view = view;
        }

        public void Run()
        {
            var random = new Random();
            var first = ProgramRunnerHelper.InitializeMatrix(random, 2, 2);
            var second = ProgramRunnerHelper.InitializeMatrix(random, 2, 2);
            
            PerformActions(first, second);
        }

        private void PerformActions(double[,] first, double[,] second)
        {
            _view.ShowMatrix(first, "first");
            _view.ShowMatrix(second, "second");
            _view.ShowMatrix(first.AddMatrix(second), "Sum");
            _view.ShowMatrix(first.SubtractMatrix(second), "Subtract");
            _view.ShowMatrix(first.MultiplyByMatrix(second), "Multiply");
        }
    }
}