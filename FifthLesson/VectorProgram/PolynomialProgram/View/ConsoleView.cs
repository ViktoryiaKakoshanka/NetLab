using PolynomialProgram.Model;
using System;
using System.Collections.Generic;
using VectorProgram.View;

namespace PolynomialProgram.View
{
    public class ConsoleView : IConsoleView, IPolinomialView
    {
        public void WaitForAnyKeyPress()
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

        public void ShowPolynomials(IList<Polynomial> initialPolynomials)
        {
            WriteLine("Your polynomials:");

            foreach (var polynomial in initialPolynomials)
            {
                WriteLine(polynomial.ToString());
            }
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
