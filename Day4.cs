using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Day4 : Day, DailySolution<int, int>
    {
        public int Part1()
        {
            var guards = GetSleepSchedule();
            var guard = guards.OrderByDescending(o => o.AsleepMinutes.Sum()).First();
            var index = 0;
            for (int i = 1; i < 60; i++)
            {
                if (guard.AsleepMinutes[i] > guard.AsleepMinutes[index])
                {
                    index = i;
                }
            }

            return guard.GuardId * (index);
        }

        public int Part2()
        {

            var guards = GetSleepSchedule();
            var guard = guards.OrderByDescending(o => o.AsleepMinutes.Max()).First();
            var index = 0;
            for (int i = 1; i < 60; i++)
            {
                if (guard.AsleepMinutes[i] > guard.AsleepMinutes[index])
                {
                    index = i;
                }
            }

            return guard.GuardId * (index);
        }

        internal List<Guard> GetSleepSchedule()
        {
            var guards = new List<Guard>();
            Guard currentGuard = null;
            var asleep = false;
            var ordered = input.OrderBy(o => DateTime.Parse(o.Substring(1, 16))).ToList();

            for (int i = 0; i < ordered.Count(); i++)
            {

                var line = ordered[i];
                if (line.Contains("Guard")) // Someone is awake here
                {
                    asleep = false;
                    var guardID = int.Parse(line.Substring(line.IndexOf("#") + 1, line.IndexOf("begins") - line.IndexOf("#") - 1));
                    currentGuard = guards.SingleOrDefault(o => o.GuardId == guardID);
                    if (currentGuard == null)
                    {
                        var tempGuard = new Guard { GuardId = guardID, AsleepMinutes = new List<int>() };
                        for (int j = 0; j < 60; j++)
                        {
                            tempGuard.AsleepMinutes.Add(0);
                        }
                        guards.Add(tempGuard);
                        currentGuard = tempGuard;
                    }
                }

                else if (line.Contains("asleep"))
                {
                    asleep = true;
                }
                else if (line.Contains("wakes"))
                {
                    asleep = false;
                }

                var minute = int.Parse(line.Substring(15, 2));
                if (asleep)
                {
                    if (ordered.Count != i + 1)
                    {
                        var nextMinute = int.Parse(ordered[i + 1].Substring(15, 2));
                        for (int j = minute; j < nextMinute; j++)
                        {
                            currentGuard.AsleepMinutes[j]++;
                        }
                    }
                }
            }
            return guards;
        }
    }

        public class Guard
        {
            public int GuardId { get; set; }
            public List<int> AsleepMinutes { get; set; }
        }
}
