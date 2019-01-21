using BinaryConverting.View;
using BinaryConverting.Helpers;

namespace BinaryConverting
{
    internal class ProgramRunner
    {
        private readonly IView _view;

        public ProgramRunner(IView view)
        {
            _view = view;
        }

        public void RunProgram()
        {
            var number = RequestDecimalNumber();
            _view.ShowResultByConversion(number, number.ToBinary());
        }

        private int RequestDecimalNumber()
        {
            while (true)
            {
                var input = _view.RequestInput("Enter a non-negative decimal integer.");

                if ( int.TryParse(input, out var decimalNumber) && decimalNumber > 0)
                {
                    return decimalNumber;
                }
                _view.ShowWarningMessage("Number is <= 0.");
            }
        }
    }
}