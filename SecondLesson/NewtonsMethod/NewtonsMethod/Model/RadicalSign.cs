namespace NewtonsMethod.Model
{
    public class RadicalSign: IRadicalSign
    {
        public int Power { get; }
        public double Number { get; }
        public double Accuracy { get; }
        public double Root { get; private set; }

        /// <summary>
        /// Number constructor under the power root
        /// </summary>
        /// <param name="numericalRoot">Number under the root</param>
        /// <param name="power">Root degree</param>
        /// <param name="accuracy">Calculation accuracy</param>
        public RadicalSign(double numericalRoot, int power, double accuracy)
        {
            Number = numericalRoot;
            Power = power;
            Accuracy = accuracy;
        }

        public void SetRoot(double root)
        {
            Root = root;
        }
        
        public override string ToString()
        {
            return $"The root of the {Power} degree from {Number} with accuracy {Accuracy}";
        }
        
    }
}
