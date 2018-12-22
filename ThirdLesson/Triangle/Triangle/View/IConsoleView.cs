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
    }
}
