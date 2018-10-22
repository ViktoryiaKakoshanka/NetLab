
namespace BinaryConverting.Model
{
    public interface INumbers
    {
        int DecimalNumber { get; set; }
        string BinaryNumber { get; set; }
        void DecimalNumberOfUserInput(string userInput);
    }
}
