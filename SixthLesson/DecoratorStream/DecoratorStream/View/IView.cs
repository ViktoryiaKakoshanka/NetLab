namespace DecoratorStream.View
{
    public interface IView
    {
        void WriteLine(string text);
        string ReadLine(string message);
        void WaitForAnyKeyPress();
        void ShowMessageErrorPassword();
        void SetCursorPosition(int left, int top);
        void ShowReadText(string text);
        string RequestPassword();
        void ShowCurrentStatusRead(string percents, int numberLineToPrint);
        void ShowVerticalLine(int countIteration, int numberLineToPrint);
        void ShowLastPercents(int numberLineToPrint);
        void GoToLastLine(int numberLastLine);
    }
}
