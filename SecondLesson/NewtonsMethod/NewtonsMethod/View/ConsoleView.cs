using System;

namespace NewtonsMethod.View
{
    public class ConsoleView : IView
    {
        public ConsoleView()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public string RequestInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        public void ShowErrorMessageUserInput() => Console.WriteLine("You entered incorrect data");
        
        public void PrintCompareResult(double number, int rootPower, double rootNewton, double rootMath)
        {
            Console.WriteLine($"rootNewton:");
            PrintNumberRoot(number, rootPower, rootNewton);

            Console.WriteLine($"rootMath:");
            PrintNumberRoot(number, rootPower, rootMath);
        }

        private static void PrintNumberRoot(double number, int rootPower, double result)
        {
            Console.WriteLine($"{rootPower}√{number} = {result}");
        }
    }
}
