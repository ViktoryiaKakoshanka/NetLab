using System;
using NewtonsMethod.Model;

namespace NewtonsMethod.View
{
    public class ConsoleView : IView
    {
        private const int Digits = 5;

        public string RequestInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        public void ShowErrorMessageUserInput() => Console.WriteLine("You entered incorrect data");

        public void PrintCompareResult(RadicalSign radicalSign, double radicalSignMethodNewton, double radicalSignMathPow)
        {
            Console.WriteLine(radicalSign.ToString());
            Console.WriteLine($"Newton's method is {Math.Round(radicalSignMethodNewton, Digits)}");
            Console.WriteLine("Check");
            Console.WriteLine($"{radicalSign.Root} to degree {radicalSign.Power} equally {Math.Round(radicalSignMathPow, Digits)}");
            Console.ReadKey(true);
        }
    }
}
