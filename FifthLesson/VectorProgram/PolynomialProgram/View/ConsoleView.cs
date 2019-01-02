using PolynomialProgram.Model;
using System;

namespace PolynomialProgram.View
{
    public class ConsoleView : IView
    {
        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public string RequestInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void ShowErrorMessage() => Console.WriteLine("You entered incorrect numbers.");

        public void ShowPolynomials(Polynomial first, Polynomial second)
        {
            Console.WriteLine("Your polynomials:\n");
            Console.WriteLine(first.ToString());
            Console.WriteLine(second.ToString());
        }

        public void ShowResultsOfPolynomialSum(
            Polynomial first,
            Polynomial second,
            Polynomial sumResult,
            Polynomial differenceResult)
        {
            Console.WriteLine($"{first} + {second} = {sumResult}");
            Console.WriteLine($"{first} - {second} = {differenceResult}");
        }

        public void ShowResultOfProductPolynomialByConstant(Polynomial polynomial, double multiplier, Polynomial result)
        {
            Console.WriteLine($"{polynomial} * {multiplier} = {result}");
        }

        public void ShowResultOfPolynomialsProduct(Polynomial first, Polynomial second, Polynomial result)
        {
            Console.WriteLine($"{first} * {second} = {result}");
        }
    }
}
