using System;
using System.Collections.Generic;
using System.Text;
using VasysRomanNumeralsKata.Converters;

namespace VasysRomanNumeralsKata
{
    public static class Extension
    {
        public static string ToRomanNumeral(this long baseTenNumber)
        {
            ToRomanNumeral romanNumeral = new ToRomanNumeral(baseTenNumber);
            return romanNumeral.GenerateRomanNumeralRepresentation();
        }

        public static string ToRomanNumeral(this int baseTenNumber)
        {
            return ToRomanNumeral((long)baseTenNumber);
        }

        public static long ParseAsRomanNumeral(this string romanNumeral)
        {
            FromRomanNumeral fromRomanNumeral = new FromRomanNumeral(romanNumeral);
            return fromRomanNumeral.GenerateArabicRepresentation();
        }
    }
}
