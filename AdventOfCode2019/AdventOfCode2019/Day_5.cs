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
                text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_5_input.txt");
            }

            int[] numbers = text.Split(',').Select(Int32.Parse).ToArray();

            return numbers;
        }

        public static int[] ConvertOpco(int opco)
        {
            var myString = opco.ToString("D5");

            var charArray = myString.ToCharArray(); //{'1','2','3','4','5'}

            int[] opcoDigits = Array.ConvertAll(charArray, c => (int)Char.GetNumericValue(c));

            return opcoDigits;
        }

        public static void RunComputation(int[] numbers)
        {
            int pointer = 0;

            int startingInput = 5; //air conditioning

            int fullOpco = numbers[pointer];

            int[] opcoWithParams = ConvertOpco(fullOpco);

            int firstParamMode = opcoWithParams[2];
            int secondParamMode = opcoWithParams[1];
            int thridParamMode = opcoWithParams[0];
            int opco = opcoWithParams[4];

            while (opco != 9)
            {
                if (opco == 1 || opco == 2)
                {
                    int first_value = 0;

                    if (firstParamMode == 0) // positional
                    {
                        first_value = numbers[numbers[pointer + 1]];
                    }
                    else //immediate
                    {
                        first_value = numbers[pointer + 1];
                    }

                    int second_value = 0;

                    if (secondParamMode == 0) // positional
                    {
                        second_value = numbers[numbers[pointer + 2]];
                    }
                    else //immediate
                    {
                        second_value = numbers[pointer + 2];
                    }

                    int update_position = 0;

                    if (thridParamMode == 0) // positional
                    {
                        update_position = numbers[pointer + 3];
                    }
                    else //immediate
                    {
                        update_position = numbers[numbers[pointer + 3]];
                    }

                    if (opco == 1)
                    {
                        numbers[update_position] = first_value + second_value;
                    }
                    else
                    {
                        numbers[update_position] = first_value * second_value;
                    }


                    pointer += 4;
                }


                else if (opco == 3) // store input
                {
                    int first_position = numbers[pointer + 1];

                    numbers[first_position] = startingInput;

                    pointer += 2;
                }

                else if (opco == 4) // report output
                {
                    int first_position = numbers[pointer + 1];

                    Console.WriteLine($"Processing {opco} {first_position}");
                    Console.WriteLine($"With command {opco} {firstParamMode} {secondParamMode} {thridParamMode}\n");

                    Console.WriteLine($"Output: {numbers[first_position]}");

                    pointer += 2;
                }

                else if (opco == 5) // jump-if-true
                {
                    int first_value = 0;

                    if (firstParamMode == 0) // positional
                    {
                        first_value = numbers[numbers[pointer + 1]];
                    }
                    else //immediate
                    {
                        first_value = numbers[pointer + 1];
                    }

                    int second_value = 0;

                    if (secondParamMode == 0) // positional
                    {
                        second_value = numbers[numbers[pointer + 2]];
                    }
                    else //immediate
                    {
                        second_value = numbers[pointer + 2];
                    }

                    if (first_value != 0)
                    {
                        pointer = second_value;
                    }
                    else
                    {
                        pointer += 3;
                    }
                }

                else if (opco == 6) // jump-if-false
                {
                    int first_value = 0;

                    if (firstParamMode == 0) // positional
                    {
                        first_value = numbers[numbers[pointer + 1]];
                    }
                    else //immediate
                    {
                        first_value = numbers[pointer + 1];
                    }

                    int second_value = 0;

                    if (secondParamMode == 0) // positional
                    {
                        second_value = numbers[numbers[pointer + 2]];
                    }
                    else //immediate
                    {
                        second_value = numbers[pointer + 2];
                    }

                    if (first_value == 0)
                    {
                        pointer = second_value;
                    }
                    else
                    {
                        pointer += 3;
                    }
                }

                else if (opco == 7) // less than
                {
                    int first_value = 0;

                    if (firstParamMode == 0) // positional
                    {
                        first_value = numbers[numbers[pointer + 1]];
                    }
                    else //immediate
                    {
                        first_value = numbers[pointer + 1];
                    }

                    int second_value = 0;

                    if (secondParamMode == 0) // positional
                    {
                        second_value = numbers[numbers[pointer + 2]];
                    }
                    else //immediate
                    {
                        second_value = numbers[pointer + 2];
                    }

                    int update_position = 0;

                    if (thridParamMode == 0) // positional
                    {
                        update_position = numbers[pointer + 3];
                    }
                    else //immediate
                    {
                        update_position = numbers[numbers[pointer + 3]];
                    }

                    if (first_value < second_value)
                    {
                        numbers[update_position] = 1;
                    }
                    else
                    {
                        numbers[update_position] = 0;
                    }

                    pointer += 4;
                }

                else if (opco == 8) // equals
                {
                    int first_value = 0;

                    if (firstParamMode == 0) // positional
                    {
                        first_value = numbers[numbers[pointer + 1]];
                    }
                    else //immediate
                    {
                        first_value = numbers[pointer + 1];
                    }

                    int second_value = 0;

                    if (secondParamMode == 0) // positional
                    {
                        second_value = numbers[numbers[pointer + 2]];
                    }
                    else //immediate
                    {
                        second_value = numbers[pointer + 2];
                    }

                    int update_position = 0;

                    if (thridParamMode == 0) // positional
                    {
                        update_position = numbers[pointer + 3];
                    }
                    else //immediate
                    {
                        update_position = numbers[numbers[pointer + 3]];
                    }

                    if (first_value == second_value)
                    {
                        numbers[update_position] = 1;
                    }
                    else
                    {
                        numbers[update_position] = 0;
                    }

                    pointer += 4;
                }

                else // INVALID OPCO READ
                {
                    Console.WriteLine("INVALID OPCO DETECTED");
                    Console.WriteLine($"With command {opco} {firstParamMode} {secondParamMode} {thridParamMode}\n");
                    break;
                }

                fullOpco = numbers[pointer];

                opcoWithParams = ConvertOpco(fullOpco);

                firstParamMode = opcoWithParams[2];
                secondParamMode = opcoWithParams[1];
                thridParamMode = opcoWithParams[0];
                opco = opcoWithParams[4];
            }
        }

        public static void Part_1()
        {
            int[] numbers = ReadData();
            RunComputation(numbers);
        }

        public static void Part_2()
        {

        }
    }
}

