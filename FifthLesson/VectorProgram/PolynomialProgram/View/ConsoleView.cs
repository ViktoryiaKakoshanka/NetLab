using System;
using VectorProgram.View;

namespace PolynomialProgram.View
{
    public class ConsoleView : IConsoleView
    {
        //todo: rename
        public void ReadKey() => Console.ReadKey(true);

        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string text) => Console.WriteLine(text);

        public void WriteErrorMessage() => Console.WriteLine("You entered incorrect numbers.");
    }
}
