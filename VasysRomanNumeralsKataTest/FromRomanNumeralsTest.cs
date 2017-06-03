using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VasysRomanNumeralsKata;
using VasysRomanNumeralsKata.Converters;

namespace VasysRomanNumeralsKataTest
{
    [TestClass]
    public class FromRomanNumeralsTest
    {
        [TestMethod]
        public void WhenStringExtensionIsPassedXItReturns10()
        {
            Assert.AreEqual(10, "X".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralItReturnsArabic()
        {
            Assert.AreEqual(6, "VI".ParseAsRomanNumeral());
            Assert.AreEqual(46, "XLVI".ParseAsRomanNumeral());
            Assert.AreEqual(104, "CIV".ParseAsRomanNumeral());
            Assert.AreEqual(501, "DI".ParseAsRomanNumeral());
            Assert.AreEqual(1550, "MDL".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralWithUnrecognizedCharactersItReturnsArabicRepresentingTheCharactersRecognized()
        {
            Assert.AreEqual(4, "I V".ParseAsRomanNumeral());
            Assert.AreEqual(4, "IQV".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralThatViolatesSingleTheSubstractionRuleItReturnsArabic()
        {
            // See "Considerations" section of the README file for reasoning behind supporting the conversion of this type of invalid data.
            Assert.AreEqual(3, "IIV".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralInLowerCaseItReturnsArabic()
        {
            Assert.AreEqual(6, "vi".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenStringExtensionIsPassedARomanNumeralFromKataTestsItReturnsArabic()
        {
            Assert.AreEqual(1, "I".ParseAsRomanNumeral());
            Assert.AreEqual(3, "III".ParseAsRomanNumeral());
            Assert.AreEqual(9, "IX".ParseAsRomanNumeral());
            Assert.AreEqual(1066, "MLXVI".ParseAsRomanNumeral());
            Assert.AreEqual(1989, "MCMLXXXIX".ParseAsRomanNumeral());
        }

        [TestMethod]
        public void WhenFromRomanNumeralIsInitializedToUseAlternateRomanNumeralsItReturnsArabic()
        {
            // this is well outside of the scope of the kata, but it is a demonstration of the flexibility of the solution
            Dictionary<string, long> alternateNumeralValueLookup = new Dictionary<string, long>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"A", 1},
                {"B", 5},
                {"C", 10},
                {"D", 50},
                {"E", 100},
                {"F", 500},
                {"G", 1000}
            };

            FromRomanNumeral fourteen = new FromRomanNumeral("CAB", alternateNumeralValueLookup);
            Assert.AreEqual(14, fourteen.GenerateArabicRepresentation());

            FromRomanNumeral nineteenEightyNine = new FromRomanNumeral("GEGDCCCAC", alternateNumeralValueLookup);
            Assert.AreEqual(1989, nineteenEightyNine.GenerateArabicRepresentation());
        }

        [TestMethod]
        public void WhenFromRomanNumeralIsInitializedToUseExpandedRomanNumeralsItReturnsArabic()
        {
            // The real numerals over 1000 are letters with bars over them.  Since that isn't easy to
            //  re-create, I'm substituting alternate letters
            Dictionary<string, long> expandedNumeralValueLookup = new Dictionary<string, long>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"I", 1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000},
                {"B", 5000},
                {"A", 10000}
            };

            FromRomanNumeral fourteenThousandTwoHundredSixtyFour = new FromRomanNumeral("AMBCCLXIV", expandedNumeralValueLookup);
            Assert.AreEqual(14264, fourteenThousandTwoHundredSixtyFour.GenerateArabicRepresentation());
        }
    }
}
