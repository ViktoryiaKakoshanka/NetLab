using VectorProgram.Model;
using VectorProgram.View;
using VectorProgram.Controller;

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
            var vectorMultiplicationResult = VectorHelper.CalculateVectorProduct(first, second);
            view.ShowVectorProductResult(first, second, vectorMultiplicationResult);
        }

        public static void ExecuteMultiplyVectorByConstant(Vector first, Vector second, double multiplier, IView view)
        {
            var result = first * multiplier;
            view.ShowProductVectorsByConstantResults(first, result, multiplier);
        }

        public static void ExecuteScalarProduct(Vector first, Vector second, IView view)
        {
            var multiplicationResult = VectorHelper.CalculateScalarProduct(first, second);
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
            var angle = VectorHelper.CalculateAngle(first, second);
            view.ShowAngleBetweenVectorsResult(first, second, angle);
        }
    }
}
