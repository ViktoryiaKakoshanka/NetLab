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

        public void ShowMessageErrorPassword() => WriteLine("You entered the wrong password!");

        public void SetCursorPosition(int left, int top) => Console.SetCursorPosition(left, top);

        public void ShowReadText(string text) => WriteLine($"Text from file:\n {text}");

        public string RequestPassword() => ReadLine("Enter the password to read the file.");

        public void ShowCurrentStatusRead(string percents, int numberLineToPrint)
        {
            SetCursorPosition(0, numberLineToPrint);
            WriteLine(percents + "%  ");
        }

        public void ShowVerticalLine(int nextPositionVerticalLine, int numberLineToPrint)
        {
            SetCursorPosition(nextPositionVerticalLine, numberLineToPrint);
            WriteLine("|");
        }

        public void ShowLastPercents(int numberLineToPrint)
        {
            SetCursorPosition(0, numberLineToPrint);
            WriteLine("100% ");
        }

        public void GoToLastLine(int numberLastLine) => SetCursorPosition(0, numberLastLine);
    }
}
