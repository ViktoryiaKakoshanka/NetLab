using System;

namespace TriangleLib.View
{
    public class ConsoleView: IConsoleView
    {
        public ConsoleKey keyEnter { get => ConsoleKey.Enter; }

        public void WriteLine(string text) => Console.WriteLine($"{text}");

        public string ReadLine() => Console.ReadLine();

        public void Clear() =>  Console.Clear();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
    }
}
