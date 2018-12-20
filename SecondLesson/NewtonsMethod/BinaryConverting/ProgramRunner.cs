using BinaryConverting.Model;
using BinaryConverting.View;
using BinaryConverting.Controller;
using System;

namespace BinaryConverting
{
    internal class ProgramRunner
    {
        private readonly INumbers _number = new Numbers();
        private readonly IView _view;

        public ProgramRunner(IView view)
        {
            _view = view;
        }

        public void RunProgram()
        {
            var conversionNumeric = new ConversionNumber();
            RequestDecimalNumber();

            conversionNumeric.ConvertDecimalToBinary(_number);
        }

        private void RequestDecimalNumber()
        {
            while (true)
            {
                try
                {
                    ParseUserInput();

                    if (_number.DecimalNumber <= 0)
                    {
                        _view.ShowWarningMessage("Number is <= 0.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    _number.DecimalNumber = 0;
                    _view.ShowMessageFormatException();
                    continue;
                }
                catch (ArgumentNullException)
                {
                    _number.DecimalNumber = 0;
                    _view.ShowMessageArgumentNullException();
                    continue;
                }
                break;
            }
        }

        private void ParseUserInput()
        {
            var input = _view.ReadInput("Enter a non-negative decimal integer.");
            _number.DecimalNumber = Convert.ToInt32(input);
        }
    }
}