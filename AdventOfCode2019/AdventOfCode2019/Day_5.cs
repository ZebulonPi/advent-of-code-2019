using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode2019
{
    public class Day_5
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
                text = System.IO.File.ReadAllText(@"/Users/jasongreenwood/advent-of-code-2019/AdventOfCode2019/AdventOfCode2019/Day_5_input.txt");
            }

            int[] numbers = text.Split(',').Select(Int32.Parse).ToArray();

            return numbers;      
        }

        public static int RunComputation(int[] numbers)
        {
            int pointer = 0;

            int opco = numbers[pointer];

            while (opco != 99)
            {


                if (opco == 1)
                {
                    int first_position = numbers[pointer + 1];
                    int second_position = numbers[pointer + 2];
                    int update_position = numbers[pointer + 3];

                    numbers[update_position] = numbers[first_position] + numbers[second_position];

                    pointer += 4;
                }
                else if (opco == 2)
                {
                    int first_position = numbers[pointer + 1];
                    int second_position = numbers[pointer + 2];
                    int update_position = numbers[pointer + 3];

                    numbers[update_position] = numbers[first_position] * numbers[second_position];

                    pointer += 4;
                }

                else if (opco == 3)
                {
                    int first_position = numbers[pointer + 1];
                    int second_position = numbers[pointer + 2];
                    int update_position = numbers[pointer + 3];

                    numbers[update_position] = numbers[first_position] * numbers[second_position];

                    pointer += 4;
                }

                else if (opco == 4)
                {
                    int first_position = numbers[pointer + 1];
                    int second_position = numbers[pointer + 2];
                    int update_position = numbers[pointer + 3];

                    numbers[update_position] = numbers[first_position] * numbers[second_position];

                    pointer += 4;
                }

                opco = numbers[pointer];
            }

            return numbers[0];
        }

        public static void Part_1()
        {

        }

        public static void Part_2()
        {

        }
    }
}
