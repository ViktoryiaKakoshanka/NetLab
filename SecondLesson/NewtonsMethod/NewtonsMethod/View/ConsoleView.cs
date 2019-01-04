using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void WriteLine(string text) => Console.WriteLine(text);

        public void ShowErrorMessageUserInput() => Console.WriteLine("You entered incorrect data");

        public void PrintCompareResult(IRadicalSign radicalSign, double radicalSignMethodNewton, double radicalSignMathPow)
        {
            WriteLine(radicalSign.ToString());
            WriteLine($"Newton's method is {Math.Round(radicalSignMethodNewton, Digits)}");
            WriteLine("Check");
            WriteLine($"{radicalSign.Root} to degree {radicalSign.Power} equally {Math.Round(radicalSignMathPow, Digits)}");
            Console.ReadKey(true);
        }
    }
}
