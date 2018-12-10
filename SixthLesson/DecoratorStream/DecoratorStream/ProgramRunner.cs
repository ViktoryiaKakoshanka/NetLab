using DecoratorStream.Model;
using DecoratorStream.View;
using DecoratorStream.Decorators;
using System.IO;
using System.Configuration;

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
            ShowFileReadStatus();

            ReadFileWithPassword();

            _consoleView.WaitForAnyKeyPress();
        }

        private void ShowFileReadStatus()
        {
            using (var fileStream = new ProgressReadDecorator(File.OpenRead(ConfigurationManager.AppSettings["filePath"]), _consoleView))
            {
                var buffer = new byte[fileStream.Length + FileData.COUNTBYTESTOREAD];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
            }
        }

        private void ReadFileWithPassword()
        {
            using (var fileStream = new RequestPasswordDecorator(File.OpenRead(ConfigurationManager.AppSettings["filePath"]), _consoleView))
            {
                var buffer = new byte[fileStream.Length];

                var readResult = fileStream.Read(buffer, 0, buffer.Length);

                if (readResult == 0)
                {
                    return;
                }

                var textFromFile = System.Text.Encoding.Default.GetString(buffer);
                _consoleView.ShowReadText(textFromFile);
            }
        }
    }
}
