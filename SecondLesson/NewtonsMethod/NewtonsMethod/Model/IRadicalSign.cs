namespace NewtonsMethod.Model
{
    public interface IRadicalSign
    {
        int Power { get; }
        double Number { get; }
        double Accuracy { get; }
        double Root { get; }
        void SetRoot(double root);
    }
}
