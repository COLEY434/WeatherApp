using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Api;
using Xunit;

namespace WeatherApp.UnitTest.UtilsTests
{
    public class UtilsTestCases
    {
        [Theory]
        [InlineData("paris", true)]
        [InlineData("", false)]
        [InlineData("  ", false)]
        [InlineData(null, false)]
        public void IsInputValid_ChecksIfInputIsNullOrEmptyOrWhitespace_ReturnsTrueOrFalse(string input, bool expected)
        {
            //Arrange
           

            //Act
            bool actual = Utils.IsInputValid(input);

            //Assert
            Assert.Equal(expected, actual);

        }
    }
}
