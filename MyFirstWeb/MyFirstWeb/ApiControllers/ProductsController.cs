namespace MyFirstWeb.ApiControllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.Data;
    using MyFirstWeb.Models.Enums.Products;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public Product Test() 
        {
            return new Product
            {
                Id = 123,
                ProductName = null,
                Category = Enum.GetName(typeof(Category), 1),
                Description = "Cool product",
                Price = 78.00M
            };
        }

        [HttpDelete]
        public string Delete() 
        {
            return "Delete";
        }

        [HttpPost]
        public Product Post(Product product)
        {
            return product;

        }
    }
}
