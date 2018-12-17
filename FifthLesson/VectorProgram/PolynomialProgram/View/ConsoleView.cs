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

        public string ReadLine(string message)
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

        public void ShowSimpleActionsWithPolynomialsResults(
            Polynomial first,
            Polynomial second,
            Polynomial sumPolynomials,
            Polynomial differencePolynomials,
            Polynomial multiplicationPolynomials)
        {
            Console.WriteLine($"{first} + {second} = {sumPolynomials}");
            Console.WriteLine($"{first} - {second} = {differencePolynomials}");
            Console.WriteLine($"{first} * {second} = {multiplicationPolynomials}");
        }

        public void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result)
        {
            Console.WriteLine($"{polynomial} * {multiplier} = {result}");
        }
    }
}
