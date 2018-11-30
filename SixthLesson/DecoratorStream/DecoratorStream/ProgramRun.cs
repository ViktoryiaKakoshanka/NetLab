using DecoratorStream.Model;
using DecoratorStream.View;
using DecoratorStream.Decorators;
using System;
using System.IO;

namespace DecoratorStream
{
    public class ProgramRun
    {
        private IConsoleView _view;

        public void Run(IConsoleView view)
        {
            _view = view;

            ShowFileReadingStatus();

            //ReadFileWithPassword();

            _view.WaitForAnyKeyPress();
        }

        private void ShowFileReadingStatus()
        {
            using (var fstream = new TextLoading(File.OpenRead(FileData.FILEPATH), _view))
            {
                byte[] bytes = new byte[fstream.Length + 10];
                fstream.Read(bytes, 0, (int)fstream.Length);
                fstream.Close();
            }
        }
        
        private void ReadFileWithPassword()
        {
            using (var fstream = new PasswordRequestBeforeReading(File.OpenRead(FileData.FILEPATH), _view))
            {
                var array = new byte[fstream.Length];

                var readResult = fstream.Read(array, 0, array.Length);

                if (readResult != 0)
                {
                    var textFromFile = System.Text.Encoding.Unicode.GetString(array);
                    _view.WriteLine($"Text from file:\n {textFromFile}");
                }
                return;
            }
        }
    }
}
