using System;

namespace MatrixProject.View
{
    public class ConsoleView : IView
    {
        public void ShowMatrix(double[,] matrix, string message = null)
        {
            Console.WriteLine(message);
            Console.WriteLine("Matrix: ");

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,10:N1}", matrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n");
        }
    }
}