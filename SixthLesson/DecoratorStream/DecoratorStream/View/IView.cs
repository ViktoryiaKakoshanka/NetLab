namespace DecoratorStream.View
{
    public interface IView
    {
        void Exit();
        void ShowMessageErrorPassword();
        string RequestPassword();
        void ShowCurrentStatusRead(string percents, int numberLineToPrint);
        void ShowSymbol(int countIteration, int numberLineToPrint, char symbol);
        void FinishRead();
    }
}