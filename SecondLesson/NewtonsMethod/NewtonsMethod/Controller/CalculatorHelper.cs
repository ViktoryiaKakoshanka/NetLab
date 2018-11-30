namespace NewtonsMethod.Controller
{
    public static class CalculatorHelper
    {
        /// <summary>
        /// Raising a number to a power
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="power">power</param>
        /// <returns>number {value} in degree {power}</returns>
        public static double RaiseToPower(double number, int power)
        {
            var numberConst = number;

            for (var counter = 2; counter <= power; counter++)
            {
                number *= numberConst;
            }

            return number;
        }
    }
}
