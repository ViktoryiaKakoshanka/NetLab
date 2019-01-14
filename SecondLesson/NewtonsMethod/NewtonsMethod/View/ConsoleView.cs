using System;

namespace NewtonsMethod.View
{
    public class ConsoleView : IView
    {
        public string RequestInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        public void ShowErrorMessageUserInput() => Console.WriteLine("You entered incorrect data");

        public void PrintNumberRoot(double number, int power, double result)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Newton's method is {power}√{number} = {result}");
            Console.ReadKey(true);
        }

        public void PrintCompareResult(int compareResult, double delta)
        {
            Console.WriteLine($"Delta = {delta}");

            if (compareResult > 0)
            {
                Console.WriteLine("The result calculated by the Newton method is greater than the result calculated by the built-in Math function.");
                return;
            }

            if (compareResult < 0)
            {
                Console.WriteLine("The result calculated by Newton's method is less than the result calculated by the built-in Math function.");
                return;
            }

            if (compareResult == 0)
            {
                Console.WriteLine("The result calculated by Newton's method is equal to the result calculated by the built-in Math function.");
            }
        }
    }
}
