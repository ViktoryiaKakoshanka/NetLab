using ConsoleFactory.Product;

namespace ConsoleFactory.Factory
{
    internal class ModernFactory : IFactory
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
