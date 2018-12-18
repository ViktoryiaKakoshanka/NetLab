using System;
using MatrixProject.Model;

namespace MatrixProject.View
{
    public class ConsoleView : IView
    {
        public void ShowMatrix(Matrix matrix, string message = null)
        {
            Console.WriteLine(message);
            Console.WriteLine("Matrix: ");

            for (var i = 0; i < matrix.Lines; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Console.Write("{0,10:N1}", matrix.Array[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n");
        }
    }
}