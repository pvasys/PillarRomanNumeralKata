using System;

namespace VasysRomanNumeralsKata
{
    class Program
    {
        static void Main(string[] args)
        {
            long numeral = 0;
            Int64.TryParse(args[0], out numeral);
            string romanNumeral = numeral.ToRomanNumeral();
            Console.WriteLine(romanNumeral);
        }
    }
}