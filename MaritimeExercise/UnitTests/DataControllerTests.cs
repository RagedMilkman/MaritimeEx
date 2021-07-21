using MaritimeExercise.Controllers;
using MaritimeExercise.Database;
using MaritimeExercise.Helpers;
using MaritimeExercise.Managers;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class DataControllerTests
    {
        private readonly DataController _DataController;

        private readonly Mock<IValuesDB> _MockDB;

        private readonly Mock<IDataManager> _SubDataManager;

        private readonly Mock<IFileLoaderHelper> _FileLoaderHelper;

        private readonly Mock<ICalculationHelper> _CalculationHelper;

        private readonly Mock<IStringSplitter> _StringSplitter;

        public DataControllerTests()
        {
            _MockDB = new Mock<IValuesDB>();

            _MockDB.Setup(x => x.GetAllValues())
                .Returns(Task.FromResult(new List<MaritimeExercise.DataModels.GDValue>() { 
                    new MaritimeExercise.DataModels.GDValue() { Value = 1 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 2 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 3 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 4 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 5 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 6 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 7 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 8 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 9 },
                    new MaritimeExercise.DataModels.GDValue() { Value = 10 },
                }));

            _SubDataManager = new Mock<IDataManager>();
            _FileLoaderHelper = new Mock<IFileLoaderHelper>();
            _CalculationHelper = new Mock<ICalculationHelper>();
            _StringSplitter = new Mock<IStringSplitter>();

            _DataController = new DataController(
                _MockDB.Object,
                _SubDataManager.Object,
                _FileLoaderHelper.Object,
                _CalculationHelper.Object,
                _StringSplitter.Object
            );

        }

        [Fact]
        public async void EnterValuesIntoDBRouteTest()
        {
            // Act
            _ = await _DataController.EnterValuesIntoDB();

            // Assert
            _SubDataManager.Verify(m => m.EnterValuesIntoDB(_MockDB.Object, _FileLoaderHelper.Object, _StringSplitter.Object), Times.Once());
        }

        [Fact]
        public async void GetValuesRouteTest()
        {
            // Act
            _ = await _DataController.GetValues();

            // Assert
            _SubDataManager.Verify(m => m.GetValuesFromDB(_MockDB.Object), Times.Once());
        }

        [Fact]
        public async void CalculateArithmeticMeanRouteTest()
        {
            // Act
            _ = await _DataController.CalculateArithmeticMean();

            // Assert
            _SubDataManager.Verify(m => m.CalculateArithmeticMean(_MockDB.Object, _CalculationHelper.Object), Times.Once());
        }

        [Fact]
        public async void CalculateStandardDeviationRouteTest()
        {
            // Act
            _ = await _DataController.CalculateStandardDeviation();

            // Assert
            _SubDataManager.Verify(m => m.CalculateStandardDeviation(_MockDB.Object, _CalculationHelper.Object), Times.Once());
        }

        [Fact]
        public async void ComputeFrequenciesOfBinSize10RouteTest()
        {
            // Act
            _ = await _DataController.ComputeFrequenciesOfBinSize10();

            // Assert
            _SubDataManager.Verify(m => m.ComputeFrequenciesOfBinSize(_MockDB.Object, _CalculationHelper.Object), Times.Once());
        }
    }
}
