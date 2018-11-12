using BinaryConverting.Model;

namespace BinaryConverting.Controller
{
    public class ConversionNumeric: IConversionNumeric
    {
        public void ConvertDecimalToBinary(INumbers number)
        {
            int numberLocal = number.DecimalNumber; 
            int remainder;
            var binaryNumber = string.Empty;
            while (numberLocal > 0)
            {
                remainder = numberLocal % 2;
                numberLocal /= 2;
                binaryNumber = remainder.ToString() + binaryNumber;
            }
            number.BinaryNumber = binaryNumber;
        }
    }
}
