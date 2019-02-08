using ConsoleFactory.Factory;
using ConsoleFactory.Model;

namespace ConsoleFactory
{
    internal class Client
    {
        public IChair Chair { get; }
        public ITable Table { get; }

        public Client(IFurnitureFactory factory)
        {
            Chair = factory.CreateChair();
            Table = factory.CreateTable();
        }
    }
}