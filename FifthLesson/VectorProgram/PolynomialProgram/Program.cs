using VectorProgram.View;
using ConsoleView = PolynomialProgram.View.ConsoleView;
using IPolinomialView = PolynomialProgram.View.IPolinomialView;

namespace PolynomialProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleView consoleView = new ConsoleView();
            IPolinomialView polinomialView = new ConsoleView();
            new ProgramRun(consoleView, polinomialView).Run();
        }
    }
}
