using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace adventofcode2020.Days
{
    public class Day03
    {
        private static readonly Day03 _day03 = new Day03();

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

        public static void Task01()
        {
            var result = _day03.GetNumberOfTreesEncountered(_day03.GetFullMountain(ReadFile(), 1, 3), 1, 3);

            Console.WriteLine("Day 02 task 1 result : " + result);
            Console.ReadLine();
        }

        public static void Task02()
        {
            var result = _day03.GetTreesFromMultiplePasses(ReadFile(), new (int, int)[] { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) });
            Console.WriteLine("Day 02 task 2 result : " + result);
            Console.ReadLine();
        }
        private long GetTreesFromMultiplePasses(List<string> input, (int slope, int angle)[] passes)
        {
            var trees = passes.Select(p => GetNumberOfTreesEncountered(GetFullMountain(input, p.slope, p.angle), p.slope, p.angle)).ToList();
            return trees.Aggregate((x, y) => x * y);
        }
        //public int GetResult(int jump, int startPosition)
        //{
        //    List<string> patern = ReadFile();
        //    int result = 0;
        //    int positionX = startPosition - 1;

        //    foreach (var item in patern)
        //    {
        //        var pat = item.ToCharArray();

        //        if (positionX >= pat.Length)
        //        {
        //            positionX -= pat.Length;
        //        }

        //        if (pat[positionX] == '#')
        //        {
        //            result++;
        //        }

        //        positionX += jump;
        //    }

        //    return result;
        //}

        private long GetNumberOfTreesEncountered(List<string> input, int slopeDescent, int angle)
        {
            var numberOfTrees = 0;
            var slidingAngle = angle;
            for (int slope = slopeDescent; slope < input.Count; slope += slopeDescent)
            {
                var space = input[slope][slidingAngle];
                if (space == '#')
                    numberOfTrees++;
                slidingAngle += angle;
            }
            return numberOfTrees;
        }

        private List<string> GetFullMountain(List<string> input, int slopeDescent, int angle)
        {
            var widthSlope = input[0].Length;
            var numberOfSlopes = input.Count / slopeDescent;
            var necessaryWidth = numberOfSlopes * angle;
            var fullMountain = input.Select(i => string.Concat(Enumerable.Repeat(i, (necessaryWidth / widthSlope) + 1))).ToList();
            return fullMountain;
        }
    }
}
