using PolynomialProgram.View;
using VectorProgram.View;
using ConsoleView = PolynomialProgram.View.ConsoleView;

namespace PolynomialProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            IView view = new ConsoleView();
            new ProgramRun(view).Run();
        }
    }
}
