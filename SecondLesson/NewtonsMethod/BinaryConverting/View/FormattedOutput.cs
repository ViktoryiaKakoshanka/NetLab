using BinaryConverting.Model;

namespace BinaryConverting.View
{
    class FormattedOutput
    {
        private IConsoleView _view;

        public FormattedOutput(IConsoleView view)
        {
            _view = view;
        }

        public void ShowResultByConversion(INumbers number)
        {
            _view.WriteLine("Result:");
            _view.WriteLine($"Decimal number:{number.DecimalNumber}");
            _view.WriteLine($"Binary number:{number.BinaryNumber}");

            _view.WaitForAnyKeyPress();
        }

        public void ShowWarningMessageForRepeat(string messEx = null)
        {
            _view.Clear();
            _view.WriteLine($"{messEx} You must repeat the value entry. ");
        }

        public void ShowMessageFormatException() => _view.WriteLine("Invalid format entered.");

        public void ShowMessageArgumentNullException() => _view.WriteLine("The value entered is empty.");
    }
}
