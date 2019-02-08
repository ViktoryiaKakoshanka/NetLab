using ConsoleFactory.Model;
using ConsoleFactory.Model;

namespace ConsoleFactory.Factory
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
}