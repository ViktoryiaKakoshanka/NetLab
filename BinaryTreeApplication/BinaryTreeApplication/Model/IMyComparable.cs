namespace BinaryTreeApplication.Model
{
    public interface IMyComparable<TValue>
    {
        int CompareTo(TValue other);
    }
}
