using BinaryConverting.Model;
using BinaryConverting.View;
using System;
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
            INumbers number = new Numbers();
            number.DecimalNumber = RequestDecimalNumber();
            _view.ShowResultByConversion(number.ConvertDecimalToBinary());
        }

        private int RequestDecimalNumber()
        {
            while (true)
            {
                try
                {
                    var decimalNumber = ConvertUserInput();

                    if (decimalNumber > 0)
                    {
                        return decimalNumber;
                    }
                    _view.ShowWarningMessage("Number is <= 0.");
                }
                catch (FormatException)
                {
                    _view.ShowMessageFormatException();
                }
            }
        }

        private int ConvertUserInput()
        {
            var input = _view.RequestInput("Enter a non-negative decimal integer.");
            return Convert.ToInt32(input);
        }
    }
}