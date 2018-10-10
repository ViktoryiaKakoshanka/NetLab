using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLessonConsoleApp
{
    class Program
    {
        protected List<string> ListCoordinates = new List<string>();

        static void Main(string[] args)
        {
            ChooseMenu();

            Console.ReadKey();
        }


        static void FormattedСoordinateOutput(List<string> fields) //форматированный вывод   
        {
            String[] Сoordinates = new string[2];
            Double СoordinateX, СoordinateY;

            Console.WriteLine("Форматированный вывод координат");
            foreach (string field in fields)
            {
                Сoordinates = field.Split(',');
                СoordinateX = Convert.ToDouble(Сoordinates[0].Replace('.', ','));
                СoordinateY = Convert.ToDouble(Сoordinates[1].Replace('.', ','));

                Console.WriteLine("X: {0:#.####} Y: {1:#.####}", СoordinateX, СoordinateY);
            }

            ChooseMenu();
        }

        static void ChooseMenu()//подобие меню
        {
            int numMenu = 3;
            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine("1 - ввод координат с клавиатуры");
            Console.WriteLine("2 - ввод координат из файла");
            Console.WriteLine("3 - очистить окно");
            Console.WriteLine("4 - выход");

            numMenu = Convert.ToInt32(Console.ReadLine());
            switch (numMenu)
            {
                case 1:
                    InputСoordinatesConsole();
                    break;
                case 2:
                    InputСoordinatesFile();
                    break;
                case 3:
                    {
                        Console.Clear();
                        ChooseMenu();
                        break;
                    }
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        static void InputСoordinatesConsole()//ввод координат через консоль
        {
            string CoordinatePair;
            Console.WriteLine("Вводите:");
            Program InstanceProgram = new Program();

            do
            {
                CoordinatePair = Console.ReadLine();
                if (CoordinatePair != String.Empty) InstanceProgram.ListCoordinates.Add(CoordinatePair);
            }
            while (CoordinatePair != String.Empty);
            
            FormattedСoordinateOutput(InstanceProgram.ListCoordinates);
        }

        static void InputСoordinatesFile()//ввод координат из файла
        {
            string Path = "coordinates.txt";

            //построчное считывание  
            using (StreamReader InstanceStreamReader = new StreamReader(Path, Encoding.Default))
            {
                Program InstanceProgram = new Program();
                string CoordinatePair;
                while((CoordinatePair = InstanceStreamReader.ReadLine())!= null)
                {
                    InstanceProgram.ListCoordinates.Add(CoordinatePair);
                }

                FormattedСoordinateOutput(InstanceProgram.ListCoordinates);
            }
        }

    }
}
