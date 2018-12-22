using BinaryConverting.Model;

namespace BinaryConverting.View
{
    public interface IConvertingView
    {
        void ShowResultByConversion(INumbers number);
        void ShowWarningMessageForRepeat(string messEx = null);
        void ShowMessageFormatException();
        void ShowMessageArgumentNullException();
    }
}
