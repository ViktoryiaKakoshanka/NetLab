using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryConverting.Model;

namespace BinaryConverting.Controller
{
    class ConversionNumeric
    {
        public void DecimalToBinary(Numbers number)
        {
            byte numberLocal = number.DecimalNumber(); 
            int remainder;
            string result = string.Empty;
            while (numberLocal > 0)
            {
                remainder = numberLocal % 2;
                numberLocal /= 2;
                result = remainder.ToString() + result;
            }

            char[] resultArray = result.ToCharArray();
            Array.Reverse(resultArray);
            number.BinaryNumber(new string(resultArray));
        }
        
    }
}
