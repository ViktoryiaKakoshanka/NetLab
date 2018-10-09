using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLessonConsoleApp
{
    class Program
    {
        protected List<string> listCoordinates = new List<string>();

        static void Main(string[] args)
        {
            question();

            Console.ReadKey();
        }


        static void formateCoordinateWrite(List<string> list_filled) //форматированный вывод
        {
            String[] coordinates = new string[2];
            Double x, y;

            Console.WriteLine("Форматированный вывод координат");
            foreach (string lf in list_filled)
            {
                coordinates = lf.Split(',');
                x = Convert.ToDouble(coordinates[0].Replace('.', ','));
                y = Convert.ToDouble(coordinates[1].Replace('.', ','));

                Console.WriteLine("X: {0:#.####} Y: {1:#.####}", x, y);
            }

            question();
        }

        static void question()//подобие меню
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
                    inputConsole();
                    break;
                case 2:
                    inputFile();
                    break;
                case 3:
                    {
                        Console.Clear();
                        question();
                        break;
                    }
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        static void inputConsole()//ввод координат через консоль
        {
            string inputC;
            Console.WriteLine("Вводите:");
            Program pr = new Program();

            do
            {
                inputC = Console.ReadLine();
                if (inputC != String.Empty) pr.listCoordinates.Add(inputC);
            }
            while (inputC != String.Empty);
            
            formateCoordinateWrite(pr.listCoordinates);
        }

        static void inputFile()//ввод координат из файла
        {
            string path = "coordinates.txt";

            //построчное считывание
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                Program pr = new Program();
                string line;
                while((line = sr.ReadLine())!= null)
                {
                    pr.listCoordinates.Add(line);
                }

                formateCoordinateWrite(pr.listCoordinates);
            }
        }

    }
}
