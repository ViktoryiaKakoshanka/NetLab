using DecoratorStream.View;

namespace DecoratorStream
{
    public static class ProgressReporter
    {
        public static void ShowProgress(int bytesRead, int totalBytes, IView view)
        {
            var percents = CalculatePercentRead(bytesRead, totalBytes);
            view.ShowCurrentStatusInPercent(percents, 2);
            view.UpdateProgressBar(percents);
        }

        private static int CalculatePercentRead(int bytesRead, int totalBytes)
        {
            return bytesRead * 100 / totalBytes;
        }    
    }
}