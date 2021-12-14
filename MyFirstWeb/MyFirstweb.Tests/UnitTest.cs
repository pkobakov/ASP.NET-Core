namespace MyFirstweb.Tests
{
    using System;
    using Xunit;
    using Moq;
    using MyFirstWeb.Data;
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            var a = 2;
            var b = 3;

            var sum = a + b;
            var ex = 5;
            Assert.Equal(ex, sum);
            Assert.Throws<DivideByZeroException>(() => sum / 0);

        }

        [Fact]
        public void CategoryNameShouldBeCorrect() 
        {
            var category = new Mock<Product>();
            category.Name = "Shirt";

            var ex = "Shirt";

            Assert.Equal(ex, category.Name);
        
        }
    }
}