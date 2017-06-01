using System;

namespace VasysRomanNumeralsKata
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = ConversionAutoSelector.ConvertInput(args[0]);
            Console.WriteLine(result);
        }
    }
}