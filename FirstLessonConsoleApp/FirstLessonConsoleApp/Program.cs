using FirstLessonConsoleApp.View;

namespace FirstLessonConsoleApp
{
    public class Program
    {
        private const string Path = "coordinates.txt";

        public static void Main(string[] args)
        {
            var program = new CoordinatesReaderProgram(new ConsoleView(), Path);
            program.RunProgram();
        }
    }
}
