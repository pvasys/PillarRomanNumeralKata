using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata
{
    public class FromRomanNumeral
    {
        public long GenerateArabicRepresentation(string romanNumeral)
        {
            long runningTotal = 0;
            long highestNumeralValue = 0;

            // Using a stack here to easily reverse the order of numerals since they are easier to process in reverse
            Stack<char> romanNumeralStack = new Stack<char>(romanNumeral);
            while (0 < romanNumeralStack.Count)
            {
                char currentNumeralCharacter = romanNumeralStack.Pop();
                long currentNumeralValue = 0;
                if (currentNumeralCharacter.Equals('I'))
                {
                    currentNumeralValue = 1;
                }
                else if (currentNumeralCharacter.Equals('V'))
                {
                    currentNumeralValue = 5;
                }
                else if (currentNumeralCharacter.Equals('X'))
                {
                    currentNumeralValue = 10;
                }
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
