
using BinaryConverting.Controller;
using BinaryConverting.View;
using System;

namespace BinaryConverting.Model
{
    class Numbers: INumbers
    {
        public int DecimalNumber { get; set; }
        public string BinaryNumber { get; set; }        
    }
}
