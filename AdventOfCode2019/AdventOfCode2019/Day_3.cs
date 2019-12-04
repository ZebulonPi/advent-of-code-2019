using System;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day_3
    {
        public static void Part_1()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_3_input.txt");

            string[] wires = text.Split('\n').ToArray();

            foreach (string wire in wires)
            {
                Console.WriteLine(wire);
            }
        }


        public static void Part_2()
        {

        }
    }
}
