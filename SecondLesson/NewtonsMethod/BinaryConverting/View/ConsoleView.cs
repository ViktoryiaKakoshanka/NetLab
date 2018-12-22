using BinaryConverting.Model;
using System;

namespace BinaryConverting.View
{
    public class ConsoleView : IView
    {
        public string RequestInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        public void ShowResultByConversion(INumbers number)
        {
            Console.WriteLine("Result:");
            Console.WriteLine($"Decimal number: {number.DecimalNumber}");
            Console.WriteLine($"Binary number: {number.BinaryNumber}");

<<<<<<< HEAD
<<<<<<< HEAD
            WaitForAnyKeyPress();
=======
            Console.ReadKey(true);
>>>>>>> RefactoringInLab
        }

        public void ShowWarningMessage(string messEx = null)
        {
            Console.Clear();
            Console.WriteLine($"{messEx} You must repeat the value entry. ");
        }

<<<<<<< HEAD
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
=======
        public void ShowMessageFormatException() => Console.WriteLine("Invalid format entered.");
>>>>>>> RefactoringInLab
    }
}