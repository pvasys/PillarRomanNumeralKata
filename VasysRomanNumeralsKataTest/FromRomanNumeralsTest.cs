using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VasysRomanNumeralsKata;

namespace VasysRomanNumeralsKataTest
{
    [TestClass]
    public class FromRomanNumeralsTest
    {
        [TestMethod]
        public void WhenStringExtensionIsPassedXItReturns10()
        {
            Assert.IsTrue(10 == "X".ParseAsRomanNumeralToLong());
        }
    }
}
