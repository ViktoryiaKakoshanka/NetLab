using System;
using TriangleLib.Model;
using TriangleLib.Controller;

namespace TriangleLib.View
{
    class ConsoleView: IConsoleView
    {
        public void ShowWarningMessage()
        {
            WriteLine("You entered an incorrect value for the side of the triangle.\nThe value must be greater than 0. ");
        }

        public void PrintPerimetrTriangle(double perimetr)
        {
            WriteLine($"Perimeter of a triangle:{perimetr}");
        }

        public void PrintAreaTriangle(double square)
        {
            WriteLine($"Area of ​​a triangle:{square}");
        }

        public void PrintDetailsTriangle(Triangle triangle)
        {
            WriteLine($"Sides of a triangle: {triangle.ToString()}");
            WriteLine($"Perimeter of a triangle: {TriangleCalculations.CalculateThePerimeter(triangle).ToString()}");
            WriteLine($"Area of ​​a triangle: {TriangleCalculations.CalculateTheArea(triangle).ToString()}");
        }

        public void ShowWarningMessageTriangleNotExist()
        {
            WriteLine($"There is no such triangle.");
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
