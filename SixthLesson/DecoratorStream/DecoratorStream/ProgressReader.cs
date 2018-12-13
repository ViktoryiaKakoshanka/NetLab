using DecoratorStream.View;
using System;
using System.Globalization;

namespace DecoratorStream
{
    public static class ProgressReader
    {
        private static IView _view;
        
        public static int ShowProgressRead(int previousCountPrintedSymbols, int bytesRead, int totalBytes, IView view)
        {
            _view = view;
            
            var currentPercentsReading = CalculateCurrentPercentRead(bytesRead, totalBytes);

            _view.ShowCurrentStatusRead(Math.Round(currentPercentsReading, 1).ToString(CultureInfo.InvariantCulture), 2);
            
            var numberOfCharactersForPrint = Convert.ToInt32(currentPercentsReading);
            var partPrintedSymbols = ShowSymbol(previousCountPrintedSymbols, numberOfCharactersForPrint);
            
            return partPrintedSymbols;
        }

        private static double CalculateCurrentPercentRead(int bytesRead, int totalBytes)
        {
            return (double)(bytesRead * 100) / totalBytes;
        }
        
        private static int ShowSymbol(int previousPartReadPercents, int nextPartReadPercents)
        {
            var partPrintedSymbols = previousPartReadPercents;

            if (nextPartReadPercents - previousPartReadPercents < 1)
            {
                return partPrintedSymbols;
            }

            for (var item = previousPartReadPercents; item < nextPartReadPercents; item++)
            {
                _view.ShowSymbol(item, 3, '|');
            }

            partPrintedSymbols = nextPartReadPercents;

            return partPrintedSymbols;
        }
    }
}