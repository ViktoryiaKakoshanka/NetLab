namespace VectorProgram.Controller
{
    public class ArrayDeterminantCalculator
    {
        public static double CalculateDeterminantTwoByTwo(double[,] array)
        {
            return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
        }
    }
}
