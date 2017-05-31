using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VasysRomanNumeralsKata;

namespace VasysRomanNumeralsKataTest
{
    [TestClass]
    public class ToRomanNumeralsTest
    {
        [TestMethod]
        public void WhenRomanNumeralIsPassedTenItReturnsX()
        {
            int ten = 10;
            Assert.IsTrue(ten.ToRomanNumeral() == "X");
        }
    }
}
