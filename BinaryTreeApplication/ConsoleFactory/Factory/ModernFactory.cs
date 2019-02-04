using ConsoleFactory.Product;

namespace ConsoleFactory.Factory
{
    class ModernFactory : IFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ITable CreateTable()
        {
            return new ModernTable();
        }
    }
}
