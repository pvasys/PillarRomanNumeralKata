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
            Assert.IsTrue("X" == 10.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedNumbersDivisibleByOneHundredItReturnsARomanNumeral()
        {
            Assert.IsTrue("M" == 1000.ToRomanNumeral());
            Assert.IsTrue("CM" == 900.ToRomanNumeral());
            Assert.IsTrue("D" == 500.ToRomanNumeral());
            Assert.IsTrue("CD" == 400.ToRomanNumeral());
            Assert.IsTrue("C" == 100.ToRomanNumeral());
            Assert.IsTrue("CC" == 200.ToRomanNumeral());
            Assert.IsTrue("CCC" == 300.ToRomanNumeral());
            Assert.IsTrue("MM" == 2000.ToRomanNumeral());
            Assert.IsTrue("DC" == 600.ToRomanNumeral());
            Assert.IsTrue("DCC" == 700.ToRomanNumeral());
            Assert.IsTrue("DCCC" == 800.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedNumbersDivisibleByTenItReturnsARomanNumeral()
        {
            Assert.IsTrue("XC" == 90.ToRomanNumeral());
            Assert.IsTrue("LX" == 60.ToRomanNumeral());
            Assert.IsTrue("XL" == 40.ToRomanNumeral());
            Assert.IsTrue("XXX" == 30.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedSingleDigitNumbersItReturnsARomanNumeral()
        {
            Assert.IsTrue("IX" == 9.ToRomanNumeral());
            Assert.IsTrue("VI" == 6.ToRomanNumeral());
            Assert.IsTrue("IV" == 4.ToRomanNumeral());
            Assert.IsTrue("III" == 3.ToRomanNumeral());
            Assert.IsTrue("I" == 1.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedComplexNumbersItReturnsARomanNumeral()
        {
            Assert.IsTrue("MLXVI" ==1066.ToRomanNumeral());
            Assert.IsTrue("MCMLXXXIX" == 1989.ToRomanNumeral());
            int maxNumeral = 3999;
            Assert.IsTrue("MMMCMXCIX" == maxNumeral.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedA64BitIntegerItReturnsARomanNumeral()
        {
            Assert.IsTrue("MLXVI" == 1066L.ToRomanNumeral());
            Assert.IsTrue("MCMLXXXIX" == 1989L.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedInvalidValuesThrowAnArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => 0.ToRomanNumeral());
            int overMaxNumeral = 4000;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => overMaxNumeral.ToRomanNumeral());
        }
    }
}
