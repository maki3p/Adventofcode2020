using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode2020.Days
{
    public class Day05
    {
        private static readonly Day05 _day05 = new Day05();
        private static List<string> ReadFile()
        {
            string _filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            _filePath = @"" + _filePath + "/PuzuleInputs/Day05.txt";

            List<string> planeTickets = File.ReadAllLines(_filePath).ToList();

            return planeTickets;
        }

        public static void Task01()
        {
            List<string> planeTickets = ReadFile();
            List<int> result = new List<int>();
            foreach (var item in planeTickets)
            {
                result.Add(_day05.GetSeat(item));
            }

            Console.WriteLine("Day 05 task 1 result : " + result.Max());
            Console.ReadLine();
        }

        public static void Task02()
        {

            List<string> planeTickets = ReadFile();
            List<int> result = new List<int>();
            foreach (var item in planeTickets)
            {
                result.Add(_day05.GetSeat(item));
            }

            int theoreticalSum = (result.Max() - result.Min() + 1) / 2 * (result.Min() + result.Max());

            Console.WriteLine("Day 05 task 2 result : " + (theoreticalSum - result.Sum()).ToString());
            Console.ReadLine();
        }

        private int GetSeat(String str)
        {
            var (minInterval, maxInterval) = (0, 127);
            var (left, right) = (0, 7);
            foreach (var c in str.ToCharArray())
            {
                if (c == 'F')
                {
                    maxInterval = maxInterval - (maxInterval - minInterval) / 2 - 1;
                }
                else if (c == 'B')
                {
                    minInterval = minInterval + (maxInterval - minInterval) / 2 + 1;
                }
                else if (c == 'L')
                {
                    right = right - (right - left) / 2 - 1;
                }
                else
                {
                    left = left + (right - left) / 2 + 1;
                }
            }

            return minInterval * 8 + left;
        }

    }
}
