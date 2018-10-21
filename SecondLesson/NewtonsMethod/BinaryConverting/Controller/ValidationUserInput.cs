using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverting.Controller
{
    class ValidationUserInput
    {
        public int ValidationUserInputTryInt(string UserInput)
        {
            int resultValidation = 0;
            int.TryParse(UserInput, out resultValidation);
            return resultValidation;
        }
    }
}
