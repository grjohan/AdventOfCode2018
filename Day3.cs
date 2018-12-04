using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Day3 : Day, DailySolution<int, string>
    {
        public string Part2()
        {

            var square = new String[10000, 10000];
            var count = 0;
            List<string> nonOverlapping = new List<string>();
            foreach (var dataLine in input)
            {
                var revelant = dataLine.Substring(dataLine.IndexOf('@') + 1);
                var StartX = int.Parse(revelant.Substring(0, revelant.IndexOf(',')));
                var StartY = int.Parse(revelant.Substring(revelant.IndexOf(',') + 1, revelant.IndexOf(':') - revelant.IndexOf(',') - 1));
                var lengthX = int.Parse(revelant.Substring(revelant.IndexOf(':') + 1,revelant.IndexOf('x') - revelant.IndexOf(':') - 1));
                var lengthY = int.Parse(revelant.Substring(revelant.IndexOf('x') + 1));
                var overlapping = false;
                for (int i = 0; i < lengthX; i++)
                {
                    for (int j = 0; j < lengthY; j++)
                    {
                        if (string.IsNullOrWhiteSpace(square[StartX + i, StartY + j]))
                        {
                            square[StartX + i, StartY + j] = dataLine.Substring(1, dataLine.IndexOf('@')-2);
                        }
                        else
                        {
                            overlapping = true;
                            nonOverlapping.Remove(square[StartX + i, StartY + j]);
                            square[StartX + i, StartY + j] = "OVERLAPPING";
                        }

                       
                    }
                }

                if (!overlapping)
                {
                    nonOverlapping.Add(dataLine.Substring(1, dataLine.IndexOf('@') - 2));
                }

            }

            return nonOverlapping.Single();
        }

        public int Part1()
        {
            var square = new int[10000, 10000];
            var count = 0;
            foreach (var dataLine in input)
            {
                var revelant = dataLine.Substring(dataLine.IndexOf('@') + 1);
                var StartX = int.Parse(revelant.Substring(0, revelant.IndexOf(',')));
                var StartY = int.Parse(revelant.Substring(revelant.IndexOf(',') + 1, revelant.IndexOf(':') - revelant.IndexOf(',') - 1));
                var lengthX = int.Parse(revelant.Substring(revelant.IndexOf(':') + 1, revelant.IndexOf('x') - revelant.IndexOf(':') - 1));
                var lengthY = int.Parse(revelant.Substring(revelant.IndexOf('x') + 1));
                for (int i = 0; i < lengthX; i++)
                {
                    for (int j = 0; j < lengthY; j++)
                    {
                        square[StartX + i, StartY + j]++;
                    }
                }

            }

            for (int j = 0; j < 10000; j++)
            {
                for (int i = 0; i < 10000; i++)
                {
                    if (square[j, i] > 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
