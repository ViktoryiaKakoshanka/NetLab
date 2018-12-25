using BinaryConverting.Model;

namespace BinaryConverting.Helpers
{
    public static class NumberConverter
    {
        public static INumbers ConvertDecimalToBinary(this INumbers number)
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

            return new Numbers()
            {
                BinaryNumber = binaryNumber,
                DecimalNumber = number.DecimalNumber
            };
        }
    }
}