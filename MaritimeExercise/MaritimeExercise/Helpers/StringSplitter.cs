using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Helpers
{
    public class StringSplitter : IStringSplitter
    {
        public List<string> SplitString(string input)
        {
            return input.Split(",").ToList();
        }
    }
}
