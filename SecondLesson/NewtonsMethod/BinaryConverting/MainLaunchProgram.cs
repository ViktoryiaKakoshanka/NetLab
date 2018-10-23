using BinaryConverting.Model;
using BinaryConverting.View;
using BinaryConverting.Controller;
using System;

namespace BinaryConverting
{
    class MainLaunchProgram
    {
        INumbers number = new Numbers();

        public void RunProgram(IConsoleView consoleView)
        {
            var conversionNumeric = new ConversionNumeric();

            while(true)
            {
                try
                {
                    Console.WriteLine("Введите неотрицательное десятичное значение целого числа");
                    ProcessUserInput();

                    if (number.DecimalNumber <= 0)
                    {
                        consoleView.WarningMessage();
                        continue;
                    }
                }
                catch (FormatException)
                {
                    number.DecimalNumber = 0;
                    consoleView.WarningMessage("Введен не верный формат");
                    continue;
                }
                catch (ArgumentNullException)
                {
                    number.DecimalNumber = 0;
                    consoleView.WarningMessage("Введенное значение пустое");
                    continue;
                }

                break;
            }

            
            conversionNumeric.NumberDecimalToBinary(number);

            consoleView.PrintResultByConversion(number);
        }
        
        public void ProcessUserInput()
        {
            number.DecimalNumber = ValidateUserInputHelper.ValidationUserInputTryInt(Console.ReadLine());
        }

    }
}
