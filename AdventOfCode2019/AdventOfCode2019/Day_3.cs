using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day_3
    {
        static int startingPortX = 0;
        static int startingPortY = 0;

        static List<CrossPoint> Points = new List<CrossPoint>();
        static List<PointRange> Ranges = new List<PointRange>();

        struct CrossPoint
        {
            public int Xcoord;
            public int Ycoord;
            public int stepCount;
        }

        struct PointRange
        {
            public int XLow;
            public int XHigh;
            public int YLow;
            public int YHigh;
            public int stepCount;
        }

        public static void LayWire(String[] steps)
        {
            int currentPointX = startingPortX;
            int currentPointY = startingPortY;

            int stepCountToRange = 0;

            foreach (string step in steps)
            {
                char instruction = step[0];
                int distance = Int32.Parse(step.Substring(1, step.Length - 1));
                PointRange range;

                stepCountToRange += distance;

                switch (instruction)
                {
                    case 'U':
                        {
                            range.XHigh = currentPointX;
                            range.XLow = currentPointX;
                            range.YHigh = currentPointY;
                            range.YLow = currentPointY - distance;
                            range.stepCount = stepCountToRange;

                            Ranges.Add(range);

                            currentPointY -= distance;

                            break;
                        }
                    case 'D':
                        {

                            range.XLow = currentPointX;
                            range.XHigh = currentPointX;
                            range.YLow = currentPointY;
                            range.YHigh = currentPointY + distance;
                            range.stepCount = stepCountToRange;

                            Ranges.Add(range);

                            currentPointY += distance;

                            break;
                        }
                    case 'L':
                        {
                            range.XLow = currentPointX - distance;
                            range.XHigh = currentPointX;
                            range.YLow = currentPointY;
                            range.YHigh = currentPointY;
                            range.stepCount = stepCountToRange;

                            Ranges.Add(range);

                            currentPointX -= distance;

                            break;
                        }
                    case 'R':
                        {
                            range.XLow = currentPointX;
                            range.XHigh = currentPointX + distance;
                            range.YLow = currentPointY;
                            range.YHigh = currentPointY;
                            range.stepCount = stepCountToRange;

                            Ranges.Add(range);

                            currentPointX += distance;

                            break;
                        }
                }

                Console.WriteLine($"Instruction is {instruction}, distance is {distance}," +
                                  $" total distance is {stepCountToRange}");
            }
        }

        public static void CheckWire(String[] steps)
        {
            int currentPointX = startingPortX;
            int currentPointY = startingPortY;

            int stepCountToPoint = 0;

            foreach (string step in steps)
            {
                char instruction = step[0];
                int distance = Int32.Parse(step.Substring(1, step.Length - 1));
                CrossPoint point;

                stepCountToPoint += distance;

                switch (instruction)
                {
                    case 'U':
                        {
                            for (int y = 0; y < distance; y++)
                            {
                                foreach (PointRange range in Ranges)
                                {
                                    if ((currentPointX >= range.XLow && currentPointX <= range.XHigh) &&
                                       (currentPointY - y >= range.YLow && currentPointY - y <= range.YHigh))
                                    {
                                        if ((currentPointX != startingPortX) &&
                                            (currentPointY - y != startingPortY))
                                        {
                                            point.Xcoord = currentPointX;
                                            point.Ycoord = currentPointY - y;
                                            point.stepCount = (stepCountToPoint - distance + y) + range.stepCount - Math.Abs(currentPointX - range.XLow);
                                            Points.Add(point);

                                            Console.WriteLine($"X is {point.Xcoord}, Y is {point.Ycoord}," +
                                                              $" step count to point is {stepCountToPoint}" +
                                                              $" range stepcount is {range.stepCount}" +
                                                              $" diff is {currentPointX - range.XLow}");
                                        }

                                    }
                                }
                            }
                          
                            currentPointY -= distance;

                            break;
                        }
                    case 'D':
                        {
                            for (int y = 0; y < distance; y++)
                            {
                                foreach (PointRange range in Ranges)
                                {
                                    if ((currentPointX >= range.XLow && currentPointX <= range.XHigh) &&
                                       (currentPointY + y >= range.YLow && currentPointY + y <= range.YHigh))
                                    {
                                        if ((currentPointX != startingPortX) &&
                                            (currentPointY + y != startingPortY))
                                        {
                                            point.Xcoord = currentPointX;
                                            point.Ycoord = currentPointY + y;
                                            point.stepCount = (stepCountToPoint - distance + y) + range.stepCount - Math.Abs(currentPointX - range.XLow);
                                            Points.Add(point);

                                            Console.WriteLine($"X is {point.Xcoord}, Y is {point.Ycoord}," +
                                                              $" step count to point is {stepCountToPoint}" +
                                                              $" range stepcount is {range.stepCount}" +
                                                              $" diff is {currentPointX - range.XLow}");
                                        }
                                    }
                                }
                            }

                            currentPointY += distance;

                            break;
                        }
                    case 'L':
                        {
                            for (int x = 0; x < distance; x++)
                            {
                                foreach (PointRange range in Ranges)
                                {
                                    if ((currentPointX - x >= range.XLow && currentPointX - x <= range.XHigh) &&
                                       (currentPointY >= range.YLow && currentPointY <= range.YHigh))
                                    {
                                        if ((currentPointX - x != startingPortX) &&
                                            (currentPointY != startingPortY))
                                        {
                                            point.Xcoord = currentPointX - x;
                                            point.Ycoord = currentPointY;
                                            point.stepCount = (stepCountToPoint - distance + x) + range.stepCount - Math.Abs(currentPointY - range.YLow);
                                            Points.Add(point);

                                            Console.WriteLine($"X is {point.Xcoord}, Y is {point.Ycoord}," +
                                                              $" step count to point is {stepCountToPoint}" +
                                                              $" range stepcount is {range.stepCount}" +
                                                              $" diff is {currentPointX - range.XLow}");
                                        }
                                    }
                                }
                            }

                            currentPointX -= distance;

                            break;
                        }
                    case 'R':
                        {
                            for (int x = 0; x < distance; x++)
                            {
                                foreach (PointRange range in Ranges)
                                {
                                    if ((currentPointX + x >= range.XLow && currentPointX + x <= range.XHigh) &&
                                       (currentPointY >= range.YLow && currentPointY <= range.YHigh))
                                    {
                                        if ((currentPointX + x != startingPortX) &&
                                            (currentPointY != startingPortY))
                                        {
                                            point.Xcoord = currentPointX + x;
                                            point.Ycoord = currentPointY;
                                            point.stepCount = (stepCountToPoint - distance + x) + range.stepCount - Math.Abs(currentPointY - range.YLow);
                                            Points.Add(point);

                                            Console.WriteLine($"X is {point.Xcoord}, Y is {point.Ycoord}," +
                                                              $" step count to point is {stepCountToPoint}" +
                                                              $" range stepcount is {range.stepCount}" +
                                                              $" diff is {currentPointX - range.XLow}");
                                        }
                                    }
                                }
                            }

                            currentPointX += distance;

                            break;
                        }
                }
                Console.WriteLine($"Instruction is {instruction}, distance is {distance}," +
                                  $" total distance is {stepCountToPoint}");
            }
        }

        public static void Part_1()
        {
            //string text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_3_input.txt");
            string text = System.IO.File.ReadAllText(@"/Users/jasongreenwood/advent-of-code-2019/AdventOfCode2019/AdventOfCode2019/Day_3_input.txt");

            string[] wires = text.Split('\n').ToArray();
            string[][] wiresteps = new string[2][];

            int lowestDist = 9999999;

            for (int numOfWires = 0; numOfWires < wires.Length; numOfWires++)
            {
                wiresteps[numOfWires] = wires[numOfWires].Split(',').ToArray();
            }

            LayWire(wiresteps[0]);
            CheckWire(wiresteps[1]);

            foreach (CrossPoint point in Points)
            {
                int pointDist = Math.Abs(startingPortX - point.Xcoord) +
                                Math.Abs(startingPortY - point.Ycoord);

                if (pointDist < lowestDist)
                {
                    lowestDist = pointDist;
                }

            }

            Console.WriteLine($"Closest distance is {lowestDist}");
        }


        public static void Part_2()
        {
            //string text = System.IO.File.ReadAllText(@"C:\Users\Jason\Documents\advent-of-code-2019\AdventOfCode2019\AdventOfCode2019\Day_3_input.txt");
            string text = System.IO.File.ReadAllText(@"/Users/jasongreenwood/advent-of-code-2019/AdventOfCode2019/AdventOfCode2019/Day_3_input.txt");

            string[] wires = text.Split('\n').ToArray();
            string[][] wiresteps = new string[2][];

            int lowestSteps = 9999999;

            for (int numOfWires = 0; numOfWires < wires.Length; numOfWires++)
            {
                wiresteps[numOfWires] = wires[numOfWires].Split(',').ToArray();
            }

            Console.WriteLine("LayWire");
            LayWire(wiresteps[0]);
            Console.WriteLine("CheckWire");
            CheckWire(wiresteps[1]);

            foreach (CrossPoint point in Points)
            {
                Console.WriteLine($"X is {point.Xcoord}, Y is {point.Ycoord}," +
                                  $" total distance is {point.stepCount}");

                int totalSteps = point.stepCount;

                if (totalSteps < lowestSteps)
                {
                    lowestSteps = totalSteps;
                }

            }

            Console.WriteLine($"Closest distance is {lowestSteps} steps");
        }
    }
}
