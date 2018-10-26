using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib.Model
{
    public class Triangle
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        
        
        public override string ToString()
        {
            return A.ToString() + ", " + B.ToString() + ", " + C.ToString();
        }
    }
}
