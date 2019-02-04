namespace ConsoleFactory
{
    class ProductA1 : IProductA, IFactory
    {
        public IFactory CreateProduct(TypeProduct product)
        {
            return new ProductA1();
        }
    }
}
