using MaritimeExercise.Database;
using MaritimeExercise.DataModels;
using MaritimeExercise.Helpers;
using MaritimeExercise.Managers;
using Moq;
//using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class DataManagerTests
    {
        private readonly DataManager _DataManager;

        private readonly Mock<IValuesDB> _MockDB;

        private readonly Mock<IFileLoaderHelper> _FileLoaderHelper;

        private readonly Mock<ICalculationHelper> _CalculationHelper;

        private readonly Mock<IStringSplitter> _StringSplitter;

        public DataManagerTests()
        {
            _MockDB = new Mock<IValuesDB>();

            _MockDB.Setup(x => x.GetAllValues())
                .Returns(Task.FromResult(new List<GDValue>() {
                    new GDValue() { Value = 1 },
                    new GDValue() { Value = 2 },
                    new GDValue() { Value = 3 },
                    new GDValue() { Value = 4 },
                    new GDValue() { Value = 5 },
                    new GDValue() { Value = 6 },
                    new GDValue() { Value = 7 },
                    new GDValue() { Value = 8 },
                    new GDValue() { Value = 9 },
                    new GDValue() { Value = 10 },
                }));

            _MockDB.Setup(x => x.ClearValues());

            _FileLoaderHelper = new Mock<IFileLoaderHelper>();
            _CalculationHelper = new Mock<ICalculationHelper>();
            _StringSplitter = new Mock<IStringSplitter>();

            _DataManager = new DataManager();
        }
        
        [Fact]
        public async void EnterValuesIntoDBRouteTest()
        {
            // Act
            bool result = await _DataManager.EnterValuesIntoDB(_MockDB.Object, _FileLoaderHelper.Object, _StringSplitter.Object);
            
            // Assert
            _MockDB.Verify(m => m.ClearValues(), Times.Once());
            _FileLoaderHelper.Verify(m => m.LoadDataFromFile(_StringSplitter.Object), Times.Once());

            Assert.True(result);

            if(result)
                _MockDB.Verify(m => m.SaveGDValues(It.IsAny<IEnumerable<GDValue>>()), Times.Once());
        }

        [Fact]
        public async void GetValuesFromDBRouteTest()
        {
            // Act
            _ = await _DataManager.GetValuesFromDB(_MockDB.Object);

            // Assert
            _MockDB.Verify(m => m.GetAllValues(), Times.Once());
        }

        [Fact]
        public async void CalculateArithmeticMeanRouteTest()
        {
            // Act
            _ = await _DataManager.CalculateArithmeticMean(_MockDB.Object, _CalculationHelper.Object);

            // Assert
            _CalculationHelper.Verify(m => m.CalculateArithmeticMean(It.IsAny<IEnumerable<GDValue>>()), Times.Once());
        }

        [Fact]
        public async void CalculateStandardDeviationRouteTest()
        {
            // Act
            _ = await _DataManager.CalculateStandardDeviation(_MockDB.Object, _CalculationHelper.Object);

            // Assert
            _CalculationHelper.Verify(m => m.CalculateStandardDeviation(It.IsAny<IEnumerable<GDValue>>()), Times.Once());
        }
    }
}
