using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsMethod.Model
{
    public interface IRadicalSign
    {
        void SetResult(double result);
        int GetPower();
        double GetNumericalRoot();
        double GetResult();
        double GetAccuracy();
        void PrintData();
    }
}
