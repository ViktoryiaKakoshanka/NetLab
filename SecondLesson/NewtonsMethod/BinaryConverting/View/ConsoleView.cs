using System;

namespace BinaryConverting.View
{
    class ConsoleView : IConsoleView
    {
        public void Clear() => Console.Clear();

        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public string ReadLine() => Console.ReadLine();

        public void WaitForAnyKeyPress() => Console.ReadKey(true);
        
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
