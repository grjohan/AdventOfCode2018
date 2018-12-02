using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    using System.IO;

    public class Day2 : Day, DailySolution<int, string>
    {
        public int Part1()
        {
            var twos = 0;
            var threes = 0;
            foreach (var phrase in input)
            {
                var letters = phrase.Distinct();
                var counterForTwo = false;
                var counterFOrThree = false;
                foreach (var letter in letters)
                {
                    var count = phrase.Count(character => character == letter);
                    if (count == 2 && !counterForTwo)
                    {
                        twos++;
                        counterForTwo = true;

                    } else if (count == 3 && !counterFOrThree)
                    {
                        threes++;
                        counterFOrThree = true;
                    }
                }
            }

            return twos * threes;

        }

        public string Part2()
        {
            var phrases = input.ToArray();
            var index = 0;
            for (int i = 0; i < phrases.Length-1; i++)
            {
                var phrase = phrases[i];
                for (int j = i+1; j < phrases.Length; j++)
                {
                    var nextPhrase = phrases[j];
                    var errors = 0;
                    var errorPosition = 0;
                    for (int z = 0; z < phrase.Length; z++)
                    {
                        if (phrase[z] != nextPhrase[z])
                        {
                            errors++;
                            errorPosition = z;
                        }
                    }

                    if (errors == 1)
                    {
                        return phrase.Remove(errorPosition, 1);
                    }
                }


            }

            throw new Exception();
        }
    }
}
