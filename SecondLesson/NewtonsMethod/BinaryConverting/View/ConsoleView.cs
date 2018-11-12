using System;
using BinaryConverting.Model;

namespace BinaryConverting.View
{
    class ConsoleView: IConsoleView
    {
        public void ShowResultByConversion(INumbers number)
        {
            Console.WriteLine("Result:");
            Console.WriteLine($"Decimal number:{number.DecimalNumber}");
            Console.WriteLine($"Binary number:{number.BinaryNumber}");

            Console.ReadKey(true);
        }

        public void ShowWarningMessage(string messEx = null)
        {
            Console.Clear();
            Console.WriteLine($"{messEx} You must repeat the value entry. ");
        }
    }
}
