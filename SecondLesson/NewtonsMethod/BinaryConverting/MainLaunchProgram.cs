using BinaryConverting.Model;
using BinaryConverting.View;
using BinaryConverting.Controller;
using System;

namespace BinaryConverting
{
    class MainLaunchProgram
    {
        readonly INumbers _number = new Numbers();
        private readonly IConsoleView _consoleView;
        private readonly IConvertingView _convertingView;

        public MainLaunchProgram(ConsoleView consoleView)
        {
            _consoleView = consoleView;
            _convertingView = consoleView;
        }

        public void RunProgram()
        {
            var conversionNumeric = new ConversionNumber();
            RequestDecimalNumber();

            conversionNumeric.ConvertDecimalToBinary(_number);
            _convertingView.ShowResultByConversion(_number);
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
                        _convertingView.ShowWarningMessageForRepeat("Number is <= 0.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    _number.DecimalNumber = 0;
                    _convertingView.ShowMessageFormatException();
                    continue;
                }
                catch (ArgumentNullException)
                {
                    _number.DecimalNumber = 0;
                    _convertingView.ShowMessageArgumentNullException();
                    continue;
                }
                break;
            }
        }

        private void ParseUserInput()
        {
            var input = _consoleView.ReadLine("Enter a non-negative decimal integer.");
            _number.DecimalNumber = Convert.ToInt32(input);
        }

    }
}
