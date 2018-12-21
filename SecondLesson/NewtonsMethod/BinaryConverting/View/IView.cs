using BinaryConverting.Model;

namespace BinaryConverting.View
{
    public interface IView
    {
        string RequestInput(string message);
        void ShowResultByConversion(INumbers number);
        void ShowWarningMessage(string messEx = null);
        void ShowMessageFormatException();
    }
}