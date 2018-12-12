using System;
using System.IO;
using DecoratorStream.Model;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    class ProgressReadDecorator : BaseDecoratorStream
    {
        public ProgressReadDecorator(Stream stream, IConsoleView view) : base(stream, view)     { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var restBytesRead = count;
            var startBytesRead = offset;
            var countIteration = 0;
            var previousPercent = 0.0;

            do
            {
                ReadFileParts(buffer, ref restBytesRead, ref startBytesRead);
                ShowProgressRead(count, startBytesRead, ref countIteration, ref previousPercent);

            } while (restBytesRead > 0);

            ConsoleView.ShowLastPercents(1);
            return count;
        }

        private void ReadFileParts(byte[] buffer, ref int restBytesRead, ref int startBytesRead)
        {
            var countReadingBytes = Stream.Read(buffer, startBytesRead, FileData.COUNTBYTESTOREAD);

            startBytesRead += countReadingBytes;
            restBytesRead -= countReadingBytes;
        }

        private void ShowProgressRead(int count, int startBytesRead, ref int countIteration, ref double previousPercent)
        {
            var currentPercentsReading = CalculateCurrentPercentRead(count, startBytesRead);

            ConsoleView.ShowCurrentStatusRead(Math.Round(currentPercentsReading, 1).ToString(), 1);

            CalculateVerticalLines(currentPercentsReading, ref previousPercent, ref countIteration);

        }

        private double CalculateCurrentPercentRead(int totalCountBytes, int currentCountBytesRead)
        {
            return ((double)(currentCountBytesRead * 100)) / totalCountBytes;
        }

        private void CalculateVerticalLines(double percents, ref double previousPartPercents, ref int countPassedPercents)
        {
            var nextPartReadPercents = (int)Math.Round(percents - previousPartPercents);
            if (nextPartReadPercents >= 1)
            {
                previousPartPercents = (int)Math.Round(percents);
                for (var item = 1; item <= nextPartReadPercents; item++)
                {
                    ConsoleView.ShowVerticalLine(countPassedPercents++, 3);
                }
            }
        }
    }
}
