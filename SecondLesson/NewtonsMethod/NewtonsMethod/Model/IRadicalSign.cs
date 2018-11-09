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
