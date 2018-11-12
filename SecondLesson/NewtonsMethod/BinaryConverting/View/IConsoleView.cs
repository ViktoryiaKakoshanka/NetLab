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
        void ShowResultByConversion(INumbers number);
        void ShowWarningMessage(string messEx = null);
    }
}
