using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public static class ConversionAutoSelector
    {
        public static string ConvertInput(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                throw new ArgumentException();
            }

            string outputValue = null;
            long numeral = 0;
            if (Int64.TryParse(input, out numeral))
                outputValue = numeral.ToRomanNumeral();
            else
                outputValue = input.ParseAsRomanNumeral().ToString();
            return outputValue;
        }
    }
}
