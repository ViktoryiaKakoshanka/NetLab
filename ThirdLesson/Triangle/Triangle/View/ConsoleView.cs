using System;
using TriangleLib.Model;

namespace TriangleLib.View
{
<<<<<<< HEAD
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
=======
    public class ConsoleView: IConsoleView
    {
        private const int Digits = 3;

        public string RequestInput(string welcomeMessage)
        {
            Console.WriteLine(welcomeMessage);
            return Console.ReadLine();
        }
        
        public void ShowTriangleDetails(Triangle triangle, double perimeter, double area)
        {
            Console.Clear();
            Console.WriteLine($"Sides of a triangle: {triangle}");
            Console.WriteLine($"Perimeter of a triangle: {Math.Round(perimeter, Digits)}");
            Console.WriteLine($"Area of a triangle: {Math.Round(area, Digits)}");
        }

        public void ShowMessageTriangleDoesNotExist()
        {
            Console.WriteLine("There is no such triangle.");
>>>>>>> RefactoringInLab
        }

        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
