using adventofcode2020.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code2020");
            Console.WriteLine("Get results from a day: 'Enter Day' ");

            ChoiceDay();
        }

        public static void ChoiceDay()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Day01.Task01();
                    Day01.Task02();
                    break;
                case "2":
                    Day02.Taks01();
                    Day02.Taks02();
                    break;
                case "3":
                    Day03.Task01();
                    Day03.Task02();
                    break;
                case "4":
                    Day04.Task01();
                    Day04.Task02();
                    break;
                case "5":
                    Day05.Task01();
                    Day05.Task02();
                    break;
                default:
                    Console.WriteLine("No result for selected day");
                    Console.ReadLine();
                    ChoiceDay();
                    break;
            }
        }
    }
}
