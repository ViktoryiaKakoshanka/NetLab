using BinaryConverting.Model;
using BinaryConverting.View;
using BinaryConverting.Controller;
using System;

namespace BinaryConverting
{
    class MainLaunchProgram
    {
        INumbers _number = new Numbers();
        FormattedOutput _formattedOutput;
        IConsoleView _consoleView;

        public void RunProgram(IConsoleView consoleView)
        {
            _consoleView = consoleView;
            _formattedOutput = new FormattedOutput(_consoleView);

            var conversionNumeric = new ConversionNumeric();
            RequestDecimalNumber();

            conversionNumeric.ConvertDecimalToBinary(_number);
            _formattedOutput.ShowResultByConversion(_number);
        }

        private void RequestDecimalNumber()
        {
            while (true)
            {
                try
                {
                    _consoleView.WriteLine("Enter a non-negative decimal integer.");
                    ParseUserInput();

                    if (_number.DecimalNumber <= 0)
                    {
                        _formattedOutput.ShowWarningMessageForRepeat("Number is <= 0.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    _number.DecimalNumber = 0;
                    _formattedOutput.ShowMessageFormatException();
                    continue;
                }
                catch (ArgumentNullException)
                {
                    _number.DecimalNumber = 0;
                    _formattedOutput.ShowMessageArgumentNullException();
                    continue;
                }
                break;
            }
        }

        private void ParseUserInput()
        {
            var input = _consoleView.ReadLine();
            _number.DecimalNumber = DataParser.ParseInt(input);
        }

    }
}
