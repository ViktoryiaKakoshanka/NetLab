using System;

namespace TriangleLib.View
{
    public interface IConsoleView
    {
        ConsoleKey KeyEnter { get; }
        void WriteLine(string text);
        string ReadLine();
        void Clear();
        ConsoleKeyInfo ReadKey();
        void ShowWarningMessage();
        void ShowPerimetrTriangle(double perimetr);
        void ShowAreaTriangle(double square);
        void ShowDetailsTriangle(string triangle, double perimeter, double area);
        void ShowWarningMessageTriangleNotExist();
    }
}
