using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Day6 : Day, DailySolution<int, int>
    {
        public int Part1()
        {
            var coords = new List<Coordinate>();
            foreach (var inputLine in input)
            {
                var splut = inputLine.Split(',');
                coords.Add(new Coordinate{x = int.Parse(splut[0]), y = int.Parse(splut[1]), PointName = inputLine, AreaSize = 0});
            }

            // It is infite either if it has max/min x or y
            var maxX = coords.Select(z => z.x).Max();
            var minX = coords.Select(z => z.x).Min();
            var maxY = coords.Select(z => z.y).Max();
            var minY = coords.Select(z => z.y).Min();
            var enclosedSpots = new List<Coordinate>();
            foreach (var coordinate in coords)
            {
                var elminate = false;
                for (int i = minX; i < maxX; i++)
                {
                    // Check upper line, if that is closest to current spot, eleminate it
                    var point = coords.OrderBy(o => Math.Abs(o.x - i) + Math.Abs(o.y - minY)).First();
                    if (point.PointName == coordinate.PointName)
                    {
                        elminate = true;
                        break;
                    }
                    // check lower line, if that is closest to current spot, eleminate it 
                    point = coords.OrderBy(o => Math.Abs(o.x - i) + Math.Abs(o.y - maxY)).First();
                    if (point.PointName == coordinate.PointName)
                    {
                        elminate = true;
                        break;
                    }
                }

                if (elminate)
                {
                    continue;
                }
                for (int i = minY; i < maxY; i++)
                {
                    // Check left line, if that is closest to current spot, eleminate it
                    var point = coords.OrderBy(o => Math.Abs(o.x - minX) + Math.Abs(o.y - i)).First();
                    if (point.PointName == coordinate.PointName)
                    {
                        elminate = true;
                        break;
                    }
                    // check right line, if that is closest to current spot, eleminate it 
                    point = coords.OrderBy(o => Math.Abs(o.x - maxX) + Math.Abs(o.y - i)).First();
                    if (point.PointName == coordinate.PointName)
                    {
                        elminate = true;
                        break;
                    }
                }
                if (elminate)
                {
                    continue;
                }
                enclosedSpots.Add(coordinate);
         }


            for (int i = minX; i < maxX; i++)
            {
                for (int j = minY; j < maxY; j++)
                {
                   var point = coords.OrderBy(o => Math.Abs(o.x - i) + Math.Abs(o.y - j)).First();
                    var distance = Math.Abs(point.x - i) + Math.Abs(point.y - j);
                    var allPoints = coords.Where(o => (Math.Abs(o.x - i) + Math.Abs(o.y - j)) == distance);
                    if (allPoints.Count() >1)
                    {
                        continue;
                    }
                    point.AreaSize++;
                }
            }


            return enclosedSpots.Max(o => o.AreaSize);

        }


        public int Part2()
        {
            var coords = new List<Coordinate>();
            foreach (var inputLine in input)
            {
                var splut = inputLine.Split(',');
                coords.Add(new Coordinate { x = int.Parse(splut[0]), y = int.Parse(splut[1]), PointName = inputLine, AreaSize = 0 });
            }

            // It is infite either if it has max/min x or y
            var maxX = coords.Select(z => z.x).Max();
            var minX = coords.Select(z => z.x).Min();
            var maxY = coords.Select(z => z.y).Max();
            var minY = coords.Select(z => z.y).Min();
            var areaSize = 0;
            for (int i = minX-1000; i < maxX+1000; i++)
            {
                for (int j = minY-1000; j < maxY+1000; j++)
                {
                    if (coords.Sum(o => Math.Abs(o.x - i) + Math.Abs(o.y - j)) < 10000)
                    {
                        areaSize++;
                    }
                }
            }

            return areaSize;
        }


    }

    public class Coordinate
    {
        public int x { get; set; }

        public int y { get; set; }
        public string PointName { get; set; }
        public int AreaSize { get; set; }
    }
}
