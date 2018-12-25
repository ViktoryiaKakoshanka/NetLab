using TriangleLib.View;

namespace TriangleLib
{
    internal class Program
    {
        private static void Main()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            var run = new WorkWithATriangle(new ConsoleView());
=======
            var run = new ProgramRunner(new ConsoleView());
>>>>>>> master
=======
            var run = new ProgramRunner(new ConsoleView());
>>>>>>> RefactoringInLab
            run.RunProgram();
        }
    }
}