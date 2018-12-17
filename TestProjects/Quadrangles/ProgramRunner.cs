using System;
using System.Collections.Generic;

namespace Quadrangles
{
    internal class ProgramRunner
    {
        public void Run()
        {
            var listFigure = new List<Quadrangle>
            {
                new Square(9),
                new Rectangle(2, 4),
                new Parallelogram(7, 5, 5),
                new Rhombus(10, 16),
                new Trapezoid(6, 4, 4, 6)
            };

            foreach (var figure in listFigure)
            {
                Console.WriteLine($"{figure.GetType()}:\nPerimeter = {Math.Round(figure.CalculatePerimeter(), 2)}");
                Console.WriteLine($"Square = {Math.Round(figure.CalculateSquare(), 2)} \n");
            }
        }
    }
}