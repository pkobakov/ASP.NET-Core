namespace MyFirstweb.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyFirstWeb.ApiControllers;
    using MyFirstWeb.Data;
    using MyFirstWeb.Models.Enums.Products;
    using Xunit;

    public class ProductsControllerTest
    {
        [Fact]
        public void GetProductShouldReturnProductIfFound()
        {
            var productShirt = new Product
            {
                Id = 1,
                ProductName = "Shirt",
                Description = "Description",
                Category = Category.Clothes,
                Price = 12.00M
            };

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var testDbContext = new ApplicationDbContext(optionsBuilder.Options);

            testDbContext.Add(productShirt);
            testDbContext.SaveChanges();

            var controller = new ProductsController(testDbContext);

            var result = controller.Get(2);
            var ex = "Shirt";
            Assert.NotNull(result);
            Assert.Equal(ex, productShirt.ProductName);


        }

        [Fact]
        public void GetProductShouldReturnNotFoundIfProductDoesNotExist()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase("test");
            var testDbContext = new ApplicationDbContext(optionsBuilder.Options);
            var controller = new ProductsController(testDbContext);
            var result = controller.Get(2);

            Assert.Null(result.Value);
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
