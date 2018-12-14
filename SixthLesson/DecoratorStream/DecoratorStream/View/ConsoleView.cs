using System;

namespace DecoratorStream.View
{
    public class ConsoleView : IView
    {
        public void Exit()
        {
            WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public void ShowMessageErrorPassword() => WriteLine("You entered the wrong password!");
        
        public string RequestPassword() => ReadLine("Enter the password to read the file.");

        public void ShowCurrentStatusInPercent(string percents, int numberLineToPrint)
        {
            SetCursorPosition(0, numberLineToPrint);
            WriteLine(percents + "%  ");
        }

        public void DrawSymbol(int nextPositionVerticalLine, int numberLineToPrint, char symbol)
        {
            SetCursorPosition(nextPositionVerticalLine, numberLineToPrint);
            WriteLine(symbol.ToString());
        }

        public void FinishRead()
        {
            SetCursorPosition(0, Console.CursorTop + 2);
        }

        private static void SetCursorPosition(int left, int top) => Console.SetCursorPosition(left, top);

        private static string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        private static void WriteLine(string text) => Console.WriteLine(text);
    }
}
