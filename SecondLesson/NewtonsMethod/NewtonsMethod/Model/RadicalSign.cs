using System;

namespace NewtonsMethod.Model
{
    public class RadicalSign: IRadicalSign
    {
        private readonly int _power;
        private readonly double _numericalRoot, _accuracy;
        private double _result;

        public RadicalSign() : this(5.0, 2, 0.0004) { }

        /// <summary>
        /// Number constructor under the power root
        /// </summary>
        /// <param name="numericalRoot">Number under the root</param>
        /// <param name="power">Root degree</param>
        /// <param name="accuracy">Calculation accuracy</param>
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
            return Math.Round(_result, 5);
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
