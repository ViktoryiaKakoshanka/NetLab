using BinaryConverting.Model;

namespace BinaryConverting.Controller
{
    public class ConversionNumeric: IConversionNumeric
    {
        public void NumberDecimalToBinary(INumbers number)
        {
            int numberLocal = number.DecimalNumber; 
            int remainder;
            var result = string.Empty;
            while (numberLocal > 0)
            {
                remainder = numberLocal % 2;
                numberLocal /= 2;
                result = remainder.ToString() + result;
            }
            number.BinaryNumber = result;
        }
        
    }
}
