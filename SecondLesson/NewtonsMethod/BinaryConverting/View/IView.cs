namespace BinaryConverting.View
{
    public interface IView
    {
        string RequestInput(string message);
        void ShowResultByConversion(int decimalNumber, string binaryNumber);
        void ShowWarningMessage(string messEx = null);
    }
}