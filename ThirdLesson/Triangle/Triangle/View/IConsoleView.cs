using System;

namespace TriangleLib.View
{
    public interface IConsoleView
    {
        void WriteLine(string text);
        string ReadLine();
        void Clear();
        ConsoleKeyInfo ReadKey();
    }
}
