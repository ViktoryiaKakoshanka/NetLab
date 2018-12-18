using MatrixProject.Model;

namespace MatrixProject.View
{
    public interface IView
    {
        void ShowMatrix(Matrix matrix, string message = null);
    }
}