using BinaryConverting.Model;
using BinaryConverting.View;
using BinaryConverting.Controller;
using System;

namespace BinaryConverting
{
    class MainLaunchProgram
    {
        INumbers number = new Numbers();

        public void RunProgram()
        {
            var conversionNumeric = new ConversionNumeric();
            var consoleView = new ConsoleView();

            try
            {
                UserInput();
            }
            catch (FormatException)
            {
                number.DecimalNumber = 0;
                ConsoleView.WarningMessage("Введен не верный формат");
            }
            catch(ArgumentNullException)
            {
                number.DecimalNumber = 0;
                ConsoleView.WarningMessage("Введенное значение пустое");
            }

            if (number.DecimalNumber <= 0)
            {
                ConsoleView.WarningMessage();
            }
            conversionNumeric.NumberDecimalToBinary(number);

            consoleView.PrintResultByConversion(number);
        }
        
        public void UserInput()
        {
            Console.WriteLine("Введите неотрицательное десятичное значение целого числа");
            number.DecimalNumberOfUserInput(Console.ReadLine());
        }

    }
}
