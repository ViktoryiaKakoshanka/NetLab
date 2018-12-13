using DecoratorStream.Model;
using DecoratorStream.View;
using DecoratorStream.Decorators;
using System.IO;
using System.Configuration;

namespace DecoratorStream
{
    public class ProgramRunner
    {
        private readonly IView _consoleView;

        public ProgramRunner(IView consoleView)
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
            using (Stream fileStream = new ProgressReadDecorator(File.OpenRead(ConfigurationManager.AppSettings["filePath"]), _consoleView))
            {
                var buffer = new byte[fileStream.Length + FileData.CountBytesToRead];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
            }
        }

        private void ReadFileWithPassword()
        {
            using (Stream fileStream = new RequestPasswordDecorator(File.OpenRead(ConfigurationManager.AppSettings["filePath"]), _consoleView))
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
