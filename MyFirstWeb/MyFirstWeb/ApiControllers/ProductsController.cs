namespace MyFirstWeb.ApiControllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyFirstWeb.Data;
    using MyFirstWeb.Models.Enums.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }

       [HttpGet]
       public IEnumerable<Product> Get() 
        { 
        
        return db.Products.ToList();
        
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get (int id) 
        { 
         var product = db.Products.Find(id);
            if (product == null)
            {
                return this.NotFound();
            }
            
            return product;
        } 

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            return this.CreatedAtAction("Get", new {id = product.Id}, product);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Product product) 
        { 
            this.db.Entry(product).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var product = this.db.Products.Find(id);

            if (product == null)
            {
                return this.NotFound();
            }
            this.db.Remove(product);
            await this.db.SaveChangesAsync();
            return this.NoContent();

        }
    }
}
