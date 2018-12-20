using BinaryConverting.Model;
using System;

namespace BinaryConverting.View
{
    public class ConsoleView : IView
    {
        public string ReadInput(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }
        
        public void ShowResultByConversion(INumbers number)
        {
            WriteLine("Result:");
            WriteLine($"Decimal number:{number.DecimalNumber}");
            WriteLine($"Binary number:{number.BinaryNumber}");

            WaitForAnyKeyPress();
        }

        public void ShowWarningMessage(string messEx = null)
        {
            Clear();
            WriteLine($"{messEx} You must repeat the value entry. ");
        }

        public void ShowMessageFormatException() => WriteLine("Invalid format entered.");

        public void ShowMessageArgumentNullException() => WriteLine("The value entered is empty.");

        private static void WriteLine(string text) => Console.WriteLine(text);

        private static void WaitForAnyKeyPress() => Console.ReadKey(true);

        private static void Clear() => Console.Clear();
    }
}
