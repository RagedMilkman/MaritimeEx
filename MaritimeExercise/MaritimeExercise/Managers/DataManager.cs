using MaritimeExercise.Database;
using MaritimeExercise.DataModels;
using MaritimeExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Managers
{
    public class DataManager
    {
        public async Task<bool> EnterValuesIntoDB(ValuesDB valuesDB, FileLoaderHelper loadingHelper)
        {
            bool success = true;

            try
            {
                // Clear the DB.
                valuesDB.ClearValues();

                // Load the values
                IEnumerable<GDValue> values = loadingHelper.LoadDataFromFile();

                // Enter the values
                valuesDB.SaveGDValues(values);
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public async Task<IEnumerable<GDValue>> GetValuesFromDB(ValuesDB valuesDB)
        {
            return await valuesDB.GetAllValues();
        }

        public async Task<float> CalculateArithmeticMean(ValuesDB valuesDB, CalculationHelper calculationHelper)
        {
            IEnumerable<GDValue> values = await GetValuesFromDB(valuesDB);

            return calculationHelper.CalculateArithmeticMean(values);
        }

        public async Task<float> CalculateStandardDeviation(ValuesDB valuesDB, CalculationHelper calculationHelper)
        {
            IEnumerable<GDValue> values = await GetValuesFromDB(valuesDB);

            return calculationHelper.CalculateStandardDeviation(values);
        }

        public async Task<List<float>> ComputeFrequenciesOfBinSize(ValuesDB valuesDB, CalculationHelper calculationHelper)
        {
            IEnumerable<GDValue> values = await GetValuesFromDB(valuesDB);

            return calculationHelper.CalculateBinFrequenciesOf10(values);
        }
    }
}
