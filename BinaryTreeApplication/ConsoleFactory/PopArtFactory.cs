using ConsoleFactory.Product;

namespace ConsoleFactory
{
    class Factory2 : IFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
}
