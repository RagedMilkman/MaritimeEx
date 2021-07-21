using MaritimeExercise.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MaritimeExercise.Helpers
{
    /// <summary>
    /// Used for loading the data out of a file
    /// </summary>
    public class FileLoaderHelper : IFileLoaderHelper
    {
        public FileLoaderHelper()
        {

        }

        public IEnumerable<GDValue> LoadDataFromFile(IStringSplitter stringSplitter)
        {
            try
            {
                var result = new List<GDValue>();

                using (var rd = new StreamReader("SampleData.csv"))
                {
                    while (!rd.EndOfStream)
                    {
                        List<string> sValues = stringSplitter.SplitString(rd.ReadLine());

                        sValues.ForEach(sValue =>
                        {
                            float fValue = float.Parse(sValue);
                            result.Add(new GDValue() { Value = fValue });
                        });                        
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }        
    }
}
