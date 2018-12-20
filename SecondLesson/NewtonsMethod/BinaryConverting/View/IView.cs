using BinaryConverting.Model;

namespace BinaryConverting.View
{
    public interface IView
    {
        string ReadInput(string message);
        void ShowResultByConversion(INumbers number);
        void ShowWarningMessage(string messEx = null);
        void ShowMessageFormatException();
        void ShowMessageArgumentNullException();
    }
}