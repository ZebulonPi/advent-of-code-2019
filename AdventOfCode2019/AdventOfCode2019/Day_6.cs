using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode2019
{
    public class Day_6
    {
        public static int[] ReadData()
        {
            string text = "";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                text = System.IO.File.ReadAllText(@"/Users/jasongreenwood/advent-of-code-2019/AdventOfCode2019/AdventOfCode2019/Day_5_input.txt");
            }
            else
            {
                text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_5_input.txt");
            }

            int[] numbers = text.Split(',').Select(Int32.Parse).ToArray();

            return numbers;
        }

        public static void Part_1()
        {

        }

        public static void Part_2()
        {

        }
    }
}
