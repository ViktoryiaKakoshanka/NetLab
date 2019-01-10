namespace TriangleLib.Helpers
{
    public class Validator
    {
        public static bool ValidateTriangle(double firstEdge, double secondEdge, double thirdEdge)
        {
            return firstEdge < secondEdge + thirdEdge && 
                   secondEdge < firstEdge + thirdEdge && 
                   thirdEdge < firstEdge + secondEdge;
        }
    }
}