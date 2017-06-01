using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public static class Extension
    {
        public static string ToRomanNumeral(this int baseTenNumber)
        {
            RomanNumeral romanNumeral = new RomanNumeral(baseTenNumber);
            return romanNumeral.GenerateRomanNumeralRepresentation();
        }

        public static int ParseAsRomanNumeralToInt(this string romanNumeral)
        {
            FromRomanNumeral fromRomanNumeral = new FromRomanNumeral();
            return fromRomanNumeral.GenerateArabicRepresentation(romanNumeral);
        }
    }
}
