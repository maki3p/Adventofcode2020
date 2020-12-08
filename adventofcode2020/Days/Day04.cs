using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode2020.Days
{
    public class Day04
    {
        private static readonly Day04 _day04 = new Day04();
        public class Passport
        {
            public int BirthYear { get; set; }
            public int IssueYear { get; set; }
            public int ExpirationYear { get; set; }
            public string Height { get; set; }
            public string HairColor { get; set; }
            public string EyeColor { get; set; }
            public string PassportID { get; set; }
            public int CountryID { get; set; }
        }
        private static List<Passport> ReadFile()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = @"" + _filePath + "/PuzuleInputs/Day04.txt";

            List<Passport> Passports = new List<Passport>();
            List<string> lines = File.ReadAllText(_filePath).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Regex byrRgx = new Regex(@"byr:(\d+)");
            Regex iyrRgx = new Regex(@"iyr:(\d+)");
            Regex eyrRgx = new Regex(@"eyr:(\d+)");
            Regex hgtRgx = new Regex(@"hgt:((\d+))cm|hgt:((\d+))in|hgt:((\d+))");
            Regex hclRgx = new Regex(@"hcl:(\#+\w+)|hcl:(\w+)");
            Regex eclRgx = new Regex(@"ecl:(\#+\w+)|ecl:(\w+)");
            Regex pidRgx = new Regex(@"pid:(.\w+)");
            Regex cidRgx = new Regex(@"cid:(\d+)");

            foreach (var item in lines)
            {
                Passports.Add(new Passport
                {
                    BirthYear = item.Contains("byr:") ? int.Parse(byrRgx.Match(item).Value.Substring(item.IndexOf(":") + 1)) : default,
                    IssueYear = item.Contains("iyr:") ? int.Parse(iyrRgx.Match(item).Value.Substring(item.IndexOf(":") + 1)) : default,
                    ExpirationYear = item.Contains("eyr:") ? int.Parse(eyrRgx.Match(item).Value.Substring(item.IndexOf(":") + 1)) : default,
                    Height = item.Contains("hgt:") ? hgtRgx.Match(item).Value.Substring(item.IndexOf(":") + 1) : "",
                    HairColor = item.Contains("hcl:") ? hclRgx.Match(item).Value.Substring(item.IndexOf(":") + 1) : "",
                    EyeColor = item.Contains("ecl:") ? eclRgx.Match(item).Value.Substring(item.IndexOf(":") + 1) : "",
                    PassportID = item.Contains("pid:") ? pidRgx.Match(item).Value.Substring(item.IndexOf(":") + 1) : "",
                    CountryID = item.Contains("cid:") ? int.Parse(cidRgx.Match(item).Value.Substring(item.IndexOf(":") + 1)) : default,
                });
            }
            return Passports;
        }

        public static void Task01()
        {
            List<Passport> puzleInput = ReadFile();
            int result = puzleInput.Where(x =>
            !string.IsNullOrEmpty(x.Height) &&
            x.ExpirationYear != 0 &&
            !string.IsNullOrEmpty(x.EyeColor) &&
            x.IssueYear != 0 &&
            !string.IsNullOrEmpty(x.HairColor) &&
            x.BirthYear != 0 &&
             !string.IsNullOrEmpty(x.EyeColor)
             && !string.IsNullOrEmpty(x.PassportID)
            ).Count();

            Console.WriteLine("Day 04 task 1 result : " + result);
            Console.ReadLine();
        }
        public static void Task02()
        {
            Regex onlyNumberNumber = new Regex(@"(\d+)");
            Regex checkHairColor = new Regex(@"#[0-9|a-f]{6}");
            Regex checkEyeColor = new Regex(@"amb|blu|brn|gry|grn|hzl|oth");
            List<Passport> puzleInput = ReadFile();
            int output = 0;

            var result = puzleInput.Where(x =>
            x.BirthYear <= 2002 && x.BirthYear >= 1920 &&
             x.IssueYear >= 2010 && x.IssueYear <= 2020 &&
            x.ExpirationYear >= 2020 && x.ExpirationYear <= 2030 &&
             (x.Height.Contains("cm") ? int.Parse(onlyNumberNumber.Match(x.Height).Value) >= 150 && int.Parse(onlyNumberNumber.Match(x.Height).Value) <= 193 : false || x.Height.Contains("in") ? int.Parse(onlyNumberNumber.Match(x.Height).Value) >= 59 && int.Parse(onlyNumberNumber.Match(x.Height).Value) <= 76 : false) &&
            checkHairColor.IsMatch(x.HairColor) &&
             checkEyeColor.IsMatch(x.EyeColor) &&
             int.TryParse(x.PassportID, out output) && x.PassportID.Length == 9
            ).Count();

            Console.WriteLine("Day 04 task 2 result : " + result);
            Console.ReadLine();

        }
    }
}
