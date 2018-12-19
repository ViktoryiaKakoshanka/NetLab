using System;

namespace DecoratorStream.View
{
    public class ConsoleView : IView
    {
        private int _currentProgress;

        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public void NotifyWrongPassword() => Console.WriteLine("You entered the wrong password!");
        
        public string RequestPassword() => ReadLine("Enter the password to read the file.");

        public void ShowCurrentStatusInPercent(int percents, int numberLineToPrint)
        {
            SetCursorPosition(0, numberLineToPrint);
            Console.WriteLine($"{percents}%  ");
        }
        
        public void FinishRead()
        {
            SetCursorPosition(0, Console.CursorTop + 2);
        }

        public void UpdateProgressBar(int currentProgress)
        {
            for (var position = _currentProgress; position < currentProgress; position++)
            {
                SetCursorPosition(position, 3);
                Console.WriteLine('|');
            }

            _currentProgress = currentProgress;
        }

        private static void SetCursorPosition(int left, int top) => Console.SetCursorPosition(left, top);

        private static string ReadLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
