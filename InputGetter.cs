using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ConsoleApp6
{
    public static class InputGetter
    {
        public static List<string> GetInput(int dayNumber)
        {
            var sessionValue = File.ReadAllText(@"C:\Development\projects\AdventOfCode\2018\SessionCode.txt");
            var client = new RestClient("https://adventofcode.com/2018/day");
            var req = new RestRequest($"{dayNumber}/input");
            req.AddCookie("session",sessionValue);
            var resp = client.Execute(req);
            return resp.Content.Split('\n').Where(o => !String.IsNullOrEmpty(o)).ToList();
        }
    }
}
