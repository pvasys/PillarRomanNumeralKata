using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VasysRomanNumeralsKata;

namespace VasysRomanNumeralsKataTest
{
    [TestClass]
    public class ToRomanNumeralsTest
    {
        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedTenItReturnsX()
        {
            int ten = 10;
            Assert.IsTrue(ten.ToRomanNumeral() == "X");
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedAnIntegerItReturnsARomanNumeral()
        {
            int oneThousand = 1000;
            Assert.IsTrue(oneThousand.ToRomanNumeral() == "M");
            int nineHundred = 900;
            Assert.IsTrue(nineHundred.ToRomanNumeral() == "CM");
            int fiveHundred = 500;
            Assert.IsTrue(fiveHundred.ToRomanNumeral() == "D");
        }
    }
}
