using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VasysRomanNumeralsKata;

namespace VasysRomanNumeralsKataTest
{
    [TestClass]
    public class ConversionAutoSelectorTest
    {
        [TestMethod]
        public void WhenAutoConversionSelectorIsPassedArabicNumeralsItReturnsRomanNumerals()
        {
            Assert.IsTrue("IX" == ConversionAutoSelector.ConvertInput("9"));
        }

        [TestMethod]
        public void WhenAutoConversionSelectorIsPassedRomanNumeralsItReturnsArabicNumerals()
        {
            Assert.IsTrue("9" == ConversionAutoSelector.ConvertInput("IX"));
        }

        [TestMethod]
        public void WhenAutoConversionSelectorIsPassedEmptyStringItThrowsAnException()
        {
            Assert.ThrowsException<ArgumentException>(() => ConversionAutoSelector.ConvertInput(""));
        }
    }
}
