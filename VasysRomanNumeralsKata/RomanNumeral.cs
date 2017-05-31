using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public class RomanNumeral
    {
        private int? _baseTenRepresentation = null;
        private int remainder = 0;
        private StringBuilder romanNumeralResult = new StringBuilder();

        public RomanNumeral(int baseTenNumber)
        {
            _baseTenRepresentation = baseTenNumber;
            if (_baseTenRepresentation < 1 || _baseTenRepresentation >= 4000)
                throw new ArgumentOutOfRangeException("Value cannot be represented with the given set of roman numeral values");
            remainder = (int)_baseTenRepresentation;
        }

        public string GenerateRomanNumeralRepresentation()
        {
            // 4xx to 3xxx
            CalculateNumeralsForGivenRepeatableNumeral(1000);

            // 4x to 3xx
            CalculateNumeralsForGivenRepeatableNumeral(100);

            // 4 to 3x
            CalculateNumeralsForGivenRepeatableNumeral(10);


            while (remainder / 1 > 0)
            {
                romanNumeralResult.Append("I");
                remainder -= 1;
            }
            return romanNumeralResult.ToString();
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

        private void CalculateNumeralsForGivenRepeatableNumeral(int repeatableValue)
        {
            int decrementNumeralValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndComplementaryDecrement;
            CalculateNumeralsForGivenNumeral(repeatableValue, decrementNumeralValue);

            int partialStepNumeralValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndPartialStep;
            CalculateNumeralsForGivenNumeral(partialStepNumeralValue, decrementNumeralValue);
        }

        private void CalculateNumeralsForGivenNumeral(int numeralValue, int decrementNumeralValue)
        {
            char numeralCharacter = numeralLookup[numeralValue];
            while (remainder >= numeralValue)
            {
                romanNumeralResult.Append(numeralCharacter);
                remainder -= numeralValue;
            }

            char decrementNumeralCharacter = numeralLookup[decrementNumeralValue];
            int numeralValueMinusDecrement = numeralValue - decrementNumeralValue;
            if (remainder >= numeralValueMinusDecrement)
            {
                romanNumeralResult.Append(decrementNumeralCharacter);
                romanNumeralResult.Append(numeralCharacter);
                remainder -= numeralValueMinusDecrement;
            }
        }
    }
}
