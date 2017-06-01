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
        public void WhenAutoConversionSelectorIsPassedArabicCharactersItReturnsRomanNumerals()
        {
            Assert.IsTrue("IX" == ConversionAutoSelector.ConvertInput("9"));
        }
    }
}
