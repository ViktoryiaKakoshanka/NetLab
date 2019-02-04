using ConsoleFactory.Product;

namespace ConsoleFactory
{
    class Factory1 : IFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
}
