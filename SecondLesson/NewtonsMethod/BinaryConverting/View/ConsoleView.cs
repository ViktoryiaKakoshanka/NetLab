using BinaryConverting.Model;
using System;

namespace BinaryConverting.View
{
    public class ConsoleView : IConsoleView, IConvertingView
    {
        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }
        
        public void ShowResultByConversion(INumbers number)
        {
            WriteLine("Result:");
            WriteLine($"Decimal number:{number.DecimalNumber}");
            WriteLine($"Binary number:{number.BinaryNumber}");

<<<<<<< HEAD
            WaitForAnyKeyPress();
        }

        public void ShowWarningMessageForRepeat(string messEx = null)
        {
            Clear();
            WriteLine($"{messEx} You must repeat the value entry. ");
        }

        public void ShowMessageFormatException() => WriteLine("Invalid format entered.");

        public void ShowMessageArgumentNullException() => WriteLine("The value entered is empty.");

        private static void WriteLine(string text) => Console.WriteLine(text);

        private static void WaitForAnyKeyPress() => Console.ReadKey(true);

        private static void Clear() => Console.Clear();
=======
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
>>>>>>> master
    }
}
