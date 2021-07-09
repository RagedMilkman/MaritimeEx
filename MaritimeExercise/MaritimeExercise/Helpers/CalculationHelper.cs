using MaritimeExercise.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Helpers
{
    public class CalculationHelper
    {
        public float CalculateArithmeticMean(IEnumerable<GDValue> values)
        {
            List<float> fValues = values.Select(x => x.Value).ToList();

            float sum = 0;

            fValues.ForEach(x => sum += x);

            float mean = sum / fValues.Count;

            return mean;
        }

        public float CalculateStandardDeviation(IEnumerable<GDValue> values)
        {
            float mean = CalculateArithmeticMean(values);

            List<GDValue> lValues = values.ToList();

            double sum = 0;
            lValues.ForEach(x =>
            {
                float distToMean = x.Value - mean;
                double sqrDist = Math.Pow(distToMean, 2);
                sum += sqrDist;
            });

            double div = sum / lValues.Count();

            double stdDev = Math.Sqrt(div);

            return (float)stdDev;
        }

        /// <summary>
        /// This method has been created extremely bespoke to save dev time.
        /// It would be better to pass in the intervals of the bins and then create them dynamically.
        /// </summary>
        /// <param name="values"></param>
        /// <returns> Returns list of frequencies </returns>
        public List<float> CalculateBinFrequenciesOf10(IEnumerable<GDValue> values)
        {
            List<float> lValues = values.Select(x => x.Value).ToList();

            List<float> frequencies = new List<float>();

            // Create Bins
            for (int i = 0; i < 10; i++)
                frequencies.Add(0);

            lValues.ForEach(value =>
            {
                // get bin
                int index = (int)Math.Floor(value / 10);

                // increase bin
                frequencies[index]++;
            });

            return frequencies;
        }
    }
}
