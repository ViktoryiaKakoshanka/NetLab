using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib.Controller
{
    public class ValidateTriangleHelper
    {
        public static double TryParseInputtingSide(string maybeSide)
        {
            double side = 0.0;
            double.TryParse(maybeSide.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out side);
            return side;
        }

        public static bool ValidateTriangle(double a, double b, double c)
        {
            return ((a <= b + c) && (b <= a + c) && (c <= a + b));
        }
    }
}
