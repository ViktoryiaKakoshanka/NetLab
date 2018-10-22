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
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValidationUserInputTryIntTest()
        {
            ValidationUserInputHelper.ValidationUserInputTryInt("kih");
        }
    }
}
