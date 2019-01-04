namespace NewtonsMethod.Model
{
    public class RadicalSign: IRadicalSign
    {
        public int Power { get; }
        public double Number { get; }
        public double Accuracy { get; }
        public double Root { get; private set; }

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
