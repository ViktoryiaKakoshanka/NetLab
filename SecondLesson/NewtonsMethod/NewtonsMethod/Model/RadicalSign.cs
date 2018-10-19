using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsMethod.Model
{
    public class RadicalSign
    {
        private readonly int _power;
        private readonly double _numericalRoot, _accuracy;
        private double _result;

        public RadicalSign() : this(5.0, 2, 0.0004) { }

        /// <summary>
        /// Конструктор числа под степенным корнем
        /// </summary>
        /// <param name="numericalRoot">Число под корнем</param>
        /// <param name="power">Степень корня</param>
        /// <param name="accuracy">Точность расчета</param>
        public RadicalSign(double numericalRoot, int power, double accuracy)
        {
            _numericalRoot = numericalRoot;
            _power = power;
            _accuracy = accuracy;
        }
        
        public void SetResult(double result)
        {
            _result = result;
        }


        public int GetPower()
        {
            return _power;
        }


        public double GetNumericalRoot()
        {
            return _numericalRoot;
        }

        public double GetResult()
        {
            return _result;
        }

        public double GetAccuracy()
        {
            return _accuracy;
        }

        public void PrintData()
        {
            Console.WriteLine($"Корень степени {_power} из числа {_numericalRoot} с точностью {_accuracy}");
        }
        
    }
}
