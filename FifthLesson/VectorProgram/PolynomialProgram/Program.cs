using PolynomialProgram.View;
using ConsoleView = PolynomialProgram.View.ConsoleView;

namespace PolynomialProgram
{
    class Program
    {
        static void Main()
        {
            IView view = new ConsoleView();
            new ProgramRun(view).Run();
        }
    }
}
