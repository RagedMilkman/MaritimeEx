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
        private ValuesDB _ValuesDB { get; }
        private FileLoaderHelper _LoadingHelper { get; }
        private CalculationHelper _CalculationHelper { get; }

        public DataController(ValuesDB valuesDB, FileLoaderHelper loadingHelper, CalculationHelper calculationHelper)
        {
            _ValuesDB = valuesDB;
            _LoadingHelper = loadingHelper;
            _CalculationHelper = calculationHelper;
        }

        [HttpGet]
        [Route("EnterValuesIntoDB")]
        public async Task<IActionResult> EnterValuesIntoDB()
        {
            var dataManager = new DataManager();            

            bool result = await dataManager.EnterValuesIntoDB(_ValuesDB, _LoadingHelper);

            return Json(result);
        }

        [HttpGet]
        [Route("GetValues")]
        public async Task<IActionResult> GetValues()
        {
            var dataManager = new DataManager();

            var data = await dataManager.GetValuesFromDB(_ValuesDB);

            return Json(data);
        }

        [HttpGet]
        [Route("CalculateArithmeticMean")]
        public async Task<IActionResult> CalculateArithmeticMean()
        {
            var dataManager = new DataManager();

            var data = await dataManager.CalculateArithmeticMean(_ValuesDB, _CalculationHelper);

            return Json(data);
        }

        [HttpGet]
        [Route("CalculateStandardDeviation")]
        public async Task<IActionResult> CalculateStandardDeviation()
        {
            var dataManager = new DataManager();

            var data = await dataManager.CalculateStandardDeviation(_ValuesDB, _CalculationHelper);

            return Json(data);
        }

        [HttpGet]
        [Route("ComputeFrequenciesOfBinSize10")]
        public async Task<IActionResult> ComputeFrequenciesOfBinSize10()
        {
            var dataManager = new DataManager();

            var data = await dataManager.ComputeFrequenciesOfBinSize(_ValuesDB, _CalculationHelper);

            return Json(data);
        }
    }
}
