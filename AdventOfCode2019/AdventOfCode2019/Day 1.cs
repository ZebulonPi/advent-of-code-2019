using System;
namespace AdventOfCode2019
{
    public class Day_1
    {
        /* --- Day 1: The Tyranny of the Rocket Equation ---
         * 
        Santa has become stranded at the edge of the Solar System while delivering presents to other planets! To accurately calculate his position in space, safely align his warp drive, and return to Earth in time to save Christmas, he needs you to bring him measurements from fifty stars.

        Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

        The Elves quickly load you into a spacecraft and prepare to launch.

        At the first Go / No Go poll, every Elf is Go until the Fuel Counter-Upper. They haven't determined the amount of fuel required yet.

        Fuel required to launch a given module is based on its mass. Specifically, to find the fuel required for a module, take its mass, divide by three, round down, and subtract 2.

        For example:

        For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
        For a mass of 14, dividing by 3 and rounding down still yields 4, so the fuel required is also 2.
        For a mass of 1969, the fuel required is 654.
        For a mass of 100756, the fuel required is 33583.
        The Fuel Counter-Upper needs to know the total fuel requirement. To find it, individually calculate the fuel needed for the mass of each module (your puzzle input), then add together all the fuel values.

        What is the sum of the fuel requirements for all of the modules on your spacecraft? */

        /* --- Part Two ---
        During the second Go / No Go poll, the Elf in charge of the Rocket Equation Double-Checker stops the launch sequence. Apparently, you forgot to include additional fuel for the fuel you just added.

        Fuel itself requires fuel just like a module - take its mass, divide by three, round down, and subtract 2. However, that fuel also requires fuel, and that fuel requires fuel, and so on. Any mass that would require negative fuel should instead be treated as if it requires zero fuel; the remaining mass, if any, is instead handled by wishing really hard, which has no mass and is outside the scope of this calculation.

        So, for each module mass, calculate its fuel and add it to the total. Then, treat the fuel amount you just calculated as the input mass and repeat the process, continuing until a fuel requirement is zero or negative. For example:

        A module of mass 14 requires 2 fuel. This fuel requires no further fuel (2 divided by 3 and rounded down is 0, which would call for a negative fuel), so the total fuel required is still just 2.
        At first, a module of mass 1969 requires 654 fuel. Then, this fuel requires 216 more fuel (654 / 3 - 2). 216 then requires 70 more fuel, which requires 21 fuel, which requires 5 fuel, which requires no further fuel. So, the total fuel required for a module of mass 1969 is 654 + 216 + 70 + 21 + 5 = 966.
        The fuel required by a module of mass 100756 and its fuel is: 33583 + 11192 + 3728 + 1240 + 411 + 135 + 43 + 12 + 2 = 50346.
        What is the sum of the fuel requirements for all of the modules on your spacecraft when also taking into account the mass of the added fuel? (Calculate the fuel requirements for each module separately, then add them all up at the end.) */

        static String raw_input = @"50669
            83199
            108957
            102490
            121216
            57848
            76120
            121042
            143774
            106490
            76671
            119551
            109598
            124949
            148026
            119862
            112854
            96289
            73573
            142714
            109875
            126588
            69748
            62766
            104446
            61766
            133199
            118306
            141410
            64420
            129370
            69444
            104178
            109696
            54654
            126517
            138265
            87100
            130934
            138946
            118078
            135109
            137330
            130913
            50681
            53071
            63070
            144616
            64122
            122603
            86612
            144666
            62572
            72247
            79005
            102223
            82585
            54975
            68539
            107964
            148333
            100269
            134101
            115960
            75866
            99371
            56685
            142199
            102107
            84075
            112733
            92180
            131056
            142803
            145495
            70900
            73129
            60764
            77576
            99160
            61897
            78675
            100890
            74787
            131911
            93106
            91267
            142663
            130649
            103857
            81178
            78896
            73745
            84463
            92926
            121715
            74959
            71911
            89102
            53428";

        public static int ComputeFuel(float mass)
        {
            int fuel_needed = Convert.ToInt32(Math.Floor(mass / 3.0)) - 2;
            return fuel_needed;
        }

        public static int ComputeFuelForFuel(float mass)
        {
            int fuel_total = 0;
            int fuel_needed = ComputeFuel(mass);
            while (fuel_needed > 0)
            {
                fuel_total += fuel_needed;
                fuel_needed = ComputeFuel(fuel_needed);
            }
            return fuel_total;
        }

        public static void Part_1()
        {
            String[] numbers = raw_input.Split('\n');
            int ans = 0;
            foreach (var raw_number in numbers)
            {
                int number = Int32.Parse(raw_number);
                ans += ComputeFuel(number);
            }
            Console.WriteLine(ans);
        }

        public static void Part_2()
        {
            String[] numbers = raw_input.Split('\n');
            int ans = 0;
            foreach (var raw_number in numbers)
            {
                int number = Int32.Parse(raw_number);
                int fuel = ComputeFuelForFuel(number);
                ans += fuel;
            }
            Console.WriteLine(ans);
        }
    }
}
        
 