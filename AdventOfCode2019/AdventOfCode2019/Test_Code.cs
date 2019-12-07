using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode2019
{
    public class Test_Code
    {
        public static void Digit_parsing()
        {
            int myNumber = 1001;

            var myString = myNumber.ToString("D5");

            var charArray = myString.ToCharArray(); //{'1','2','3','4','5'}

            int[] opcoDigits = Array.ConvertAll(charArray, c => (int)Char.GetNumericValue(c));

            foreach (int digit in opcoDigits)
            {
                Console.WriteLine(digit);
            }
        }

        public static void TextParsing()
        {
            string text = "";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                text = System.IO.File.ReadAllText(@"/Users/jasongreenwood/advent-of-code-2019/AdventOfCode2019/AdventOfCode2019/Day_6_test_input.txt");
            }
            else
            {
                text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_6_test_input.txt");
            }
            string[] orbits = text.Split('\n').ToArray();

            foreach(String orbit in orbits)
            {
                Console.WriteLine(orbit);
            }
        }
    }
}
