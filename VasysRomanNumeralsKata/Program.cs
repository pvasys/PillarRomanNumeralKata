using System;

namespace VasysRomanNumeralsKata
{
    class Program
    {
        private const string invalidInputMessage = "Usage: dotnet run <arabic numeral or roman numeral>\n   Example:  'dotnet run 1234' or 'dotnet run MCCXXXIV'";

        static void Main(string[] args)
        {
            string message = null;
            if (1 == args.Length)
            {
                try
                {
                    message = ConversionAutoSelector.ConvertInput(args[0]);
                }
                catch (ArgumentException e)
                {
                    // message defined here instead of within the ConversionAutoSelector as it could be called from other UIs, where usage would vary.
                    message = invalidInputMessage;
                }
            }
            else
            {
                message = invalidInputMessage;
            }
            Console.WriteLine(message);
        }
    }
}