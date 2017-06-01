using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public class FromRomanNumeral
    {
        private readonly Dictionary<char, long> numeralValueLookup = new Dictionary<char, long>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10}
        };

        public long GenerateArabicRepresentation(string romanNumeral)
        {
            long runningTotal = 0;
            long highestNumeralValue = 0;

            // Using a stack here to easily reverse the order of numerals since they are easier to process in reverse
            Stack<char> romanNumeralStack = new Stack<char>(romanNumeral);
            while (0 < romanNumeralStack.Count)
            {
                char currentNumeralCharacter = romanNumeralStack.Pop();
                long currentNumeralValue = numeralValueLookup[currentNumeralCharacter];

                if (0 < currentNumeralValue && currentNumeralValue < highestNumeralValue)
                {
                    currentNumeralValue *= -1;
                }
                else
                {
                    highestNumeralValue = currentNumeralValue;
                }
                runningTotal += currentNumeralValue;
            }
            return runningTotal;
        }
    }
}
