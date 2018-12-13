using System.Collections;
using System.ComponentModel;
using DecoratorStream.Model;
using DecoratorStream.View;
using DecoratorStream.Decorators;
using System.IO;
using System.Configuration;
using System.Collections.Generic;

namespace DecoratorStream
{
    public class InitializationListDecorators
    {
        private readonly IView _consoleView;
        private IList<Stream> _listStreamDecorators;
        private readonly Stream _stream;

        public InitializationListDecorators(IView consoleView)
        {
            _consoleView = consoleView;
            _stream = File.OpenRead(ConfigurationManager.AppSettings["filePath"]);

            InitializeListDecorators();
        }

        public void Run()
        {
            ShowFileReadStatus();

            ReadFileWithPassword();

            _consoleView.WaitForAnyKeyPress();
        }

        private void ShowFileReadStatus()
        {
            using (Stream fileStream = new ProgressReadDecorator(_stream, _consoleView))
            {
                var buffer = new byte[fileStream.Length + FileData.CountBytesToRead];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
            }
        }

        private void ReadFileWithPassword()
        {
            using (Stream fileStream = new RequestPasswordDecorator(_stream, _consoleView))
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

        private void InitializeListDecorators()
        {
            _listStreamDecorators.Add(new RequestPasswordDecorator(_stream, _consoleView));
            _listStreamDecorators.Add(new ProgressReadDecorator(_stream, _consoleView));
        }

        private Stream GetDecorator()
        {

            return null;
        }
        
    }
}
