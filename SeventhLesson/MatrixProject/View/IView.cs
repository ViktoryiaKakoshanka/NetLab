namespace MatrixProject.View
{
    public interface IView
    {
        void ShowMatrix(double[,] matrix, string message = null);
    }
}