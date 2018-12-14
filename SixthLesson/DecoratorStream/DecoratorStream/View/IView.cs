namespace DecoratorStream.View
{
    public interface IView
    {
        void Exit();
        void ShowMessageErrorPassword();
        string RequestPassword();
        void ShowCurrentStatusInPercent(string percents, int numberLineToPrint);
        void DrawSymbol(int countIteration, int numberLineToPrint, char symbol);
        void FinishRead();
    }
}