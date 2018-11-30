using System;
using System.IO;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    class TextLoader : BaseDecoratorStream
    {
        private const int COUNTBYTESTOREAD = 30;

        public TextLoader(Stream stream, IConsoleView view) : base(stream, view)     { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var numberBytesToRead = count;
            var numberBytesRead = 0;
            var countIteration = 0;
            var previousPercent = 0.0;

            do
            {
                var n = Stream.Read(buffer, numberBytesRead, COUNTBYTESTOREAD);

                numberBytesRead += n;
                numberBytesToRead -= n;

                var currentPercents = CalculateCurrentPersent(count, numberBytesRead);
                ShowCurrentPersents(currentPercents);

                ShowVerticalLines(currentPercents, ref previousPercent, ref countIteration);

            } while (numberBytesToRead > 0);

            ShowFinalResult();
            return count;
        }

        private double CalculateCurrentPersent(int count, int numBytesRead)
        {
            return ((double)(numBytesRead * 100)) / count;
        }

        private void ShowCurrentPersents(double percents)
        {
            ConsoleView.SetCursorPosition(0, 1);
            ConsoleView.WriteLine(Math.Round(percents, 1).ToString() + "%");
        }

        private void ShowVerticalLines(double percents, ref double previousPercent, ref int countIteration)
        {
            //TODO: rename differentPercent (nextPartReadPercents)
            var differentPersent = (int)Math.Round(percents - previousPercent);
            if (differentPersent >= 1)
            {
                previousPercent = (int)Math.Round(percents);
                for (var item = 1; item <= differentPersent; item++)
                {
                    ConsoleView.SetCursorPosition(countIteration++, 3);
                    ConsoleView.WriteLine("|");
                }
            }
        }

        private void ShowFinalResult()
        {
            ConsoleView.SetCursorPosition(0, 1);
            ConsoleView.WriteLine("100% ");
            ConsoleView.SetCursorPosition(0, 4);
        }
    }
}
