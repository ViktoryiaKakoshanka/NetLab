using System;
using BinaryConverting.Model;

namespace BinaryConverting.View
{
    class ConsoleView: IConsoleView
    {
        public void PrintResultByConversion(INumbers number)
        {
            Console.WriteLine("Result:");
            Console.WriteLine($"Decimal number:{number.DecimalNumber}");
            Console.WriteLine($"Binary number:{number.BinaryNumber}");

            Console.ReadKey(true);
        }

        public void WarningMessage(string messEx = null)
        {
            Console.Clear();
            Console.WriteLine($"{messEx} You must repeat the value entry. ");
        }
    }
}
