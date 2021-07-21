using MaritimeExercise.Database;
using MaritimeExercise.DataModels;
using MaritimeExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Managers
{
    public interface IDataManager
    {
        Task<bool> EnterValuesIntoDB(IValuesDB valuesDB, IFileLoaderHelper loadingHelper, IStringSplitter stringSplitter);

        Task<IEnumerable<GDValue>> GetValuesFromDB(IValuesDB valuesDB);

        Task<float> CalculateArithmeticMean(IValuesDB valuesDB, ICalculationHelper calculationHelper);

        Task<float> CalculateStandardDeviation(IValuesDB valuesDB, ICalculationHelper calculationHelper);

        Task<List<float>> ComputeFrequenciesOfBinSize(IValuesDB valuesDB, ICalculationHelper calculationHelper);
    }
}
