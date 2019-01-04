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

            Console.ReadKey(true);
        }

        public void ShowWarningMessage(string messEx = null)
        {
            Console.Clear();
            Console.WriteLine($"{messEx} You must repeat the value entry. ");
        }

        public void ShowMessageFormatException() => Console.WriteLine("Invalid format entered.");
    }
}