using ConsoleFactory.Product;

namespace ConsoleFactory.Factory
{
    internal class PopArtFactory : IFactory
    {
        public IChair CreateChair()
        {
            return new PopArtChair();
        }

        public ITable CreateTable()
        {
            return new PopArtTable();
        }
    }
}
