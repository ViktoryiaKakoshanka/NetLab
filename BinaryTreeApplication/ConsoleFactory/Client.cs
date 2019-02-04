using ConsoleFactory.Factory;
using ConsoleFactory.Product;

namespace ConsoleFactory
{
    class Client
    {
        public IChair Chair { get; private set; }
        public ITable Table { get; private set; }

        public Client(IFactory factory)
        {
            Chair = factory.CreateChair();
            Table = factory.CreateTable();
        }
    }
}