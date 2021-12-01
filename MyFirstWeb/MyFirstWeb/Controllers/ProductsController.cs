using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyFirstWeb.Models.Enums.Products;
using MyFirstWeb.Models.Products;
using System.IO;
using System.Threading.Tasks;

namespace MyFirstWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Add()
        {
            // if we want to set default values to the fields

            var model = new AddProductModel
            {
                ProductName = "Type your Product name here",
                Description = "Write your description here",
                Price = 0.00M
                
            
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add (AddProductModel model)
        {
            if (!model.Image.FileName.EndsWith(".png"))
            {
                this.ModelState.AddModelError("Image", "Invalid file type.");
            }

            if (model.Image.Length > 10*1024*1024)
            {
                this.ModelState.AddModelError("Image", "The file is too big.");
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            using (FileStream fs = new FileStream
                (this.webHostEnvironment.WebRootPath + "/print.png", FileMode.Create)) 
            { 
               await model.Image.CopyToAsync(fs);
            
            }

                return RedirectToAction("ThankYou");


        }

        public IActionResult Image() 
        {

            return this.PhysicalFile(this.webHostEnvironment.WebRootPath + "/print.png", "image/png");
        
        }

        public IActionResult ThankYou() 
        { 
        
        return this.View();
        }
    }
}
