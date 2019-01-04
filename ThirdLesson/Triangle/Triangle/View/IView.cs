using TriangleLib.Model;

namespace TriangleLib.View
{
    public interface IView
    {
        string RequestInput(string welcomeMessage);
        void Exit();
        void ShowTriangleDetails(Triangle triangle, double perimeter, double area);
        void ShowMessageTriangleDoesNotExist();
    }
}