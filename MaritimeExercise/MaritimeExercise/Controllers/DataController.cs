using MaritimeExercise.Database;
using MaritimeExercise.Helpers;
using MaritimeExercise.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Controllers
{
    [Route("api/DataController")]
    [ApiController]
    public class DataController : Controller
    {
        private IValuesDB _ValuesDB { get; }
        private IDataManager _DataManager { get; }
        private IFileLoaderHelper _LoadingHelper { get; }
        private ICalculationHelper _CalculationHelper { get; }
        private IStringSplitter _StringSplitter { get; }

        public DataController(IValuesDB valuesDB, IDataManager dataManager, IFileLoaderHelper loadingHelper, ICalculationHelper calculationHelper, IStringSplitter stringSplitter)
        {
            _ValuesDB = valuesDB;
            _DataManager = dataManager;
            _LoadingHelper = loadingHelper;
            _CalculationHelper = calculationHelper;
            _StringSplitter = stringSplitter;
        }

        [HttpGet]
        [Route("EnterValuesIntoDB")]
        public async Task<IActionResult> EnterValuesIntoDB()
        {
            bool result = await _DataManager.EnterValuesIntoDB(_ValuesDB, _LoadingHelper, _StringSplitter);

            return Json(result);
        }

        [HttpGet]
        [Route("GetValues")]
        public async Task<IActionResult> GetValues()
        {
            var data = await _DataManager.GetValuesFromDB(_ValuesDB);

            return Json(data);
        }

        [HttpGet]
        [Route("CalculateArithmeticMean")]
        public async Task<IActionResult> CalculateArithmeticMean()
        {
            var data = await _DataManager.CalculateArithmeticMean(_ValuesDB, _CalculationHelper);

            return Json(data);
        }

        [HttpGet]
        [Route("CalculateStandardDeviation")]
        public async Task<IActionResult> CalculateStandardDeviation()
        {
            var data = await _DataManager.CalculateStandardDeviation(_ValuesDB, _CalculationHelper);

            return Json(data);
        }

        [HttpGet]
        [Route("ComputeFrequenciesOfBinSize10")]
        public async Task<IActionResult> ComputeFrequenciesOfBinSize10()
        {
            var data = await _DataManager.ComputeFrequenciesOfBinSize(_ValuesDB, _CalculationHelper);

            return Json(data);
        }
    }
}
