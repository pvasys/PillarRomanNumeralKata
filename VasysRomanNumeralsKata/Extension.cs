﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public static class Extension
    {
        public static string ToRomanNumeral(this long baseTenNumber)
        {
            RomanNumeral romanNumeral = new RomanNumeral(baseTenNumber);
            return romanNumeral.GenerateRomanNumeralRepresentation();
        }

        public static string ToRomanNumeral(this int baseTenNumber)
        {
            return ToRomanNumeral((long)baseTenNumber);
        }

        public static long ParseAsRomanNumeralToLong(this string romanNumeral)
        {
            FromRomanNumeral fromRomanNumeral = new FromRomanNumeral();
            return fromRomanNumeral.GenerateArabicRepresentation(romanNumeral);
        }
    }
}
