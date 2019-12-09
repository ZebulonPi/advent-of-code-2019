using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day_6
    {
        public static Dictionary<string, string> orbitalDict = new Dictionary<string, string>();
        public static List<string> planetList = new List<string>();
        public static List<string> myList = new List<string>();
        public static List<string> santaList = new List<string>();

        public static String[] ReadData()
        {
            string text = "";

                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    text = System.IO.File.ReadAllText(@"/Users/jasongreenwood/advent-of-code-2019/AdventOfCode2019/AdventOfCode2019/Day_6_input.txt");
                }
                else
                {
                    text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_6_input.txt");
                }
                string[] orbits = text.Split('\n').ToArray();

            return orbits;
        }

        public static void BuildOrbitalDict(string[] orbits)
        {
            orbitalDict.Add("COM", null);

            foreach (String orbit in orbits)
            {
                int start = orbit.IndexOf(')')+1;
                int length = orbit.Length - orbit.IndexOf(')') - 1;

                String parentPlanet = orbit.Substring(0, orbit.IndexOf(')'));
                String planet = orbit.Substring(start, length);

                orbitalDict.Add(planet, parentPlanet);
            }
        }

        public static void BuildPlanetList(string[] orbits)
        {
            planetList.Add("COM");

            foreach (String orbit in orbits)
            {
                int start = orbit.IndexOf(')') + 1;
                int length = orbit.Length - orbit.IndexOf(')') - 1;

                String planet = orbit.Substring(start, length);

                planetList.Add(planet);
            }
        }

        public static int FindOrbitCount(string planet, string targetPlanet)
        {
            int numOfOrbits = 1;

            if (orbitalDict[planet] == targetPlanet) // We're at COM
            {
                return 0;
            }
            else
            {
                numOfOrbits += FindOrbitCount(orbitalDict[planet], targetPlanet);
                return numOfOrbits;
            }
        }

        public static string FindMyOrbits(string planet)
        {
            if (orbitalDict[planet] == null) // We're at COM
            {
                return "COM";
            }
            else
            {
                myList.Add(FindMyOrbits(orbitalDict[planet]));
                return orbitalDict[planet];
            }
        }

        public static string FindSantasOrbits(string planet)
        {
            if (orbitalDict[planet] == null) // We're at COM
            {
                return "COM";
            }
            else
            {
                santaList.Add(FindSantasOrbits(orbitalDict[planet]));
                return orbitalDict[planet];
            }
        }

        public static void Part_1()
        {
            int totalOrbits = 0;

            String[] orbits = ReadData();
            BuildOrbitalDict(orbits);
            BuildPlanetList(orbits);

            foreach(string planet in planetList)
            {
                totalOrbits += FindOrbitCount(planet, null);
            }

            Console.WriteLine(totalOrbits);

        }

        public static void Part_2()
        {
            String[] orbits = ReadData();
            BuildOrbitalDict(orbits);
            BuildPlanetList(orbits);

            FindMyOrbits("YOU");
            FindSantasOrbits("SAN");

            List<string> commonPlanets = myList.Intersect(santaList).ToList();

            int myClosestCommonPlanet = 0;
            int santasClosestCommonPlanet = 0;

            foreach (string planet in commonPlanets)
            {
                if (myList.IndexOf(planet) > myClosestCommonPlanet)
                {
                    myClosestCommonPlanet = myList.IndexOf(planet);
                }
                if (santaList.IndexOf(planet) > santasClosestCommonPlanet)
                {
                    santasClosestCommonPlanet = santaList.IndexOf(planet);
                }
            }

            string commonPlanet = myList[myClosestCommonPlanet];

            int myCountToCommon = FindOrbitCount("YOU", commonPlanet);
            int santasCountToCommon = FindOrbitCount("SAN", commonPlanet);

            Console.WriteLine($"{myCountToCommon} + {santasCountToCommon} = {myCountToCommon + santasCountToCommon}");

        }
    }
}
