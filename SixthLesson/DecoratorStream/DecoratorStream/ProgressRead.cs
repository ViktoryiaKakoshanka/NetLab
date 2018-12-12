using DecoratorStream.View;
using System;
using System.Globalization;

namespace DecoratorStream
{
    public class ProgressRead
    {
        private readonly IView _view;

        public ProgressRead(IView view)
        {
            _view = view;
        }

        public void ShowProgressRead(int offset, int count)
        {
            var startBytesRead = offset;
            var countIteration = 0;
            var previousPercent = 0.0;

            var currentPercentsReading = CalculateCurrentPercentRead(count, startBytesRead);

            _view.ShowCurrentStatusRead(Math.Round(currentPercentsReading, 1).ToString(CultureInfo.InvariantCulture), 1);

            CalculateCountSymbolsToPrint(currentPercentsReading, ref previousPercent, ref countIteration);
            
            if(offset >= count) _view.ShowLastPercents(1);
        }
            
        private static double CalculateCurrentPercentRead(int totalCountBytes, int currentCountBytesRead)
        {
            return (double)(currentCountBytesRead * 100) / totalCountBytes;
        }

        private void CalculateCountSymbolsToPrint(double percents, ref double previousPartPercents, ref int countPassedPercents)
        {
            var nextPartReadPercents = (int)Math.Round(percents - previousPartPercents);
            if (nextPartReadPercents < 1)
            {
                return;
            }
            previousPartPercents = (int)Math.Round(percents);
            for (var item = 1; item <= nextPartReadPercents; item++)
            {
                _view.ShowVerticalLine(countPassedPercents++, 3);
            }
        }
    }
}
