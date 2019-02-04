using ConsoleFactory.Product;

namespace ConsoleFactory
{
    public interface IFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
}