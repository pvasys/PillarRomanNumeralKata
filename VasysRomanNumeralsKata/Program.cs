using System;

namespace VasysRomanNumeralsKata
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeral = 0;
            Int32.TryParse(args[0], out numeral);
            string romanNumeral = numeral.ToRomanNumeral();
            Console.WriteLine(romanNumeral);
        }
    }
}