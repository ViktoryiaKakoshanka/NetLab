using System;
using System.IO;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    class TextLoading : BaseDecoratorStream
    {
        private Stream _stream;
        private IConsoleView _view;

        private const int COUNTBYTESTOREAD = 30;

        public TextLoading(Stream stream, IConsoleView view) : base(stream, view)
        {
            _stream = stream;
            _view = view;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            byte[] bytes = new byte[count + COUNTBYTESTOREAD];
            int numBytesToRead = count;
            int numBytesRead = 0;
            var i = 0;
            var previousPercent = 0.0;

            do
            {
                ShowCurrentPersents(count, numBytesRead, ref previousPercent, ref i);

                int n = _stream.Read(bytes, numBytesRead, COUNTBYTESTOREAD);

                numBytesRead += n;
                numBytesToRead -= n;
            } while (numBytesToRead > 0);

            ShowFinalResult();

            return count;
        }

        private void ShowCurrentPersents(int count, int numBytesRead, ref double previousPercent, ref int i)
        {
            var currentPercent = (((double)(numBytesRead * 100)) / count);

            _view.SetCursorPosition(0, 1);
            _view.WriteLine(Math.Round(currentPercent, 1).ToString() + "%");

            ShowVerticalLines(currentPercent, ref previousPercent, ref i);
        }

        private void ShowVerticalLines(double currentPercent, ref double previousPercent, ref int i)
        {
            var differentPersent = currentPercent - previousPercent;
            if (differentPersent > 1)
            {
                previousPercent = currentPercent;_view.SetCursorPosition(i++, 3);
                _view.WriteLine("|");
            }
        }

        private void ShowFinalResult()
        {
            _view.SetCursorPosition(0, 1);
            _view.WriteLine("100% ");
            _view.SetCursorPosition(0, 4);
        }
    }
}
