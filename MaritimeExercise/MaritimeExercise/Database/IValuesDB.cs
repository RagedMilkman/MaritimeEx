using MaritimeExercise.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Database
{
    public interface IValuesDB
    {
        Task<List<GDValue>> GetAllValues();

        void SaveGDValues(IEnumerable<GDValue> gdValues);

        void ClearValues();
    }
}
