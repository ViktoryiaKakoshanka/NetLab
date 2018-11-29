using System;

namespace DecoratorStream.View
{
    public class ConsoleView : IConsoleView
    {
        public void WaitForAnyKeyPress()
        {
            WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string text) => Console.WriteLine(text);

        public void ShowMessageErrorPassword()
        {
            WriteLine("You entered the wrong password");
        }
    }
}
