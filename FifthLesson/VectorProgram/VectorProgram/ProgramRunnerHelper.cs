using VectorProgram.Model;
using VectorProgram.View;

namespace VectorProgram
{
    public static class ProgramRunnerHelper
    {
        public static void PerformActionsWithVectors(Vector first, Vector second, double multiplier, IView view)
        {
            ExecuteSimpleActionsWithVectors(first, second, view);
            ExecuteVectorProduct(first, second, view);
            ExecuteMultiplyVectorByConstant(first, second, multiplier, view);
            ExecuteScalarProduct(first, second, view);
            ExecuteCompareVectors(first, second, view);
            ExecuteCalculatingAngleBetweenVectors(first, second, view);
        }

        public static void ExecuteSimpleActionsWithVectors(Vector first, Vector second, IView view)
        {
            var sumResult = first + second;
            var differenceResult = first - second;

            view.ShowSimpleActionsWithVectorsResults(first, second, sumResult, differenceResult);
        }

        public static void ExecuteVectorProduct(Vector first, Vector second, IView view)
        {
            var vectorMultiplicationResult = Vector.CalculateVectorProduct(first, second);
            view.ShowVectorProductResult(first, second, vectorMultiplicationResult);
        }

        public static void ExecuteMultiplyVectorByConstant(Vector first, Vector second, double multiplier, IView view)
        {
            var right = first * multiplier;
            var left = multiplier * first;
            view.ShowProductVectorsByConstantResults(first, second, right, left, multiplier);
        }

        public static void ExecuteScalarProduct(Vector first, Vector second, IView view)
        {
            var multiplicationResult = Vector.CalculateScalarProduct(first, second);
            view.ShowScalarProductResult(first, second, multiplicationResult);
        }

        public static void ExecuteCompareVectors(Vector first, Vector second, IView view)
        {
            var equalityResult = first == second;
            var inequalityResult = first != second;
            view.ShowVectorsComparisonResults(first, second, equalityResult, inequalityResult);
        }

        public static void ExecuteCalculatingAngleBetweenVectors(Vector first, Vector second, IView view)
        {
            var angle = Vector.CalculateAngle(first, second);
            view.ShowAngleBetweenVectorsResult(first, second, angle);
        }
    }
}
