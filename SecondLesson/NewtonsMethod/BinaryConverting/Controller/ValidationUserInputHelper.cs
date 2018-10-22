using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverting.Controller
{
    public class ValidationUserInputHelper
    {
        public static int ValidationUserInputTryInt(string userInput)
        {
            int resultValidation = 0;
            resultValidation = int.Parse(userInput);
            return resultValidation;
        }
    }
}
