namespace ConsoleFactory
{
    class Factory2 : IFactory
    {
        public IFactory CreateProduct(TypeProduct product)
        {
            if (product == TypeProduct.ProductA)
            {
                return new ProductA2();
            }

            if (product == TypeProduct.ProductB)
            {
                return new ProductB2();
            }

            return null;
        }
    }
}
