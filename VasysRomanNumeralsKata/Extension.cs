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
    }
}
