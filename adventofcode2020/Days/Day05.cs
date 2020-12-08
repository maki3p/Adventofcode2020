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
            List<int> result = _day05.GetSeats();

            Console.WriteLine("Day 05 task 1 result : " + result.Max());
            Console.ReadLine();
        }

        public static void Task02()
        {
            List<int> result = _day05.GetSeats();

            int mySeat = (result.Max() - result.Min() + 1) / 2 * (result.Min() + result.Max());

            Console.WriteLine("Day 05 task 2 result : " + (mySeat - result.Sum()).ToString());
            Console.ReadLine();
        }

        private List<int> GetSeats()
        {
            List<string> planeTickets = ReadFile();
            List<int> result = new List<int>();

            foreach (var item in planeTickets)
            {
                var s = "";
                foreach (var chart in item.ToCharArray())
                {
                    if (chart == 'F')
                    {
                        s += 0;
                    }
                    else if (chart == 'B')
                    {
                        s += 1;
                    }
                    else if (chart == 'L')
                    {
                        s += 0;
                    }
                    else if (chart == 'R')
                    {
                        s += 1;
                    }
                }
                result.Add(Convert.ToInt32(s, 2));
            }
            return result;
        }
    }
}
