using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Helpers
{
    public interface IStringSplitter
    {
        List<string> SplitString(string input);
    }
}
