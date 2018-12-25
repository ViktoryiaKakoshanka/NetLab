using BinaryConverting.View;

namespace BinaryConverting
{
    internal class Program
    {
        private static void Main()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            var mainLaunchProgram = new MainLaunchProgram(new ConsoleView());
=======
            var mainLaunchProgram = new ProgramLauncher(new ConsoleView());
>>>>>>> master
            mainLaunchProgram.RunProgram();
=======
            var runner = new ProgramRunner(new ConsoleView());
            runner.RunProgram();
>>>>>>> RefactoringInLab
        }
    }
}