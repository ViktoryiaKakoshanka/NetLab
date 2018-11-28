using System;

namespace TriangleLib.View
{
    public interface IConsoleView
    {
        ConsoleKey keyEnter { get; }
        void WriteLine(string text);
        string ReadLine();
        void Clear();
        ConsoleKeyInfo ReadKey();
    }
}
