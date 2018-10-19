using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewtonsMethod.Controller
{
    public class ValidationData
    {
        public bool InputUserPower(string power)
        {
            Regex regex = new Regex(@"\d+");
            if(regex.IsMatch(power))
            {
                return true;
            }
            return false;
        }

        public bool InputUserNumericalRoot(string numericalRoot)
        {
            Regex regex = new Regex(@"\d+\.\d+|\d+");
            if (regex.IsMatch(numericalRoot))
            {
                return true;
            }
            return false;
        }

        public bool InputUserАccurancy(string accurancy)
        {
            Regex regex = new Regex(@"0\.\d+|1");
            if (regex.IsMatch(accurancy))
            {
                return true;
            }
            return false;
        }
    }
}
