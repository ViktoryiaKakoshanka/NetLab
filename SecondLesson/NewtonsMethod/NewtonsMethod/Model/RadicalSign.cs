﻿namespace NewtonsMethod.Model
{
    public class RadicalSign: IRadicalSign
    {
        public int Power { get; private set; }
        public double NumericalRoot { get; private set; }
        public double Accuracy { get; private set; }
        public double Result { get; set; }
        
        public RadicalSign() : this(5.0, 2, 0.0004) { }

        /// <summary>
        /// Number constructor under the power root
        /// </summary>
        /// <param name="numericalRoot">Number under the root</param>
        /// <param name="power">Root degree</param>
        /// <param name="accuracy">Calculation accuracy</param>
        public RadicalSign(double numericalRoot, int power, double accuracy)
        {
            NumericalRoot = numericalRoot;
            Power = power;
            Accuracy = accuracy;
        }
        
        public override string ToString()
        {
            return $"The root of the {Power} degree from {NumericalRoot} with accuracy {Accuracy}";
        }
        
    }
}
