namespace TriangleLib.View
{
    public interface ITriangleView
    {
        void ShowDetailsTriangle(string triangle, double perimeter, double area);
        void ShowWarningMessageTriangleNotExist();
    }
}
