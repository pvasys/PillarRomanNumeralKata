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
            int oneThousand = 1000;
            Assert.IsTrue(oneThousand.ToRomanNumeral() == "M");
            int nineHundred = 900;
            Assert.IsTrue(nineHundred.ToRomanNumeral() == "CM");
            int fiveHundred = 500;
            Assert.IsTrue(fiveHundred.ToRomanNumeral() == "D");
            int fourHundred = 400;
            Assert.IsTrue(fourHundred.ToRomanNumeral() == "CD");
            int oneHundred = 100;
            Assert.IsTrue(oneHundred.ToRomanNumeral() == "C");
            int twoHundred = 200;
            Assert.IsTrue(twoHundred.ToRomanNumeral() == "CC");
            int threeHundred = 300;
            Assert.IsTrue(threeHundred.ToRomanNumeral() == "CCC");
            int twoThousand = 2000;
            Assert.IsTrue(twoThousand.ToRomanNumeral() == "MM");
            int sixHundred = 600;
            Assert.IsTrue(sixHundred.ToRomanNumeral() == "DC");
            int sevenHundred = 700;
            Assert.IsTrue(sevenHundred.ToRomanNumeral() == "DCC");
            int eightHundred = 800;
            Assert.IsTrue(eightHundred.ToRomanNumeral() == "DCCC");
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedNumbersDivisibleByTenItReturnsARomanNumeral()
        {
            int ninety = 90;
            Assert.IsTrue(ninety.ToRomanNumeral() == "XC");
            int sixty = 60;
            Assert.IsTrue(sixty.ToRomanNumeral() == "LX");
            int forty = 40;
            Assert.IsTrue(forty.ToRomanNumeral() == "XL");
            int thirty = 30;
            Assert.IsTrue(thirty.ToRomanNumeral() == "XXX");
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedSingleDigitNumbersItReturnsARomanNumeral()
        {
            int nine = 9;
            Assert.IsTrue(nine.ToRomanNumeral() == "IX");
            int six = 6;
            Assert.IsTrue(six.ToRomanNumeral() == "VI");
        }
    }
}
