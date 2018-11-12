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
                    Console.WriteLine("Enter a non-negative decimal integer.");
                    EnterUserData();

                    if (number.DecimalNumber <= 0)
                    {
                        consoleView.ShowWarningMessage();
                        continue;
                    }
                }
                catch (FormatException)
                {
                    number.DecimalNumber = 0;
                    consoleView.ShowWarningMessage("Invalid format entered");
                    continue;
                }
                catch (ArgumentNullException)
                {
                    number.DecimalNumber = 0;
                    consoleView.ShowWarningMessage("The value entered is empty");
                    continue;
                }

                break;
            }
            
            conversionNumeric.ConvertDecimalToBinary(number);
            consoleView.ShowResultByConversion(number);
        }
        
        public void EnterUserData()
        {
            number.DecimalNumber = ValidatingInputDataHelper.ValidateDataInputTryInt(Console.ReadLine());
        }

    }
}
