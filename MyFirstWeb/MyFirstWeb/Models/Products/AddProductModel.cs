namespace MyFirstWeb.Models.Products
{
    using Microsoft.AspNetCore.Http;
    using MyFirstWeb.Models.Enums.Products;
    using System.ComponentModel.DataAnnotations;

    public class AddProductModel
    {
        [Required (ErrorMessage = "Product name is required")]
        [StringLength(10, MinimumLength = 2)]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required (ErrorMessage = "Category is required")]
        public Category? Category { get; set; }

        [Required (ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Price is required")]
        [Range(1,100)]
        public decimal? Price { get; set; }
        
        [Display(Name ="Image")]
        public IFormFile Image { get; set; }
    }
}
