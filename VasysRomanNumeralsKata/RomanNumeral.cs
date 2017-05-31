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
            int numberOfThousands = (int)_baseTenRepresentation / 1000;
            if (numberOfThousands > 0)
            {
                for(int i = 0; i < numberOfThousands; i++)
                {
                    romanNumeralBuilder.Append("M");
                }
            }
            int remainder = (int)_baseTenRepresentation % 1000;

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
