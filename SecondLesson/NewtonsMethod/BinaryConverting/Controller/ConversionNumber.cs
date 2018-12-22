using BinaryConverting.Model;

namespace BinaryConverting.Controller
{
    public class ConversionNumber
    {
        public void ConvertDecimalToBinary(INumbers number)
        {
            var numberLocal = number.DecimalNumber;
            var binaryNumber = string.Empty;
            while (numberLocal > 0)
            {
                var remainder = numberLocal % 2;
                numberLocal /= 2;
                binaryNumber = remainder + binaryNumber;
            }
            number.BinaryNumber = binaryNumber;
        }
    }
}
