﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VasysRomanNumeralsKata.Converters
{
    public class FromRomanNumeral
    {
        private Dictionary<string, long> numeralValueLookup = new Dictionary<string, long>(StringComparer.CurrentCultureIgnoreCase)
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        private string romanNumeral = null;

        public FromRomanNumeral(string romanNumeralInput, Dictionary<string, long> alternateNumeralValueLookup = null)
        {
            romanNumeral = romanNumeralInput;
            if (null != alternateNumeralValueLookup)
            {
                numeralValueLookup = alternateNumeralValueLookup;
            }
        }

        private long? arabicRepresentationCache = null;
        public long GenerateArabicRepresentation()
        {
            if (null != arabicRepresentationCache)
            {
                return (long)arabicRepresentationCache;
            }

            long runningTotal = 0;
            long highestNumeralValue = 0;

            // Using a stack here to easily reverse the order of numerals since they are easier to process in reverse
            Stack<char> romanNumeralStack = new Stack<char>(romanNumeral);
            while (0 < romanNumeralStack.Count)
            {
                string currentNumeralCharacter = romanNumeralStack.Pop().ToString();

                // check for, and skip, unrecognized characters
                if (!numeralValueLookup.ContainsKey(currentNumeralCharacter.ToString()))
                {
                    continue;
                }

                long currentNumeralValue = numeralValueLookup[currentNumeralCharacter];

                if (0 < currentNumeralValue && currentNumeralValue < highestNumeralValue)
                {
                    currentNumeralValue *= -1;
                }

                // sanity check
                else if(0 < currentNumeralValue)
                {
                    highestNumeralValue = currentNumeralValue;
                }
                runningTotal += currentNumeralValue;
            }

            arabicRepresentationCache = runningTotal;
            return (long)arabicRepresentationCache;
        }
    }
}
