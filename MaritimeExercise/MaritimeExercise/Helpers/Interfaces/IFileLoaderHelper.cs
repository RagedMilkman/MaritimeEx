using MaritimeExercise.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Helpers
{
    public interface IFileLoaderHelper
    {
        IEnumerable<GDValue> LoadDataFromFile(IStringSplitter stringSplitter);
    }
}
