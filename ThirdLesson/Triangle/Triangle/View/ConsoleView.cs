using System;

namespace TriangleLib.View
{
    public class ConsoleView : IConsoleView
    {
        private const int DIGITS = 6;

        public ConsoleKey KeyEnter => ConsoleKey.Enter;

        public void WriteLine(string text) => Console.WriteLine($"{text}");

        public string ReadLine() => Console.ReadLine();

        public void Clear() => Console.Clear();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();

        public void ShowWarningMessage()
        {
            WriteLine($"You entered an incorrect value for the side of the triangle.{Environment.NewLine}The value must be greater than 0. ");
        }

        public void ShowPerimetrTriangle(double perimetr)
        {
            WriteLine($"Perimeter of a triangle: {perimetr}");
        }

        public void ShowAreaTriangle(double square)
        {
            WriteLine($"Area of ​​a triangle: {square}");
        }

        public void ShowDetailsTriangle(string triangle, double perimeter, double area)
        {
            WriteLine($"Sides of a triangle: {triangle}");
            WriteLine($"Perimeter of a triangle: {perimeter}");
            WriteLine($"Area of ​​a triangle: {Math.Round(area, DIGITS)}");
        }

        public void ShowWarningMessageTriangleNotExist()
        {
            WriteLine("There is no such triangle.");
        }
    }
}
