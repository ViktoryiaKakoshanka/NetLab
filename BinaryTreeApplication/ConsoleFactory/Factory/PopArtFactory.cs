using ConsoleFactory.Product;

namespace ConsoleFactory.Factory
{
    class PopArtFactory : IFactory
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
