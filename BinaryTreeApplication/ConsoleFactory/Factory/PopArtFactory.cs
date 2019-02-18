using ConsoleFactory.Model;

namespace ConsoleFactory.Factory
{
    internal class PopArtFactory : IFurnitureFactory
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
