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
            Assert.IsTrue(10 == "X".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralItReturnsArabic()
        {
            Assert.IsTrue(6 == "VI".ParseAsRomanNumeral());
            Assert.IsTrue(46 == "XLVI".ParseAsRomanNumeral());
            Assert.IsTrue(104 == "CIV".ParseAsRomanNumeral());
            Assert.IsTrue(501 == "DI".ParseAsRomanNumeral());
            Assert.IsTrue(1550 == "MDL".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralWithUnrecognizedCharactersItReturnsArabicRepresentingTheCharactersRecognized()
        {
            Assert.IsTrue(4 == "I V".ParseAsRomanNumeral());
            Assert.IsTrue(4 == "IQV".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralThatViolatesSingleTheSubstractionRuleItReturnsArabic()
        {
            // See "Considerations" section of the README file for reasoning behind supporting the conversion of this type of invalid data.
            Assert.IsTrue(3 == "IIV".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralInLowerCaseItReturnsArabic()
        {
            Assert.IsTrue(6 == "vi".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralFromKataTestsItReturnsArabic()
        {
            Assert.IsTrue(1 == "I".ParseAsRomanNumeral());
            Assert.IsTrue(3 == "III".ParseAsRomanNumeral());
            Assert.IsTrue(9 == "IX".ParseAsRomanNumeral());
            Assert.IsTrue(1066 == "MLXVI".ParseAsRomanNumeral());
            Assert.IsTrue(1989 == "MCMLXXXIX".ParseAsRomanNumeral());
        }
    }
}
