using NewtonsMethod.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsMethod.Controller
{
    public interface ICalculation
    {
        double RadicalSignByMethodNewton(IRadicalSign radicalSign);
        double MathPow(IRadicalSign radicalSign);
    }
}
