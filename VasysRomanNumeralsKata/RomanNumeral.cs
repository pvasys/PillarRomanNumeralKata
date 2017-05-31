using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public class RomanNumeral
    {
        private int? _baseTenRepresentation = null;
        public RomanNumeral(int baseTenNumber)
        {
            _baseTenRepresentation = baseTenNumber;
        }

        public string GenerateRomanNumeralRepresntation()
        {
            StringBuilder romanNumeralBuilder = new StringBuilder();
            int remainder = (int)_baseTenRepresentation;
            while(remainder / 1000 > 0)
            {
                romanNumeralBuilder.Append("M");
                remainder -= 1000;
            }

            if (remainder >= 900)
            {
                romanNumeralBuilder.Append("CM");
                remainder -= 900;
            }

            if(remainder >= 500)
            {
                romanNumeralBuilder.Append("D");
                remainder -= 500;
            }

            if (remainder >= 400)
            {
                romanNumeralBuilder.Append("CD");
                remainder -= 400;
            }

            while(remainder >= 100)
            {
                romanNumeralBuilder.Append("C");
                remainder -= 100;
            }

            int numberOfTens = remainder / 10;
            if (numberOfTens > 0)
            {
                for (int i = 0; i < numberOfTens; i++)
                {
                    romanNumeralBuilder.Append("X");
                }
            }
            return romanNumeralBuilder.ToString();
        }
    }
}
