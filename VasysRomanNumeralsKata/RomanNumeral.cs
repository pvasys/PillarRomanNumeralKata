using System;
using System.Collections.Generic;
using System.Linq;
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
            int largestSupportedValue = (LargestNumeral() * 4) - 1;
            if (_baseTenRepresentation < 1 || _baseTenRepresentation > largestSupportedValue)
                throw new ArgumentOutOfRangeException("Value cannot be represented with the given set of roman numeral values");
            remainder = (int)_baseTenRepresentation;
        }

        // Values can be added, provided that they are added in pairs, where the first value is 
        //  the radix variable times (originally 10x) the largest current value 
        //  and the second value is the first value divided by the 
        //  factorDifferenceBetweenRepeatableNumeralAndPartialStep variable (originally 2)
        //  (e.g. if 1000 is the largest existing value, then 10000 and 5000 can be added).
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

        // For theoretical future use, these values could be configurable.  Radix is much more likely to be configured,
        //  but factorDifferenceBetweenRepeatableNumeralAndPartialStep might be considered for larger radix values.
        //  The radix must always be evenly divisible by the factorDifferenceBetweenRepeatableNumeralAndPartialStep.
        private static readonly int radix = 10;
        private static readonly int factorDifferenceBetweenRepeatableNumeralAndPartialStep = 2;

        private static int LargestNumeral()
        {
            return numeralLookup.Keys.Max();
        }

        public string GenerateRomanNumeralRepresentation()
        {
            int currentNumeral = LargestNumeral();

            // I originally considered making this a recursive call, but determined that would add
            //  unnecessary complexity.  
            while(currentNumeral >= radix)
            {
                CalculateNumeralsForRepeatableNumeralValue(currentNumeral);
                currentNumeral /= radix;
            }

            while (remainder > 0)
            {
                romanNumeralResult.Append(numeralLookup[1]);
                remainder -= 1;
            }
            return romanNumeralResult.ToString();
        }

        private void CalculateNumeralsForRepeatableNumeralValue(int repeatableValue)
        {
            int decrementNumeralValue = repeatableValue / radix;
            CalculateNumeralsForNumeralValue(repeatableValue, decrementNumeralValue);

            int partialStepNumeralValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndPartialStep;
            CalculateNumeralsForNumeralValue(partialStepNumeralValue, decrementNumeralValue);
        }

        private void CalculateNumeralsForNumeralValue(int numeralValue, int decrementNumeralValue)
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
