using ConsoleFactory.Product;

namespace ConsoleFactory.Factory
{
    public interface IFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
}