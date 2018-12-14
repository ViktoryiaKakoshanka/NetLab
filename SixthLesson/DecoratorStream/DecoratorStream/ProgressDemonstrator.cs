using DecoratorStream.View;

namespace DecoratorStream
{
    public static class ProgressDemonstrator
    {
        public static int ShowProgress(int countPrintedSymbols, int bytesRead, int totalBytes, IView view)
        {
            var percents = CalculatePercentRead(bytesRead, totalBytes);
            view.ShowCurrentStatusInPercent(percents.ToString(), 2);

            countPrintedSymbols = ShowSymbols(countPrintedSymbols, percents, view);
            
            return countPrintedSymbols;
        }

        private static int CalculatePercentRead(int bytesRead, int totalBytes)
        {
            return bytesRead * 100 / totalBytes;
        }
        
        private static int ShowSymbols(int countPrintedSymbols, int countNextSymbols, IView view)
        {
            for (var position = countPrintedSymbols; position < countNextSymbols; position++)
            {
                view.DrawSymbol(position, 3, '|');
            }
            return countNextSymbols;
        }
    }
}