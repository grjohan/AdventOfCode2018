using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Day
    {
        internal List<string> input;

        public Day()
        {
            input = InputGetter.GetInput(int.Parse(GetType().Name.Substring(3)));
        }
    }
}
