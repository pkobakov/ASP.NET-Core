namespace MyFirstWeb.Data
{
    using MyFirstWeb.Models.Enums.Products;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public class Product 
    {
        public int Id { get; set; }

        [Required, MinLength(5)]
        public string ProductName { get; set; }

        public Category Category { get; set; } 

        [Required, MaxLength(20)]
        public string Description { get; set; }

        public double Price { get; set; }

    }





}
