using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public class RomanNumeral
    {
        private int? _baseTenRepresentation = null;
        private int remainder;

        public RomanNumeral(int baseTenNumber)
        {
            _baseTenRepresentation = baseTenNumber;
            if (_baseTenRepresentation < 1 || _baseTenRepresentation >= 4000)
                throw new ArgumentOutOfRangeException("Value cannot be represented with the given set of roman numeral values");
            remainder = (int)_baseTenRepresentation;
        }

        public string GenerateRomanNumeralRepresentation()
        {
            //if (_baseTenRepresentation < 1 || _baseTenRepresentation >= 4000)
            //    throw new ArgumentOutOfRangeException("Value cannot be represented with the given set of roman numeral values");

            StringBuilder romanNumeralBuilder = new StringBuilder();

            // 400 to 3000
            var thousandsResult = GenerateNumeralsForGivenRepeatableNumeral(1000, romanNumeralBuilder);
            romanNumeralBuilder = thousandsResult;

            // 40 to 300
            var hundredsResult = GenerateNumeralsForGivenRepeatableNumeral(100, romanNumeralBuilder);
            romanNumeralBuilder = hundredsResult;

            // 4 to 30
            var tensResult = GenerateNumeralsForGivenRepeatableNumeral(10, romanNumeralBuilder);
            romanNumeralBuilder = tensResult;


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

        // for theoretical future use, these values could be configurable
        private static readonly int factorDifferenceBetweenRepeatableNumeralAndComplementaryDecrement = 10;
        private static readonly int factorDifferenceBetweenRepeatableNumeralAndPartialStep = 2;

        private StringBuilder GenerateNumeralsForGivenRepeatableNumeral(int repeatableValue, StringBuilder romanNumeralBuilder)
        {
            int decrementNumeralValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndComplementaryDecrement;
            var repeatableNumeralResult = GenerateNumeralsForGivenNumeral(repeatableValue, decrementNumeralValue, romanNumeralBuilder);
            romanNumeralBuilder = repeatableNumeralResult;

            int partialStepNumeralValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndPartialStep;
            var partialStepNumeralResult = GenerateNumeralsForGivenNumeral(partialStepNumeralValue, decrementNumeralValue, romanNumeralBuilder);
            romanNumeralBuilder = partialStepNumeralResult;

            return romanNumeralBuilder;
        }

        private StringBuilder GenerateNumeralsForGivenNumeral(int numeralValue, int decrementNumeralValue, StringBuilder romanNumeralBuilder)
        {
            char numeralCharacter = numeralLookup[numeralValue];
            while (remainder >= numeralValue)
            {
                romanNumeralBuilder.Append(numeralCharacter);
                remainder -= numeralValue;
            }

            char decrementNumeralCharacter = numeralLookup[decrementNumeralValue];
            int numeralValueMinusDecrement = numeralValue - decrementNumeralValue;
            if (remainder >= numeralValueMinusDecrement)
            {
                romanNumeralBuilder.Append(decrementNumeralCharacter);
                romanNumeralBuilder.Append(numeralCharacter);
                remainder -= numeralValueMinusDecrement;
            }

            return romanNumeralBuilder;
        }
    }
}
