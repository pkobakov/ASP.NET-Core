using MyFirstWeb.ViewModels.Info;
using System;
using Xunit;

namespace MyFirstweb.Tests
{
    public class CustomDateMinValueAttributeTest
    {
        [Fact]
        public void IsValidReturnsFalseIfYearIsOutOfRange()
        {
            var attribute = new CustomDateValidationAttribute(2017);

            var isValid = attribute.IsValid(2016);

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsTrueIfYearIsBeforeCurrentYear()
        {
            var attribute = new CustomDateValidationAttribute(2020);

            var isValid = attribute.IsValid(DateTime.UtcNow.Year);

            Assert.True(isValid);
        }

        [Fact]
        public void IsMinYearValueCorrect() 
        {
            var attribute = new CustomDateValidationAttribute(2021);

            var ex = 2021;

            Assert.Equal(ex, attribute.MinYear);
        } 


    }
}
