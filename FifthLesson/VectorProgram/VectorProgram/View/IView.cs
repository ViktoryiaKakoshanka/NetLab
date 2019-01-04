using VectorProgram.Model;

namespace VectorProgram.View
{
    public interface IView
    {
        void Exit();
        string RequestInput(string message);
        void ShowErrorMessage();
        void ShowVectors(Vector first, Vector second);
        void ShowResultsOfVectorSum(Vector first, Vector second, Vector sumResult, Vector differenceResult);
        void ShowResultOfScalarProduct(Vector first, Vector second, double result);
        void ShowResultOfVectorProduct(Vector first, Vector second, Vector result);
        void ShowResultOfProductVectorByConstant(Vector first, Vector result, double multiplier);
        void ShowResultsOfVectorsComparison(Vector first, Vector second, bool equalityResult, bool inequalityResult);
        void ShowAngleBetweenVectors(Vector first, Vector second, double angle);
    }
}
