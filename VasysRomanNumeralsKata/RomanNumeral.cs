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
            if (_baseTenRepresentation < 1 || _baseTenRepresentation >= 4000)
                throw new ArgumentOutOfRangeException("Value cannot be represented with the given set of roman numeral values");

            StringBuilder romanNumeralBuilder = new StringBuilder();
            int remainder = (int)_baseTenRepresentation;

            // 400 to 3000
            var thousandsResult = GenerateNumeralsForGivenRepeatableNumeral(1000, romanNumeralBuilder, remainder);
            romanNumeralBuilder = thousandsResult.Item1;
            remainder = thousandsResult.Item2;

            // 40 to 300
            var hundredsResult = GenerateNumeralsForGivenRepeatableNumeral(100, romanNumeralBuilder, remainder);
            romanNumeralBuilder = hundredsResult.Item1;
            remainder = hundredsResult.Item2;

            // 4 to 30
            var tensResult = GenerateNumeralsForGivenRepeatableNumeral(10, romanNumeralBuilder, remainder);
            romanNumeralBuilder = tensResult.Item1;
            remainder = tensResult.Item2;


            while (remainder / 1 > 0)
            {
                romanNumeralBuilder.Append("I");
                remainder -= 1;
            }
            return romanNumeralBuilder.ToString();
        }

        private static readonly Dictionary<int, char> numeralLookup = new Dictionary<int, char>()
        {
            {1000, 'M'},
            {500, 'D'},
            {100, 'C'},
            {50, 'L'},
            {10, 'X'},
            {5, 'V'},
            {1, 'I'}
        };

        private static readonly int factorDifferenceBetweenRepeatableNumeralAndComplementaryDecrement = 10;
        private static readonly int factorDifferenceBetweenRepeatableNumeralAndPartialStep = 2;

        private Tuple<StringBuilder, int> GenerateNumeralsForGivenRepeatableNumeral(int repeatableValue, StringBuilder romanNumeralBuilder, int remainder)
        {
            char repeatableNumeral = numeralLookup[repeatableValue];
            while (remainder >= repeatableValue)
            {
                romanNumeralBuilder.Append(repeatableNumeral);
                remainder -= repeatableValue;
            }

            int decrementValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndComplementaryDecrement;
            char decrementNumeral = numeralLookup[decrementValue];
            int repeatableValueMinusDecrement = repeatableValue - decrementValue;
            if (remainder >= repeatableValueMinusDecrement)
            {
                romanNumeralBuilder.Append(decrementNumeral);
                romanNumeralBuilder.Append(repeatableNumeral);
                remainder -= repeatableValueMinusDecrement;
            }

            int halfRepeatableValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndPartialStep;
            char halfRepeatableNumeral = numeralLookup[halfRepeatableValue];
            if (remainder >= halfRepeatableValue)
            {
                romanNumeralBuilder.Append(halfRepeatableNumeral);
                remainder -= halfRepeatableValue;
            }

            int halfRepeatableMinusDecrement = halfRepeatableValue - decrementValue;
            if (remainder >= halfRepeatableMinusDecrement)
            {
                romanNumeralBuilder.Append(decrementNumeral);
                romanNumeralBuilder.Append(halfRepeatableNumeral);
                remainder -= halfRepeatableMinusDecrement;
            }

            return Tuple.Create(romanNumeralBuilder, remainder);
        }
    }
}
