using System;

namespace VectorProgram.View
{
    public class ConsoleView : IConsoleView
    {
        public void PressKeyToContinue() => Console.ReadKey(true);

        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string text) => Console.WriteLine(text);

        public void WriteErrorMessage() => Console.WriteLine("You entered incorrect numbers.");
    }
}
