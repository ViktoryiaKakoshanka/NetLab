using System;
using TriangleLib.Model;
using TriangleLib.Controller;

namespace TriangleLib.View
{
    class ConsoleView: IConsoleView
    {
        public void WarningMessage()
        {
            WriteLine("Вы ввели некорректное значение стороны треугольника.\nЗначение должно быть больше 0. ");
        }

        public void PrintPerimetrTriangle(double perimetr)
        {
            WriteLine($"Периметр треугольника:{perimetr}");
        }

        public void PrintAreaTriangle(double square)
        {
            WriteLine($"Площадь треугольника:{square}");
        }

        public void PrintDetailsTriangle(Triangle triangle)
        {
            WriteLine($"Стороны треугольника: {triangle.ToString()}");
            WriteLine($"Периметр треугольника: {TriangleCalculations.CalculateThePerimeter(triangle).ToString()}");
            WriteLine($"Площадь треугольника: {TriangleCalculations.CalculateTheArea(triangle).ToString()}");
        }

        public void WarningMessageTriangleNotExist()
        {
            WriteLine($"Такого треугольника не существует");
        }

        public void WriteLine(string text)
        {
            Console.WriteLine($"{text}");
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
