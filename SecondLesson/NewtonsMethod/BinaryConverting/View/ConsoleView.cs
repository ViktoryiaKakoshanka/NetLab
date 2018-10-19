using System;
using BinaryConverting.Model;
using BinaryConverting.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverting.View
{
    class ConsoleView
    {
        private Numbers number = new Numbers();

        public void UserInput()
        {
            byte decNumeric;
            Console.WriteLine("Введите неотрицательное десятичное значение целого числа");

            if(byte.TryParse(Console.ReadLine(), out decNumeric))
            {
                number.DecimalNumber(decNumeric);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы ввели некорректное значение.");
                Console.WriteLine("Введите неотрицательное десятичное значение целого числа:");
                UserInput();
            }
        }

        public void PrintResultByConversion()
        {
            var conversionNumeric = new ConversionNumeric();
            conversionNumeric.DecimalToBinary(number);
            Console.WriteLine(number.BinaryNumber());
            Console.ReadKey(true);
        }
    }
}
