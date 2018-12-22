using BinaryConverting.View;

namespace BinaryConverting
{
    class Program
    {
        static void Main()
        {
<<<<<<< HEAD
            var mainLaunchProgram = new MainLaunchProgram(new ConsoleView());
=======
            var mainLaunchProgram = new ProgramLauncher(new ConsoleView());
>>>>>>> master
            mainLaunchProgram.RunProgram();
        }
    }
}
