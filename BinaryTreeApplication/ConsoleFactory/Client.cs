using ConsoleFactory.Factory;
using ConsoleFactory.Product;

namespace ConsoleFactory
{
    internal class Client
    {
        public IChair Chair { get; private set; }
        public ITable Table { get; private set; }

        public Client(IFurnitureFactory factory)
        {
            Chair = factory.CreateChair();
            Table = factory.CreateTable();
        }
    }
}