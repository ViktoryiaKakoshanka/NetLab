namespace TriangleLib.Helpers
{
    public class TriangleValidator
    {
        public static bool Validate(double firstEdge, double secondEdge, double thirdEdge)
        {
            return firstEdge < secondEdge + thirdEdge && 
                   secondEdge < firstEdge + thirdEdge && 
                   thirdEdge < firstEdge + secondEdge;
        }
    }
}