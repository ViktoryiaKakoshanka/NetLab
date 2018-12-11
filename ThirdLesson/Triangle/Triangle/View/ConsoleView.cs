using System;

namespace TriangleLib.View
{
    public class ConsoleView: IConsoleView, ITriangleView
    {
        private const int Digits = 6;
        public ConsoleKey KeyEnter => ConsoleKey.Enter;

        public void WriteLine(string text) => Console.WriteLine($"{text}");

        public string ReadLine() => Console.ReadLine();

        public void Clear() =>  Console.Clear();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
        
        public void ShowDetailsTriangle(string triangle, double perimeter, double area)
        {
            WriteLine($"Sides of a triangle: {triangle}");
            WriteLine($"Perimeter of a triangle: {perimeter}");
            WriteLine($"Area of ​​a triangle: {Math.Round(area, Digits)}");
        }

        public void ShowWarningMessageTriangleNotExist()
        {
            WriteLine("There is no such triangle.");
        }
    }
}
