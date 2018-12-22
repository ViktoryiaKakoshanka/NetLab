using System;

namespace TriangleLib.View
{
<<<<<<< HEAD
    public class ConsoleView: IConsoleView, ITriangleView
    {
        private const int Digits = 6;
=======
    public class ConsoleView : IConsoleView
    {
        private const int DIGITS = 6;

>>>>>>> master
        public ConsoleKey KeyEnter => ConsoleKey.Enter;

        public void WriteLine(string text) => Console.WriteLine($"{text}");

        public string ReadLine() => Console.ReadLine();

        public void Clear() => Console.Clear();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
<<<<<<< HEAD
        
=======

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

>>>>>>> master
        public void ShowDetailsTriangle(string triangle, double perimeter, double area)
        {
            WriteLine($"Sides of a triangle: {triangle}");
            WriteLine($"Perimeter of a triangle: {perimeter}");
<<<<<<< HEAD
            WriteLine($"Area of ​​a triangle: {Math.Round(area, Digits)}");
=======
            WriteLine($"Area of ​​a triangle: {Math.Round(area, DIGITS)}");
>>>>>>> master
        }

        public void ShowWarningMessageTriangleNotExist()
        {
            WriteLine("There is no such triangle.");
        }
    }
}
