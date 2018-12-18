using System;
using MatrixProject.Controller;
using MatrixProject.Model;
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

        private void PerformActions(Matrix first, Matrix second)
        {
            _view.ShowMatrix(first, "first");
            _view.ShowMatrix(second, "second");
            _view.ShowMatrix(MatrixHelper.Sum(first, second), "Sum");
            _view.ShowMatrix(MatrixHelper.Subtract(first, second), "Subtract");
            _view.ShowMatrix(MatrixHelper.Multiply(first, second), "Multiply");
        }

        private static Matrix InitializeMatrix(Random random,int numberLines, int numberColumns)
        {
            var array = new double[numberLines, numberColumns];
            for (var i = 0; i < numberLines; i++)
            {
                for (var j = 0; j < numberColumns; j++)
                {
                    array[i, j] = random.NextDouble() * 10;
                }
            }
            return new Matrix(array, numberLines, numberColumns);
        }
    }
}