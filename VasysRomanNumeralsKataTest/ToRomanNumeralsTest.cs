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
        public void WhenRomanNumeralExtensionIsPassedNumbersDivisibleByOneHundredItReturnsARomanNumeral()
        {
            Assert.IsTrue(1000.ToRomanNumeral() == "M");
            Assert.IsTrue(900.ToRomanNumeral() == "CM");
            Assert.IsTrue(500.ToRomanNumeral() == "D");
            Assert.IsTrue(400.ToRomanNumeral() == "CD");
            Assert.IsTrue(100.ToRomanNumeral() == "C");
            Assert.IsTrue(200.ToRomanNumeral() == "CC");
            Assert.IsTrue(300.ToRomanNumeral() == "CCC");
            Assert.IsTrue(2000.ToRomanNumeral() == "MM");
            Assert.IsTrue(600.ToRomanNumeral() == "DC");
            Assert.IsTrue(700.ToRomanNumeral() == "DCC");
            Assert.IsTrue(800.ToRomanNumeral() == "DCCC");
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedNumbersDivisibleByTenItReturnsARomanNumeral()
        {
            Assert.IsTrue(90.ToRomanNumeral() == "XC");
            Assert.IsTrue(60.ToRomanNumeral() == "LX");
            Assert.IsTrue(40.ToRomanNumeral() == "XL");
            Assert.IsTrue(30.ToRomanNumeral() == "XXX");
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedSingleDigitNumbersItReturnsARomanNumeral()
        {
            Assert.IsTrue(9.ToRomanNumeral() == "IX");
            Assert.IsTrue(6.ToRomanNumeral() == "VI");
            Assert.IsTrue(4.ToRomanNumeral() == "IV");
            Assert.IsTrue(3.ToRomanNumeral() == "III");
            Assert.IsTrue(1.ToRomanNumeral() == "I");
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedComplexNumbersItReturnsARomanNumeral()
        {
            Assert.IsTrue(1066.ToRomanNumeral() == "MLXVI");
            Assert.IsTrue(1989.ToRomanNumeral() == "MCMLXXXIX");
            int maxNumeral = 3999;
            Assert.IsTrue(maxNumeral.ToRomanNumeral() == "MMMCMXCIX");
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
