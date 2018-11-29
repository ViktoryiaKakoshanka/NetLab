using DecoratorStream.Model;
using DecoratorStream.View;
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

            ReadFile();
            _view.WriteLine(Console.CursorLeft.ToString());
            _view.WriteLine(Console.CursorTop.ToString());
            _view.WaitForAnyKeyPress();
        }

        private void ReadFile()
        {
            using (WorkWithText fstream = new WorkWithText(File.OpenRead(FileData.PUTH), _view))
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
