using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2020.Days
{
    public class Day01
    {
        public static List<int> ReadFile()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

            _filePath = @"" + _filePath + "/PuzuleInputs/Day01.txt";
            List<int> Numbers = new List<int>();

            string[] lines = File.ReadAllLines(_filePath);
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Numbers.Add(Int32.Parse(line));
            }

            return Numbers;
        }

        public static void Task01()
        {
            List<int> Numbers = ReadFile();

            for (int i = 0; i < Numbers.Count(); i++)
            {
                for (int j = 0 + i; j < Numbers.Count(); j++)
                {
                    if (Numbers[i] + Numbers[j] == 2020)
                    {
                        Console.WriteLine("Day 01 task 1 result: " + Numbers[i] * Numbers[j]);
                    }
                }
            }

            Console.ReadLine();
        }
        public static void Task02()
        {
            List<int> Numbers = ReadFile();

            for (int i = 0; i < Numbers.Count(); i++)
            {
                for (int j = 0 + i; j < Numbers.Count(); j++)
                {
                    for (int z = 0 + j; z < Numbers.Count(); z++)
                    {
                        if (Numbers[i] + Numbers[j] + Numbers[z] == 2020)
                        {

                            Console.WriteLine("Day 01 task 2 result: " + Numbers[i] * Numbers[j] * Numbers[z]);
                        }
                    }

                }
            }

            Console.ReadLine();
        }
    }
}
