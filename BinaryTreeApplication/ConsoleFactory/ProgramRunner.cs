using ConsoleFactory.Factory;
using System;

namespace ConsoleFactory
{
    public static class ProgramRunner
    {
        public static void Run()
        {
            var client = new Client(new ModernFactory());
            PrintInfo(client);

            client = new Client(new PopArtFactory());
            PrintInfo(client);
        }

        private static void PrintInfo(Client client)
        {
            Console.WriteLine(client.Chair.GetInfo());
            Console.WriteLine(client.Table.GetInfo() + '\n');
        }
    }
}
