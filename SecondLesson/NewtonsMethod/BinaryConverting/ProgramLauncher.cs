using BinaryConverting.View;
using BinaryConverting.Controller;
using System;

namespace BinaryConverting
{
    class ProgramLauncher
    {
        IConsoleView _consoleView;

        public ProgramLauncher(IConsoleView consoleView)
        {
            _consoleView = consoleView;
        }

        public void RunProgram()
        {
            var numberConverter = new NumberConverter();
            var number = RequestDecimalNumber();

            var binaryNumberString = numberConverter.ConvertDecimalToBinary(number);
            _consoleView.ShowConvertionResult(number, binaryNumberString);
            _consoleView.WaitForAnyKeyPress();
        }

        private int RequestDecimalNumber()
        {
            var number = 0;
            do
            {
                try
                {
                    _consoleView.WriteLine("Enter positive integer number");
                    var input = _consoleView.ReadLine();
                    number = int.Parse(input);

                    if (number <= 0)
                    {
                        _consoleView.ShowWarningMessageForRepeat("Number should be positive");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    _consoleView.ShowMessageFormatException();
                    continue;
                }
                catch (ArgumentNullException)
                {
                    _consoleView.ShowMessageArgumentNullException();
                    continue;
                }
            } while (number <= 0);

            return number;
        }
    }
}
