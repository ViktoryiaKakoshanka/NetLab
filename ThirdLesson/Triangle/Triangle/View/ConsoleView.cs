using System;
using TriangleLib.Model;
using TriangleLib.Controller;

namespace TriangleLib.View
{
    class ConsoleView: IConsoleView
    {
        public void WarningMessage()
        {
            Console.WriteLine("Вы ввели некорректное значение стороны треугольника.\nЗначение должно быть больше 0. ");
        }

        public void PrintPerimetrTriangle(double perimetr)
        {
            Console.WriteLine($"Периметр треугольника:{perimetr}");
        }

        public void PrintAreaTriangle(double square)
        {
            Console.WriteLine($"Площадь треугольника:{square}");
        }

        public void PrintDetailsTriangle(Triangle triangle)
        {
            Console.WriteLine($"Стороны треугольника: {triangle.ToString()}");
            Console.WriteLine($"Периметр треугольника: {TriangleCalculations.CalculateThePerimeter(triangle).ToString()}");
            Console.WriteLine($"Площадь треугольника: {TriangleCalculations.CalculateTheArea(triangle).ToString()}");
        }

        public void WarningMessageTriangleNotExist()
        {
            Console.WriteLine($"Такого треугольника не существует");
        }
    }
}
