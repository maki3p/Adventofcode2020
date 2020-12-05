using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode2020.Days
{
    public class Day02
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Letter { get; set; }
        public string Password { get; set; }


        public static List<Day02> ReadFile()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = @"" + _filePath + "/PuzuleInputs/Day02.txt";
            List<Day02> Passowrds = new List<Day02>();
            Regex rgx = new Regex(@"^(\d+)-(\d+) (\w): (\w+)$");
            string[] lines = System.IO.File.ReadAllLines(_filePath);
            foreach (string line in lines)
            {
                foreach (Match match in rgx.Matches(line))
                {
                    Passowrds.Add(new Day02
                    {
                        Min = Int32.Parse(match.Groups[1].Value),
                        Max = Int32.Parse(match.Groups[2].Value),
                        Letter = match.Groups[3].Value.ToCharArray().FirstOrDefault(),
                        Password = match.Groups[4].Value
                    });
                }
            }

            return Passowrds;
        }


        public static void Taks01()
        {
            List<Day02> Passwords = ReadFile();

            int Counter = 0;
            foreach (var pass in Passwords)
            {
                if (pass.Password.Contains(pass.Letter))
                {
                    var matchCount = pass.Password.Count(x => x == pass.Letter);
                    if (matchCount >= pass.Min && pass.Max >= matchCount)
                    {
                        Counter++;
                    }

                }
            }
            Console.WriteLine("Day 02 task 1 result : " + Counter);
            Console.ReadLine();
        }

        public static void Taks02()
        {
            List<Day02> Passwords = ReadFile();

            int Counter = 0;
            foreach (var pass in Passwords)
            {
                if (pass.Password.Contains(pass.Letter))
                {
                    //Console.WriteLine(pass.Password.ToCharArray()[0] + " " + pass.Password.ToCharArray()[pass.Min - 1] + " " + pass.Password.ToCharArray()[pass.Max - 1]);
                    //Console.WriteLine();
                    //Console.WriteLine(pass.Password.ToCharArray()[pass.Max - 1]);
                    var charPassword = pass.Password;
                    if (charPassword[pass.Min - 1] == pass.Letter || charPassword[pass.Max - 1] == pass.Letter)
                    {
                        if(pass.Password.Count(x=> x == pass.Letter) > 1)
                        {
                            Counter++;
                        }
                        //Console.WriteLine(pass.Password);

                       
                    }

                }
            }
            Console.WriteLine("Day 02 task 2 result: " + Counter);
            Console.ReadLine();
        }
    }
}
