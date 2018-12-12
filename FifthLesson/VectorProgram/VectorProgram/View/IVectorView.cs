using System.Collections.Generic;
using VectorProgram.Model;

namespace VectorProgram.View
{
    internal interface IVectorView
    {
        void ShowVectors(IList<Vector> vectors);

        void ShowSimpleActionsWithVectorsResults(Vector first, Vector second, Vector sumResult, Vector differenceResult);

        void ShowScalarMultiplicationResult(Vector first, Vector second, double result);

        void ShowVectorsMultiplicationResult(Vector first, Vector second, Vector result);

        void ShowMultiplicationVectorsByNumberResults(Vector first, Vector second, IList<Vector> resultNumberRight, IList<Vector> resultNumberLeft, double multiplier);

        void ShowVectorsComparisonResults(Vector first, Vector second, bool equalityResult, bool inequalityResult);

        void ShowAngleBetweenVectorsResult(Vector first, Vector second, double angle);
    }
}
