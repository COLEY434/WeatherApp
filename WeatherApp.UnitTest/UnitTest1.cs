using System;
using WeatherApp.Api.Services;
using Xunit;

namespace WeatherApp.UnitTest
{
    public class UnitTest1
    {
        
        [Theory]
        [InlineData(4,3,12)]
        [InlineData(4, 5, 20)]
        [InlineData(4, 6, 24)]
        public void MultiplyNumber_TwoNumber_ReturnsMultpliedValue(int input1, int input2, int ezpected)
        {
            //Arrange
            var service = new WeatherService();

            //Act
            var actual = service.MultiplyNumber(input1, input2);

            //Assert
            Assert.Equal(actual, ezpected);
        }
    }
}
