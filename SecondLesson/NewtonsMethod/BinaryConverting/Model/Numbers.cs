using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverting.Model
{
    class Numbers
    {
        private byte _decNumeric;
        private string _binNumeric;

        public void DecimalNumber(byte decNumeric)
        {
            _decNumeric = decNumeric;
        }

        public void BinaryNumber(string binNumeric)
        {
            _binNumeric = binNumeric;
        }

        public byte DecimalNumber()
        {
            return _decNumeric;
        }

        public string BinaryNumber()
        {
            return _binNumeric;
        }
    }
}
