using MaritimeExercise.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Helpers
{
    public interface ICalculationHelper
    {
        float CalculateArithmeticMean(IEnumerable<GDValue> values);

        float CalculateStandardDeviation(IEnumerable<GDValue> values);

        List<float> CalculateBinFrequenciesOf10(IEnumerable<GDValue> values);
    }
}
