using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day_7
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static int[] ReadData()
        {
            string text = "";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                text = System.IO.File.ReadAllText(@"/Users/jasongreenwood/advent-of-code-2019/AdventOfCode2019/AdventOfCode2019/Day_7_input.txt");
            }
            else
            {
                text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_7_input.txt");
            }

            int[] numbers = text.Split(',').Select(Int32.Parse).ToArray();

            return numbers;
        }

        public static void Part_1()
        {
            int highestOutput = 0;

            List<int> phaseSettingSequence = new List<int>() { 0, 1, 2, 3, 4 };
            IEnumerable<IEnumerable<int>> possibilityList = Test_Code.GetPermutations(phaseSettingSequence, 5);
            foreach (var possibilities in possibilityList)
            {
                int[] first_numbers = ReadData();
                int[] second_numbers = ReadData();
                int[] third_numbers = ReadData();
                int[] fourth_numbers = ReadData();
                int[] fifth_numbers = ReadData();

                List<int> asList = possibilities.ToList();
                int firstPS = asList[0];
                int secondPS = asList[1];
                int thirdPS = asList[2];
                int fourthPS = asList[3];
                int fifthPS = asList[4];

                int[] firstInput = { firstPS, 0 };
                IntCodeComp FirstComp = new IntCodeComp(first_numbers, firstInput);
                int firstOutput = FirstComp.RunComputation();
                //Console.WriteLine($"First output is {firstOutput}");
                int[] secondInput = { secondPS, firstOutput };
                IntCodeComp SecondComp = new IntCodeComp(second_numbers, secondInput);
                int secondOutput = SecondComp.RunComputation();
                //Console.WriteLine($"Second output is {secondOutput}");
                int[] thirdInput = { thirdPS, secondOutput };
                IntCodeComp ThirdComp = new IntCodeComp(third_numbers, thirdInput);
                int thirdOutput = ThirdComp.RunComputation();
                //Console.WriteLine($"Third output is {thirdOutput}");
                int[] fourthInput = { fourthPS, thirdOutput };
                IntCodeComp FourthComp = new IntCodeComp(fourth_numbers, fourthInput);
                int fourthOutput = FourthComp.RunComputation();
                //Console.WriteLine($"Fourth output is {fourthOutput}");
                int[] fifthInput = { fifthPS, fourthOutput };
                IntCodeComp FifthComp = new IntCodeComp(fifth_numbers, fifthInput);
                int fifthOutput = FifthComp.RunComputation();

                if (fifthOutput > highestOutput)
                {
                    Console.WriteLine($"New highest output is {fifthOutput}");
                    highestOutput = fifthOutput;
                }
            }

            Console.WriteLine($"Final output is {highestOutput}");
        }

        public static void Part_2()
        {

        }
    }
}
