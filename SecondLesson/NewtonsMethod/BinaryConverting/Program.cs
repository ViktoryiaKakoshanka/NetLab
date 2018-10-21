using BinaryConverting.View;

namespace BinaryConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            var fundamentaView = new FundamentalView();
            fundamentaView.UserInput();
            fundamentaView.PrintResultByConversion();
        }
    }
}
