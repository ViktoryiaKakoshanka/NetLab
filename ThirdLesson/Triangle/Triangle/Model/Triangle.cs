using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib.Model
{
    public class Triangle
    {
        private double _a, _b, _c;

        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double GetA() { return _a; }

        public double GetB() { return _b; }

        public double GetC() { return _c; }
        
        public override string ToString()
        {
            return _a.ToString() + ", " + _b.ToString() + ", " + _c.ToString();
        }
    }
}
