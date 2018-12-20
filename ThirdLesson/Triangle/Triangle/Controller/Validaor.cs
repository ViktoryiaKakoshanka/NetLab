namespace TriangleLib.Controller
{
    public class Validator
    {
        public static bool ValidateTriangle(double firstSide, double secondSide, double thirdSide)
        {
            return firstSide <= secondSide + thirdSide && 
                   secondSide <= firstSide + thirdSide && 
                   thirdSide <= firstSide + secondSide;
        }
    }
}