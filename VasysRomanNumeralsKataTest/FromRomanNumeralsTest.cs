﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralItReturnsArabic()
        {
            Assert.IsTrue(6 == "VI".ParseAsRomanNumeralToLong());
            Assert.IsTrue(46 == "XLVI".ParseAsRomanNumeralToLong());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralWithUnrecognizedCharactersItReturnsArabicRepresentingTheCharactersRecognized()
        {
            Assert.IsTrue(4 == "I V".ParseAsRomanNumeralToLong());
            Assert.IsTrue(4 == "IQV".ParseAsRomanNumeralToLong());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralInLowerCaseItReturnsArabic()
        {
            Assert.IsTrue(6 == "vi".ParseAsRomanNumeralToLong());
        }
    }
}
