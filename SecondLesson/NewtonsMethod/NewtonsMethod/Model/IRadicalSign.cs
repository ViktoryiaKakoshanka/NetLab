namespace NewtonsMethod.Model
{
    public interface IRadicalSign
    {
        int Power { get; }
        double NumericalRoot { get; }
        double Accuracy { get; }
        double Result { get; set;  }
    }
}
