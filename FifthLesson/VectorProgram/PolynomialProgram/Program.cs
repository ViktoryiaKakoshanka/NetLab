using PolynomialProgram.View;
using ConsoleView = PolynomialProgram.View.ConsoleView;

namespace PolynomialProgram
{
    internal class Program
    {
        private static void Main()
        {
            IView view = new ConsoleView();
            new ProgramRunner(view).Run();
        }
    }
}