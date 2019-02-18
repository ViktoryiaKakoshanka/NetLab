using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Helpers
{
    public interface IProperty<T>
    {
        T GetProperty(StudentTestRegister register, string nameProperty);
    }
}
