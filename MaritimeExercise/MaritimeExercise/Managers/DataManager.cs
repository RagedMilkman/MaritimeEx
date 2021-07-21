using MaritimeExercise.Database;
using MaritimeExercise.DataModels;
using MaritimeExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Managers
{
    public class DataManager : IDataManager
    {
        public async Task<bool> EnterValuesIntoDB(IValuesDB valuesDB, IFileLoaderHelper loadingHelper, IStringSplitter stringSplitter)
        {
            bool success = true;

            try
            {
                // Clear the DB.
                valuesDB.ClearValues();

                // Load the values
                IEnumerable<GDValue> values = loadingHelper.LoadDataFromFile(stringSplitter);

                // Enter the values
                valuesDB.SaveGDValues(values);
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public async Task<IEnumerable<GDValue>> GetValuesFromDB(IValuesDB valuesDB)
        {
            return await valuesDB.GetAllValues();
        }

        public async Task<float> CalculateArithmeticMean(IValuesDB valuesDB, ICalculationHelper calculationHelper)
        {
            IEnumerable<GDValue> values = await GetValuesFromDB(valuesDB);

            return calculationHelper.CalculateArithmeticMean(values);
        }

        public async Task<float> CalculateStandardDeviation(IValuesDB valuesDB, ICalculationHelper calculationHelper)
        {
            IEnumerable<GDValue> values = await GetValuesFromDB(valuesDB);

            return calculationHelper.CalculateStandardDeviation(values);
        }

        public async Task<List<float>> ComputeFrequenciesOfBinSize(IValuesDB valuesDB, ICalculationHelper calculationHelper)
        {
            IEnumerable<GDValue> values = await GetValuesFromDB(valuesDB);

            return calculationHelper.CalculateBinFrequenciesOf10(values);
        }
    }
}
