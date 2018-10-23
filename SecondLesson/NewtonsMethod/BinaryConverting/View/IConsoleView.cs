using BinaryConverting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverting.View
{
    interface IConsoleView
    {
        void PrintResultByConversion(INumbers number);
        void WarningMessage(string messEx = null);
    }
}
