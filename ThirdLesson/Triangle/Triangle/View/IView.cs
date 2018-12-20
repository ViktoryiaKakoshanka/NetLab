using TriangleLib.Model;

namespace TriangleLib.View
{
    public interface IConsoleView
    {
        string ReadInput(string welcomeMessage);
        void Exit();
        void ShowTriangleDetails(Triangle triangle, double perimeter, double area);
        void ShowMessageTriangleDoesNotExist();
    }
}