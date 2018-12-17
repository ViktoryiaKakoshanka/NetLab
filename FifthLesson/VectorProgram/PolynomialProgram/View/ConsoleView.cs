using PolynomialProgram.Model;
using System;

namespace PolynomialProgram.View
{
    public class ConsoleView : IView
    {
        public void Exit()
        {
            WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public string ReadLine(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string text) => Console.WriteLine(text);

        public void WriteErrorMessage() => Console.WriteLine("You entered incorrect numbers.");

        public void ShowPolynomials(Polynomial first, Polynomial second)
        {
            WriteLine("Your polynomials:\n");
            WriteLine(first.ToString());
            WriteLine(second.ToString());
        }

        public void ShowSimpleActionsWithPolynomialsResults(
            Polynomial first,
            Polynomial second,
            Polynomial sumPolynomials,
            Polynomial differencePolynomials,
            Polynomial multiplicationPolynomials)
        {
            WriteLine($"{first} + {second} = {sumPolynomials}");
            WriteLine($"{first} - {second} = {differencePolynomials}");
            WriteLine($"{first} * {second} = {multiplicationPolynomials}");
        }

        public void ShowMultiplicationNumberByPolynomial(Polynomial polynomial, double multiplier, Polynomial result)
        {
            WriteLine($"{polynomial} * {multiplier} = {result}");
        }
    }
}
