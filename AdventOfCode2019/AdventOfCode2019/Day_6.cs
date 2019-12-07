using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day_6
    {
        public static Dictionary<string, int> orbitalDict = new Dictionary<string, int>();

        public static String[] ReadData()
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

            return orbits;
        }

        public static Dictionary<string, int> BuildOrbitalDict(string[] orbits)
        {
            Dictionary<string, int> orbitalDict = new Dictionary<string, int>();

            foreach (String orbit in orbits)
            {
                Console.WriteLine(orbit);
            }

            return orbitalDict;
        }

        public static void Part_1()
        {
            String[] orbits = ReadData();
            orbitalDict = BuildOrbitalDict(orbits);

        }

        public static void Part_2()
        {

        }
    }
}
