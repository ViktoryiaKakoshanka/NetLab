namespace ConsoleFactory
{
    class Factory1 : IFactory
    {
        public IFactory CreateProduct(TypeProduct product)
        {
            if (product == TypeProduct.ProductA)
            {
                return new ProductA1();
            }

            if (product == TypeProduct.ProductB)
            {
                return new ProductB1();
            }

            return null;
        }
    }
}
