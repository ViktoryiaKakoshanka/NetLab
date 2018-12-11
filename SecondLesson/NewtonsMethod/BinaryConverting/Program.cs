using BinaryConverting.View;

namespace BinaryConverting
{
    class Program
    {
        static void Main()
        {
            var mainLaunchProgram = new MainLaunchProgram(new ConsoleView());
            mainLaunchProgram.RunProgram();
        }
    }
}
