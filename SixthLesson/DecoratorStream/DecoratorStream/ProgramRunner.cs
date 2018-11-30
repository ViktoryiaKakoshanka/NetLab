using DecoratorStream.Model;
using DecoratorStream.View;
using DecoratorStream.Decorators;
using System.IO;

namespace DecoratorStream
{
    public class ProgramRunner
    {
        private IConsoleView _consoleView;

        public ProgramRunner(IConsoleView consoleView)
        {
            _consoleView = consoleView;
        }

        public void Run()
        {

            ShowFileReadingStatus();

            ReadFileWithPassword();

            _consoleView.WaitForAnyKeyPress();
        }

        private void ShowFileReadingStatus()
        {
            using (var fileStream = new TextLoader(File.OpenRead(FileData.FILEPATH), _consoleView))
            {
                var buffer = new byte[fileStream.Length + 10];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
            }
        }

        private void ReadFileWithPassword()
        {
            using (var fileStream = new PasswordRequestBeforeReading(File.OpenRead(FileData.FILEPATH), _consoleView))
            {
                var buffer = new byte[fileStream.Length];

                var readResult = fileStream.Read(buffer, 0, buffer.Length);

                if (readResult != 0)
                {
                    var textFromFile = System.Text.Encoding.Unicode.GetString(buffer);
                    _consoleView.WriteLine($"Text from file:\n {textFromFile}");
                }
                return;
            }
        }
    }
}
