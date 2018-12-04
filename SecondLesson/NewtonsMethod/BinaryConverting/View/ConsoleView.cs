using System;

namespace BinaryConverting.View
{
    class ConsoleView : IConsoleView
    {
        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string text) => Console.WriteLine(text);

        public string ReadLine() => Console.ReadLine();

        public void WaitForAnyKeyPress()
        {
            WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public void ShowConvertionResult(int number, string binaryNumber)
        {
            WriteLine("Result:");
            WriteLine($"Decimal number: {number}");
            WriteLine($"Binary number: {binaryNumber}");
        }

        public void ShowWarningMessageForRepeat(string messEx = null)
        {
            Console.Clear();
            WriteLine($"{messEx} You must repeat the value entry. ");
        }

        public void ShowMessageFormatException() => WriteLine("Invalid number format.");

        public void ShowMessageArgumentNullException() => WriteLine("Entered value is empty.");
    }
}
