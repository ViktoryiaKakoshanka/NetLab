namespace ConsoleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(new Factory1().CreateProduct(TypeProduct.ProductA));
        }
    }
}
