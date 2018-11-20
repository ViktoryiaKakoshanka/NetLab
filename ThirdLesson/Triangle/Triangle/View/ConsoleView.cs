using System;

namespace TriangleLib.View
{
    class ConsoleView: IConsoleView
    {
        public void WriteLine(string text) => Console.WriteLine($"{text}");

        public string ReadLine() => Console.ReadLine();

        public void Clear() =>  Console.Clear();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
    }
}
