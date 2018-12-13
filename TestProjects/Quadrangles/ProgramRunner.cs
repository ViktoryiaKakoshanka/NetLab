using System;
using System.Collections.Generic;

namespace Quadrangles
{
    internal class ProgramRunner
    {
        public void Run()
        {
            var listFigure = new List<Figure>
            {
                new Square(2, 2, 2, 2),
                new Rectangle(2, 4, 2, 4),
                new Parallelogram(7, 5, 7, 5, 5),
                new Rhombus(10, 10, 10, 10, 12, 16),
                new Trapezoid(2, 5, 2, 3.61, 2)
            };

            foreach (var figure in listFigure)
            {
                Console.WriteLine($"{figure.GetType()}:\nPerimeter = {Math.Round(figure.CalculatePerimeter(), 2)}");
                Console.WriteLine($"Square = {Math.Round(figure.CalculateSquare(), 2)} \n");
            }
        }
    }
}
