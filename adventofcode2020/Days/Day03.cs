using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace adventofcode2020.Days
{
    public class Day03
    {
        private static List<string> ReadFile()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = @"" + _filePath + "/PuzuleInputs/Day03.txt";

            List<string> Pathern = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(_filePath);
            foreach (string line in lines)
            {
                Pathern.Add(line);
            }

            return Pathern;
        }

        public static void Taks01()
        {
            List<string> patern = ReadFile();
            int result = 0;
            int positionX = 0;

            foreach (var item in patern)
            {
                var pat = item.ToCharArray();
                Console.WriteLine(positionX);

                if (positionX >= pat.Length)
                {
                    positionX -= pat.Length;
                }

                if (pat[positionX] == '#')
                {
                    result++;
                }

                positionX += 3;
            }

            Console.WriteLine("Day 03 task 1 result : " + result);
            Console.ReadLine();
        }
    }
}
