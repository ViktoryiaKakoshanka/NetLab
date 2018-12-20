namespace DecoratorStream.View
{
    public interface IView
    {
        void Exit();
        void NotifyWrongPassword();
        string RequestPassword();
        void ShowCurrentStatusInPercent(int percents, int numberLineToPrint);
        void UpdateProgressBar(int newProgress);
        void FinishRead();
    }
}