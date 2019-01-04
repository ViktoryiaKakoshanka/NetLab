using VectorProgram.Model;
using VectorProgram.View;

namespace VectorProgram.Helpers
{
    public static class ProgramRunnerHelper
    {
        public static void PerformActionsWithVectors(Vector first, Vector second, double multiplier, IView view)
        {
            ExecuteSumWithVectors(first, second, view);
            ExecuteVectorProduct(first, second, view);
            ExecuteMultiplyVectorByConstant(first, second, multiplier, view);
            ExecuteScalarProduct(first, second, view);
            CompareVectors(first, second, view);
            CalculateAngleBetweenVectors(first, second, view);
        }

        public static void ExecuteSumWithVectors(Vector first, Vector second, IView view)
        {
            var sumResult = first + second;
            var differenceResult = first - second;

            view.ShowResultsOfVectorSum(first, second, sumResult, differenceResult);
        }

        public static void ExecuteVectorProduct(Vector first, Vector second, IView view)
        {
            var vectorMultiplicationResult = VectorHelper.CalculateVectorProduct(first, second);
            view.ShowResultOfVectorProduct(first, second, vectorMultiplicationResult);
        }

        public static void ExecuteMultiplyVectorByConstant(Vector first, Vector second, double multiplier, IView view)
        {
            var result = first * multiplier;
            view.ShowResultOfProductVectorByConstant(first, result, multiplier);
        }

        public static void ExecuteScalarProduct(Vector first, Vector second, IView view)
        {
            var multiplicationResult = VectorHelper.CalculateScalarProduct(first, second);
            view.ShowResultOfScalarProduct(first, second, multiplicationResult);
        }

        public static void CompareVectors(Vector first, Vector second, IView view)
        {
            var equalityResult = first == second;
            var inequalityResult = first != second;
            view.ShowResultsOfVectorsComparison(first, second, equalityResult, inequalityResult);
        }

        public static void CalculateAngleBetweenVectors(Vector first, Vector second, IView view)
        {
            var angle = VectorHelper.CalculateAngle(first, second);
            view.ShowAngleBetweenVectors(first, second, angle);
        }
    }
}
