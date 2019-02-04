namespace ConsoleFactory
{
    class ProductB1 : IProductB, IFactory
    {
        public IFactory CreateProduct(TypeProduct product)
        {
            return new ProductB1();
        }
    }
}
