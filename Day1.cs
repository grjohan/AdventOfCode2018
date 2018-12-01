using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    using System.IO;

    public class Day1 : DailySolution
    {
        public int Part1() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day4Input.txt");
            var phrases = File.ReadAllLines(file.FullName);
            var counter = 0;
            foreach (var phrase in phrases)
            {
                var sign = phrase.Substring(0, 1);
                var number = int.Parse(phrase.Substring(1));
                if (sign == "-")
                {
                    counter -= number;
                }
                else
                {
                    counter += number;
                }
            }
            return counter;
        }

        public int Part2() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day4Input.txt");
            var phrases = File.ReadAllLines(file.FullName);
            var counter = 0;
            var reachedNumber = new List<int>();
            reachedNumber.Add(counter);
            while (true)
            {
            foreach (var phrase in phrases)
            {
                var sign = phrase.Substring(0, 1);
                var number = int.Parse(phrase.Substring(1));
                if (sign == "-")
                {
                    counter -= number;
                }
                else
                {
                    counter += number;
                }

                if (reachedNumber.Contains(counter))
                {
                    return counter;
                }
                reachedNumber.Add(counter);
            }
            }
        }
    }
}
