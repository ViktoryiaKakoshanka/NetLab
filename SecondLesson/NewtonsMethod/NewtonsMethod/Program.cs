using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonsMethod.View;
using NewtonsMethod.Model;
using NewtonsMethod.Controller;

namespace NewtonsMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new ConsoleView();
            view.UserInput();
            view.MethodComparisonNewtonAndPow();
        }
    }
}
