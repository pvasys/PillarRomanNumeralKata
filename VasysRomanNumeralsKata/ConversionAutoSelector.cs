using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public static class ConversionAutoSelector
    {
        public static string ConvertInput(string input)
        {
            string outputValue = null;
            long numeral = 0;
            if (Int64.TryParse(input, out numeral))
                outputValue = numeral.ToRomanNumeral();
            else
                outputValue = input.ParseAsRomanNumeralToLong().ToString();
            return outputValue;
        }
    }
}
