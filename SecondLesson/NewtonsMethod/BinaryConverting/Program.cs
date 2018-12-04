using BinaryConverting.View;

namespace BinaryConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainLaunchProgram = new ProgramLauncher(new ConsoleView());
            mainLaunchProgram.RunProgram();
        }
    }
}
