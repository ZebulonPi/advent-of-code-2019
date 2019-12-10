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

        public static int[] ConvertOpco(int opco)
        {
            var myString = opco.ToString("D5");

            var charArray = myString.ToCharArray(); //{'1','2','3','4','5'}

            int[] opcoDigits = Array.ConvertAll(charArray, c => (int)Char.GetNumericValue(c));

            return opcoDigits;
        }

        public static int RunComputation(int[] numbers, int[] startingInput)
        {
            int pointer = 0;

            int inputPointer = 0;
            //int outputPointer = 0;
            int output = 0;

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

                    //Console.WriteLine($"Input {inputPointer}: {startingInput[inputPointer]}");

                    numbers[first_position] = startingInput[inputPointer];

                    pointer += 2;

                    inputPointer += 1;
                }

                else if (opco == 4) // report output
                {
                    int first_position = numbers[pointer + 1];

                    //Console.WriteLine($"Output: {numbers[first_position]}");

                    output = numbers[first_position];

                    //output[outputPointer] = numbers[first_position];

                    pointer += 2;

                   //outputPointer += 1;
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

            return output;
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
                int firstOutput = RunComputation(first_numbers, firstInput);
                //Console.WriteLine($"First output is {firstOutput}");
                int[] secondInput = { secondPS, firstOutput };
                int secondOutput = RunComputation(second_numbers, secondInput);
                //Console.WriteLine($"Second output is {secondOutput}");
                int[] thirdInput = { thirdPS, secondOutput };
                int thirdOutput = RunComputation(third_numbers, thirdInput);
                //Console.WriteLine($"Third output is {thirdOutput}");
                int[] fourthInput = { fourthPS, thirdOutput };
                int fourthOutput = RunComputation(fourth_numbers, fourthInput);
                //Console.WriteLine($"Fourth output is {fourthOutput}");
                int[] fifthInput = { fifthPS, fourthOutput };
                int fifthOutput = RunComputation(fifth_numbers, fifthInput);

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
