using System;

namespace AdventOfCode2019
{
    public class Day_4
    {
        /* You arrive at the Venus fuel depot only to discover it's protected by a password. The Elves had written the password on a sticky note, but someone threw it out.

            However, they do remember a few key facts about the password:

            It is a six-digit number.
            The value is within the range given in your puzzle input.
            Two adjacent digits are the same (like 22 in 122345).
            Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
            Other than the range rule, the following are true:

            111111 meets these criteria (double 11, never decreases).
            223450 does not meet these criteria (decreasing pair of digits 50).
            123789 does not meet these criteria (no double).
            How many different passwords within the range given in your puzzle input meet these criteria? */

        // Your puzzle input is 231832-767346.

        public static bool DoubleDigits(String password)
        {
            if (password[0] == password[1] ||
                password[1] == password[2] ||
                password[2] == password[3] ||
                password[3] == password[4] ||
                password[4] == password[5])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AlwaysIncreasing(String password)
        {
            if (password[0] <= password[1] &&
                password[1] <= password[2] &&
                password[2] <= password[3] &&
                password[3] <= password[4] &&
                password[4] <= password[5])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DoubleButNotTriple(String password)
        {
            if (password[0] == password[1] && 
                password[1] != password[2])
            {
                return true;
            }
            if (password[1] == password[2] && 
                password[0] != password[1] &&
                password[2] != password[3])
            {
                return true;
            }

            if (password[2] == password[3] && 
                password[1] != password[2] &&
                password[3] != password[4])
            {
                return true;
            }
            if (password[3] == password[4] && 
                password[2] != password[3] &&
                password[4] != password[5])
            {
                return true;
            }
            if (password[4] == password[5] && 
                password[3] != password[4])
            {
                return true;
            }  

            return false;

        }

        public static void Part_1()
        {
            int passwordCount = 0;

            for (int possible = 231832; possible < 767346; possible++)
            {
                if (DoubleDigits(possible.ToString()) && 
                    AlwaysIncreasing(possible.ToString()))
                {
                    passwordCount += 1;
                }
            }

            Console.WriteLine($"The answer is {passwordCount}");
        }

        public static void Part_2()
        {
            int passwordCount = 0;

            for (int possible = 231832; possible < 767346; possible++)
            {
                if (DoubleButNotTriple(possible.ToString()) &&
                    AlwaysIncreasing(possible.ToString()))
                {
                    passwordCount += 1;
                }
            }

            Console.WriteLine($"The answer is {passwordCount}");
        }
    }
}
