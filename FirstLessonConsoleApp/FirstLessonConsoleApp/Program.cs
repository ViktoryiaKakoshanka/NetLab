using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLessonConsoleApp
{
    class Program
    {
        List<string> listCoordinates = new List<string>();

        static void Main(string[] args)
        {
            ChooseMenu();
        }


        static void FormattedСoordinateOutput(List<string> fields) //форматированный вывод   
        {
            var coordinates = new string[2];
            double coordinateX, coordinateY;

            Console.WriteLine("Форматированный вывод координат");

            foreach (var field in fields)
            {
                coordinates = field.Split(',');
                coordinateX = Convert.ToDouble(coordinates[0].Replace('.', ','));
                coordinateY = Convert.ToDouble(coordinates[1].Replace('.', ','));

                Console.WriteLine("X: {0:#.####} Y: {1:#.####}", coordinateX, coordinateY);
            }

            ChooseMenu();
        }

        static void ChooseMenu()//подобие меню
        {
            string menuItem;

            Console.WriteLine("\nВыберите пункт меню:");
            Console.WriteLine("1 - ввод координат с клавиатуры");
            Console.WriteLine("2 - ввод координат из файла");
            Console.WriteLine("3 - очистить окно");
            Console.WriteLine("4 - выход");

            menuItem = Console.ReadLine();

            switch (menuItem)
            {
                case "1":
                    InputСoordinatesConsole();
                    break;
                case "2":
                    InputСoordinatesFile();
                    break;
                case "3":
                    Console.Clear();
                    ChooseMenu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Выберите пункт меню от 1 до 4");
                    ChooseMenu();
                    break;
            }
        }

        static void InputСoordinatesConsole()//ввод координат через консоль
        {
            string coordinatePair;

            Console.WriteLine("Вводите:");

            var instanceProgram = new Program();

            do
            {
                coordinatePair = Console.ReadLine();
                if (coordinatePair != String.Empty) instanceProgram.listCoordinates.Add(coordinatePair);
            }
            while (coordinatePair != String.Empty);
            
            FormattedСoordinateOutput(instanceProgram.listCoordinates);
        }

        static void InputСoordinatesFile()//ввод координат из файла
        {
            string Path = "coordinates.txt";

            //построчное считывание  
            using (StreamReader InstanceStreamReader = new StreamReader(Path, Encoding.Default))
            {
                var instanceProgram = new Program();
                string coordinatePair;
                while((coordinatePair = InstanceStreamReader.ReadLine())!= null)
                {
                    instanceProgram.listCoordinates.Add(coordinatePair);
                }

                FormattedСoordinateOutput(instanceProgram.listCoordinates);
            }
        }

    }
}
