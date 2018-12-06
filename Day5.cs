using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Extensions;

namespace ConsoleApp6
{
    public class Day5 : Day, DailySolution<int, int>
    {
        public int Part1()
        {
           return ReactPolymet(input.First()).Length;
        }

        public int Part2()
        {
            var uniqueTypes = input.First().Select(o => char.ToLower(o)).Distinct();
            var polymer = input.First();
            var length = int.MaxValue;
            foreach (var uniqueType in uniqueTypes)
            {
                var uppercase = Char.ToUpper(uniqueType);
                var newPolymer =  new string(polymer.Where(o => o != uniqueType && o != uppercase).ToArray());
                var tempLength =  ReactPolymet(newPolymer).Length;
                if (tempLength < length)
                {
                    length = tempLength;
                }

            }

            return length;
        }

        public string ReactPolymet(string polymet)
        {
            char[] polymer;
            var removedSomething = false;
            var newString = polymet;
            do
            {
                polymer = newString.ToCharArray();
                newString = "";
                for (int i = 0; i < polymer.Count(); i++)
                {
                    if (i + 1 == polymer.Length)
                    {
                        newString += polymer[i];
                        continue;
                    }

                    if (char.IsUpper(polymer[i]) == char.IsUpper(polymer[i + 1]) || char.ToLower(polymer[i]) != char.ToLower(polymer[i + 1]))
                    {
                        newString += polymer[i];
                    }
                    else
                    {
                        i++;
                    }
                }
            } while (newString.Length != polymer.Length);

            return newString;
        }
    }
}
