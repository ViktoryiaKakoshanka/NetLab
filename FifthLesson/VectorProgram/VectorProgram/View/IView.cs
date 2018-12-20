using VectorProgram.Model;

namespace VectorProgram.View
{
    public interface IView
    {
        void Exit();
        string ReadLine(string message);
        void ShowErrorMessage();
        void ShowVectors(Vector first, Vector second);
        void ShowSimpleActionsWithVectorsResults(Vector first, Vector second, Vector sumResult, Vector differenceResult);
        void ShowScalarProductResult(Vector first, Vector second, double result);
        void ShowVectorProductResult(Vector first, Vector second, Vector result);
        void ShowProductVectorsByConstantResults(Vector first, Vector result, double multiplier);
        void ShowVectorsComparisonResults(Vector first, Vector second, bool equalityResult, bool inequalityResult);
        void ShowAngleBetweenVectorsResult(Vector first, Vector second, double angle);
    }
}
