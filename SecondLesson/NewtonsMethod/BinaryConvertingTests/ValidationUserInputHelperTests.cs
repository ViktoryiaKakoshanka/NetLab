﻿using System;
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
        public void ValidationUserInput_FormatExceptionTest()
        {
            ValidatingInputDataHelper.ValidateDataInputTryInt("kih");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void ValidationUserInput_ArgumentNullExceptionTest()
        {
            ValidatingInputDataHelper.ValidateDataInputTryInt(null);
        }
    }
}
