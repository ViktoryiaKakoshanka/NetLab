using MatrixProject.View;

namespace MatrixProject
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