using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VasysRomanNumeralsKata;
using System.Collections.Generic;
using VasysRomanNumeralsKata.Converters;

namespace VasysRomanNumeralsKataTest
{
    [TestClass]
    public class ToRomanNumeralsTest
    {
        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedTenItReturnsX()
        {
            Assert.AreEqual("X", 10.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedNumbersDivisibleByOneHundredItReturnsARomanNumeral()
        {
            Assert.AreEqual("M", 1000.ToRomanNumeral());
            Assert.AreEqual("CM", 900.ToRomanNumeral());
            Assert.AreEqual("D", 500.ToRomanNumeral());
            Assert.AreEqual("CD", 400.ToRomanNumeral());
            Assert.AreEqual("C", 100.ToRomanNumeral());
            Assert.AreEqual("CC", 200.ToRomanNumeral());
            Assert.AreEqual("CCC", 300.ToRomanNumeral());
            Assert.AreEqual("MM", 2000.ToRomanNumeral());
            Assert.AreEqual("DC", 600.ToRomanNumeral());
            Assert.AreEqual("DCC", 700.ToRomanNumeral());
            Assert.AreEqual("DCCC", 800.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedNumbersDivisibleByTenItReturnsARomanNumeral()
        {
            Assert.AreEqual("XC", 90.ToRomanNumeral());
            Assert.AreEqual("LX", 60.ToRomanNumeral());
            Assert.AreEqual("XL", 40.ToRomanNumeral());
            Assert.AreEqual("XXX", 30.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedSingleDigitNumbersItReturnsARomanNumeral()
        {
            Assert.AreEqual("IX", 9.ToRomanNumeral());
            Assert.AreEqual("VI", 6.ToRomanNumeral());
            Assert.AreEqual("IV", 4.ToRomanNumeral());
            Assert.AreEqual("III", 3.ToRomanNumeral());
            Assert.AreEqual("I", 1.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedComplexNumbersItReturnsARomanNumeral()
        {
            Assert.AreEqual("MLXVI",1066.ToRomanNumeral());
            Assert.AreEqual("MCMLXXXIX", 1989.ToRomanNumeral());
            int maxNumeral = 3999;
            Assert.AreEqual("MMMCMXCIX", maxNumeral.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedA64BitIntegerItReturnsARomanNumeral()
        {
            Assert.AreEqual("MLXVI", 1066L.ToRomanNumeral());
            Assert.AreEqual("MCMLXXXIX", 1989L.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenRomanNumeralExtensionIsPassedInvalidValuesThrowAnArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => 0.ToRomanNumeral());
            int overMaxNumeral = 4000;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => overMaxNumeral.ToRomanNumeral());
        }

        [TestMethod]
        public void WhenToRomanNumeralIsInitializedToUseAlternateRomanNumeralsItReturnsARomanNumeral()
        {
            Dictionary<long, char> alternateNumeralLookup = new Dictionary<long, char>()
            {
                {1000, 'G'},
                {500, 'F'},
                {100, 'E'},
                {50, 'D'},
                {10, 'C'},
                {5, 'B'},
                {1, 'A'}
            };

            ToRomanNumeral fourteen = new ToRomanNumeral(14, alternateNumeralLookup);
            Assert.AreEqual("CAB", fourteen.GenerateRomanNumeralRepresentation());

            ToRomanNumeral nineteenEightyNine = new ToRomanNumeral(1989, alternateNumeralLookup);
            Assert.AreEqual("GEGDCCCAC", nineteenEightyNine.GenerateRomanNumeralRepresentation());
        }

        [TestMethod]
        public void WhenToRomanNumeralIsInitializedToUseExpandedRomanNumeralsItReturnsARomanNumeral()
        {
            // The real numerals over 1000 are letters with bars over them.  Since that isn't easy to
            //  re-create, I'm substituting alternate letters
            Dictionary<long, char> expandedNumeralLookup = new Dictionary<long, char>()
            {
                {10000, 'A'},
                {5000, 'B'},
                {1000, 'M'},
                {500, 'D'},
                {100, 'C'},
                {50, 'L'},
                {10, 'X'},
                {5, 'V'},
                {1, 'I'}
            };

            ToRomanNumeral fourteenThousandTwoHundredSixtyFour = new ToRomanNumeral(14264, expandedNumeralLookup);
            Assert.AreEqual("AMBCCLXIV", fourteenThousandTwoHundredSixtyFour.GenerateRomanNumeralRepresentation());

            int overMaxNumeral = 40000;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => overMaxNumeral.ToRomanNumeral());
        }
    }
}
