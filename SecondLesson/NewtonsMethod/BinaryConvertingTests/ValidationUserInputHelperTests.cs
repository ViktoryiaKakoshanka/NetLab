using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryConverting.Controller;

namespace BinaryConvertingTests
{
    /// <summary>
    /// Summary description for ValidationUserInputHelperTests
    /// </summary>
    [TestClass]
    public class ValidationUserInputHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException), AllowDerivedTypes = true)]
        public void ValidationUserInputStringTryIntTest()
        {
            ValidateUserInputHelper.ValidationUserInputTryInt("kih");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void ValidationUserInputNullTryIntTest()
        {
            ValidateUserInputHelper.ValidationUserInputTryInt(null);
        }
    }
}
