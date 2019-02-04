namespace ConsoleFactory
{
    public interface IFactory
    {
        IFactory CreateProduct(TypeProduct product);
    }
}