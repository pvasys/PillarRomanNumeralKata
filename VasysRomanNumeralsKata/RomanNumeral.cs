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

        public string GenerateRomanNumeralRepresentation()
        {
            StringBuilder romanNumeralBuilder = new StringBuilder();
            int remainder = (int)_baseTenRepresentation;

            // 400 to 3000
            RepeatableNumeralSet thousandsNumeralSet = new RepeatableNumeralSet();
            thousandsNumeralSet.RepeatableNumeral = new NumeralValuePair() { Numeral = 'M', Value = 1000 };
            thousandsNumeralSet.HalfRepeatableNumeral = new NumeralValuePair() { Numeral = 'D', Value = 500 };
            thousandsNumeralSet.NextLowestRepeatableNumeral = new NumeralValuePair() { Numeral = 'C', Value = 100 };

            var thousandsResult = GenerateNumeralsForGivenRepeatableNumeral(thousandsNumeralSet, romanNumeralBuilder, remainder);
            romanNumeralBuilder = thousandsResult.Item1;
            remainder = thousandsResult.Item2;

            // 40 to 300
            RepeatableNumeralSet hundredsNumeralSet = new RepeatableNumeralSet();
            hundredsNumeralSet.RepeatableNumeral = new NumeralValuePair() { Numeral = 'C', Value = 100 };
            hundredsNumeralSet.HalfRepeatableNumeral = new NumeralValuePair() { Numeral = 'L', Value = 50 };
            hundredsNumeralSet.NextLowestRepeatableNumeral = new NumeralValuePair() { Numeral = 'X', Value = 10 };

            var hundredsResult = GenerateNumeralsForGivenRepeatableNumeral(hundredsNumeralSet, romanNumeralBuilder, remainder);
            romanNumeralBuilder = hundredsResult.Item1;
            remainder = hundredsResult.Item2;

            // 4 to 30
            RepeatableNumeralSet tensNumeralSet = new RepeatableNumeralSet();
            tensNumeralSet.RepeatableNumeral = new NumeralValuePair() { Numeral = 'X', Value = 10 };
            tensNumeralSet.HalfRepeatableNumeral = new NumeralValuePair() { Numeral = 'V', Value = 5 };
            tensNumeralSet.NextLowestRepeatableNumeral = new NumeralValuePair() { Numeral = 'I', Value = 1 };

            var tensResult = GenerateNumeralsForGivenRepeatableNumeral(tensNumeralSet, romanNumeralBuilder, remainder);
            romanNumeralBuilder = tensResult.Item1;
            remainder = tensResult.Item2;


            //while (remainder / 10 > 0)
            //{
            //    romanNumeralBuilder.Append("X");
            //    remainder -= 10;
            //}
            return romanNumeralBuilder.ToString();
        }

        private struct NumeralValuePair
        {
            public char Numeral { get; set; }
            public int Value { get; set; }
        }

        private struct RepeatableNumeralSet
        {
            public NumeralValuePair RepeatableNumeral { get; set; }
            public NumeralValuePair HalfRepeatableNumeral { get; set; }
            public NumeralValuePair NextLowestRepeatableNumeral { get; set; }
        }

        private Tuple<StringBuilder, int> GenerateNumeralsForGivenRepeatableNumeral(RepeatableNumeralSet repeatableNumeralSet, StringBuilder romanNumeralBuilder, int remainder)
        {
            int repeatableNumeralValue = repeatableNumeralSet.RepeatableNumeral.Value;
            char repeatableNumeralChar = repeatableNumeralSet.RepeatableNumeral.Numeral;
            while (remainder / repeatableNumeralValue > 0)
            {
                romanNumeralBuilder.Append(repeatableNumeralChar);
                remainder -= repeatableNumeralValue;
            }

            int nextLowestRepeatableNumeralValue = repeatableNumeralSet.NextLowestRepeatableNumeral.Value;
            char nextLowestRepeatableNumeralChar = repeatableNumeralSet.NextLowestRepeatableNumeral.Numeral;
            int repeatableMinusDecrement = repeatableNumeralValue - nextLowestRepeatableNumeralValue;
            if (remainder >= repeatableMinusDecrement)
            {
                romanNumeralBuilder.Append(nextLowestRepeatableNumeralChar);
                romanNumeralBuilder.Append(repeatableNumeralChar);
                remainder -= repeatableMinusDecrement;
            }

            int halfRepeatableNumeralValue = repeatableNumeralSet.HalfRepeatableNumeral.Value;
            char halfRepeatableNumeralChar = repeatableNumeralSet.HalfRepeatableNumeral.Numeral;
            if (remainder >= halfRepeatableNumeralValue)
            {
                romanNumeralBuilder.Append(halfRepeatableNumeralChar);
                remainder -= halfRepeatableNumeralValue;
            }

            int halfRepeatableMinusDecrement = halfRepeatableNumeralValue - nextLowestRepeatableNumeralValue;
            if (remainder >= halfRepeatableMinusDecrement)
            {
                romanNumeralBuilder.Append(nextLowestRepeatableNumeralChar);
                romanNumeralBuilder.Append(halfRepeatableNumeralChar);
                remainder -= halfRepeatableMinusDecrement;
            }

            return Tuple.Create(romanNumeralBuilder, remainder);
        }
    }
}
