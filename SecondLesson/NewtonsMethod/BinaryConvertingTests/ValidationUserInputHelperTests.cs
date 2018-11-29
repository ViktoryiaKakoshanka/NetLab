using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryConverting.Controller;

namespace BinaryConvertingTests
{
    [TestClass]
    public class ValidationUserInputHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException), AllowDerivedTypes = true)]
        public void ValidationUserInput_FormatException_Test()
        {
            DataParser.ParseInt("kih");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void ValidationUserInput_ArgumentNullException_Test()
        {
            DataParser.ParseInt(null);
        }
    }
}
