using System;
using TriangleLib.Model;

namespace TriangleLib.View
{
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
        }

        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
