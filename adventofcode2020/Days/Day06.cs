using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2020.Days
{
    public class Day06
    {
        private static List<string> ReadFile()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = @"" + _filePath + "/PuzuleInputs/Day06.txt";

            List<string> lines = File.ReadAllText(_filePath).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return lines;
        }

        public static void Task01()
        {
            var groups = ReadFile();
            var result = 0;
            List<string> dar = new List<string>();
            foreach (var item in groups)
            {
                result += item.ToCharArray().Where(x => x != '\r' && x != '\n').GroupBy(x => x).Distinct().Count();
            }

            Console.WriteLine("Day 06 task 1 result : " + result);
            Console.ReadLine();
        }

        public static void Task02()
        {
            var groups = ReadFile();
            var result = 0;
            var noPersons = 0;
            foreach (var item in groups)
            {
                noPersons = item.Split('\n').Count();

                if (item.Contains('\n') || item.Contains('\r'))
                {                    
                    result += item.Where(char.IsLetter).Where(x => x != '\r' && x != '\n').GroupBy(x => x).Select(g => new { Letter = g.Key, Count = g.Count() }).Where(x => x.Count == noPersons).Count();                        
                }
                else
                {
                    result += item.ToCharArray().Where(x => x != '\r' && x != '\n').GroupBy(x => x).Distinct().Count();
                }
            }

            Console.WriteLine("Day 06 task 2 result : " + result);
            Console.ReadLine();
        }
    }
}
