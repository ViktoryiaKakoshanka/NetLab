namespace ConsoleFactory
{
    class ProductA2 : IProductA, IFactory
    {
        public IFactory CreateProduct(TypeProduct product)
        {
            return new ProductA2();
        }
    }
}
