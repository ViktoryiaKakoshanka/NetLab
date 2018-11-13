namespace NewtonsMethod.View
{
    public interface IProgramView
    {
        void WriteLine(string text);
        void ReadKeyTrue();
        string ReadLine(string message);
        void ShowErrorMessageUserInput();
    }
}
