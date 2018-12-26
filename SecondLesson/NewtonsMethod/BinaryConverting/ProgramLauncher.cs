using BinaryConverting.View;
using BinaryConverting.Controller;
using System;

namespace BinaryConverting
{
    class ProgramLauncher
    {
<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/MainLaunchProgram.cs
        readonly INumbers _number = new Numbers();
        private readonly IConsoleView _consoleView;
        private readonly IConvertingView _convertingView;

        public MainLaunchProgram(ConsoleView consoleView)
        {
            _consoleView = consoleView;
            _convertingView = consoleView;
=======
        IConsoleView _consoleView;

        public ProgramLauncher(IConsoleView consoleView)
        {
            _consoleView = consoleView;
>>>>>>> master:SecondLesson/NewtonsMethod/BinaryConverting/ProgramLauncher.cs
        }

        public void RunProgram()
        {
<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/MainLaunchProgram.cs
            var conversionNumeric = new ConversionNumber();
            RequestDecimalNumber();

            conversionNumeric.ConvertDecimalToBinary(_number);
            _convertingView.ShowResultByConversion(_number);
=======
            var numberConverter = new NumberConverter();
            var number = RequestDecimalNumber();

            var binaryNumberString = numberConverter.ConvertDecimalToBinary(number);
            _consoleView.ShowConvertionResult(number, binaryNumberString);
            _consoleView.WaitForAnyKeyPress();
>>>>>>> master:SecondLesson/NewtonsMethod/BinaryConverting/ProgramLauncher.cs
        }

        private int RequestDecimalNumber()
        {
            var number = 0;
            do
            {
                try
                {
<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/MainLaunchProgram.cs
                    ParseUserInput();
=======
                    _consoleView.WriteLine("Enter positive integer number");
                    var input = _consoleView.ReadLine();
                    number = int.Parse(input);
>>>>>>> master:SecondLesson/NewtonsMethod/BinaryConverting/ProgramLauncher.cs

                    if (number <= 0)
                    {
<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/MainLaunchProgram.cs
                        _convertingView.ShowWarningMessageForRepeat("Number is <= 0.");
=======
                        _consoleView.ShowWarningMessageForRepeat("Number should be positive");
>>>>>>> master:SecondLesson/NewtonsMethod/BinaryConverting/ProgramLauncher.cs
                        continue;
                    }
                }
                catch (FormatException)
                {
<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/MainLaunchProgram.cs
                    _number.DecimalNumber = 0;
                    _convertingView.ShowMessageFormatException();
=======
                    _consoleView.ShowMessageFormatException();
>>>>>>> master:SecondLesson/NewtonsMethod/BinaryConverting/ProgramLauncher.cs
                    continue;
                }
                catch (ArgumentNullException)
                {
<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/MainLaunchProgram.cs
                    _number.DecimalNumber = 0;
                    _convertingView.ShowMessageArgumentNullException();
=======
                    _consoleView.ShowMessageArgumentNullException();
>>>>>>> master:SecondLesson/NewtonsMethod/BinaryConverting/ProgramLauncher.cs
                    continue;
                }
            } while (number <= 0);

<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/MainLaunchProgram.cs
        private void ParseUserInput()
        {
            var input = _consoleView.ReadLine("Enter a non-negative decimal integer.");
            _number.DecimalNumber = Convert.ToInt32(input);
=======
            return number;
>>>>>>> master:SecondLesson/NewtonsMethod/BinaryConverting/ProgramLauncher.cs
        }
    }
}
