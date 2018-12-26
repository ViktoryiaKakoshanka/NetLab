using TriangleLib.Model;

namespace TriangleLib.View
{
    public interface IConsoleView
    {
<<<<<<< HEAD:SecondLesson/NewtonsMethod/BinaryConverting/View/IConsoleView.cs
        string ReadLine(string message);
<<<<<<< HEAD
=======
        void WaitForAnyKeyPress();
        void ShowConvertionResult(int number, string binaryNumber);
        void ShowWarningMessageForRepeat(string messEx = null);
        void ShowMessageFormatException();
        void ShowMessageArgumentNullException();
>>>>>>> master
=======
        string RequestInput(string welcomeMessage);
        void Exit();
        void ShowTriangleDetails(Triangle triangle, double perimeter, double area);
        void ShowMessageTriangleDoesNotExist();
>>>>>>> RefactoringInLab:ThirdLesson/Triangle/Triangle/View/IView.cs
    }
}