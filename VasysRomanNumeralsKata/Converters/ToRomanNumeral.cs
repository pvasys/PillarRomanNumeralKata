using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VasysRomanNumeralsKata.Converters
{
    public class ToRomanNumeral
    {
        private long remainder = 0;
        private StringBuilder romanNumeralResult = new StringBuilder();

        public ToRomanNumeral(long baseTenNumber, Dictionary<long, char> alternateNumeralLookup = null)
        {
            if (null != alternateNumeralLookup)
                numeralLookup = alternateNumeralLookup;
            long largestSupportedValue = (LargestNumeral() * 4) - 1;
            if (baseTenNumber < 1 || baseTenNumber > largestSupportedValue)
                throw new ArgumentOutOfRangeException("Value cannot be represented with the given set of roman numeral values");
            remainder = (long)baseTenNumber;
        }

        // Values can be added, provided that they are added in pairs, where the first value is 
        //  the radix variable times (originally 10x) the largest current value 
        //  and the second value is the first value divided by the 
        //  factorDifferenceBetweenRepeatableNumeralAndPartialStep variable (originally 2)
        //  (e.g. if 1000 is the largest existing value, then 10000 and 5000 can be added).
        private static Dictionary<long, char> numeralLookup = new Dictionary<long, char>()
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
        private static readonly long radix = 10;
        private static readonly long factorDifferenceBetweenRepeatableNumeralAndPartialStep = 2;

        private long? largestNumeralCache = null;
        private long LargestNumeral()
        {
            if (null == largestNumeralCache)
                largestNumeralCache = numeralLookup.Keys.Max();
            return (long)largestNumeralCache;
        }

        private string romanNumeralResultCache = null;
        public string GenerateRomanNumeralRepresentation()
        {
            long currentNumeral = LargestNumeral();

            // I originally considered making this a recursive call, but determined that would add
            //  unnecessary complexity.  
            while(currentNumeral >= radix)
            {
                CalculateNumeralsForRepeatableNumeralValue(currentNumeral);
                currentNumeral /= radix;
            }

            while (0 < remainder)
            {
                romanNumeralResult.Append(numeralLookup[1]);
                remainder -= 1;
            }
            romanNumeralResultCache = romanNumeralResult.ToString();
            return romanNumeralResultCache;
        }

        private void CalculateNumeralsForRepeatableNumeralValue(long repeatableValue)
        {
            long decrementNumeralValue = repeatableValue / radix;
            CalculateNumeralsForNumeralValue(repeatableValue, decrementNumeralValue);

            long partialStepNumeralValue = repeatableValue / factorDifferenceBetweenRepeatableNumeralAndPartialStep;
            CalculateNumeralsForNumeralValue(partialStepNumeralValue, decrementNumeralValue);
        }

        private void CalculateNumeralsForNumeralValue(long numeralValue, long decrementNumeralValue)
        {
            char numeralCharacter = numeralLookup[numeralValue];
            while (remainder >= numeralValue)
            {
                romanNumeralResult.Append(numeralCharacter);
                remainder -= numeralValue;
            }

            char decrementNumeralCharacter = numeralLookup[decrementNumeralValue];
            long numeralValueMinusDecrement = numeralValue - decrementNumeralValue;
            if (remainder >= numeralValueMinusDecrement)
            {
                romanNumeralResult.Append(decrementNumeralCharacter);
                romanNumeralResult.Append(numeralCharacter);
                remainder -= numeralValueMinusDecrement;
            }
        }
    }
}
