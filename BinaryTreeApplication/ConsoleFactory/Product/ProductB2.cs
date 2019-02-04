namespace ConsoleFactory
{
    class ProductB2 : IProductB, IFactory
    {
        public IFactory CreateProduct(TypeProduct product)
        {
            return new ProductB2();
        }
    }
}
