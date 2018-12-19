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
            var first = InitializeMatrix(random, 2, 2);
            var second = InitializeMatrix(random, 2, 2);
            
            PerformActions(first, second);
        }

        private void PerformActions(double[,] first, double[,] second)
        {
            _view.ShowMatrix(first, "first");
            _view.ShowMatrix(second, "second");
            _view.ShowMatrix(first.AddArray(second), "Sum");
            _view.ShowMatrix(first.SubtractArray(second), "Subtract");
            _view.ShowMatrix(first.MultiplyArray(second), "Multiply");
        }

        private static double[,] InitializeMatrix(Random random,int numberLines, int numberColumns)
        {
            var matrix = new double[numberLines, numberColumns];
            for (var i = 0; i < numberLines; i++)
            {
                for (var j = 0; j < numberColumns; j++)
                {
                    matrix[i, j] = random.NextDouble() * 10;
                }
            }
            return matrix;
        }
    }
}