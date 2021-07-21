using MaritimeExercise.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class StringSplitterTests
    {
        private readonly StringSplitter _StringSplitter;

        public StringSplitterTests()
        {

            _StringSplitter = new StringSplitter();
        }

        [Fact]
        public void InputSplitTest()
        {
            // Arrange
            string intTest = "1,2,3,4,5";
            string floatTest = "1.12,2.23,3.34,4.56,5.95";
            string stringTest = "dog,rabbit,carrot";

            // Act
            var intValues = _StringSplitter.SplitString(intTest);
            var floatValues = _StringSplitter.SplitString(floatTest);
            var stringValues = _StringSplitter.SplitString(stringTest);

            // Assert
            Assert.Equal(new List<string>() { "1", "2", "3", "4", "5" }, intValues);
            Assert.Equal(new List<string>() { "1.12", "2.23", "3.34", "4.56", "5.95" }, floatValues);
            Assert.Equal(new List<string>() { "dog","rabbit","carrot" }, stringValues);
        }
    }
}
