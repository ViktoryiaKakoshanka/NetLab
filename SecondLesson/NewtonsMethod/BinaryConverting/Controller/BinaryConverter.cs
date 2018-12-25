using System.Text;

namespace BinaryConverting.Controller
{
    public class NumberConverter: INumberConverter
    {
        public string ConvertDecimalToBinary(int number)
        {
            int remainder;
            var binaryNumberStringBuilder = new StringBuilder();

            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                binaryNumberStringBuilder.Insert(0, remainder);
            }

            return binaryNumberStringBuilder.ToString();
        }
    }
}
