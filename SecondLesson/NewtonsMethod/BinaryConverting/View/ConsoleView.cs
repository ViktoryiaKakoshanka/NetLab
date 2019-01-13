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
        
        public void ShowResultByConversion(int decimalNumber, string binaryNumber)
        {
            Console.WriteLine("Result:");
            Console.WriteLine($"Decimal number: {decimalNumber}");
            Console.WriteLine($"Binary number: {binaryNumber}");

            Console.ReadKey(true);
        }

        public void ShowWarningMessage(string messEx = null)
        {
            Console.Clear();
            Console.WriteLine($"{messEx} You must repeat the value entry. ");
        }
    }
}