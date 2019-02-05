using ConsoleFactory.Product;

namespace ConsoleFactory.Factory
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
}