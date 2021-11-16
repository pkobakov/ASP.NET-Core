namespace MyFirstWeb.Models.Data
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.ModelBinders;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DataInputModel
    {
        [Required]
        public string Name  { get; set; }

       
        public DateTime Date { get; set; }

        //[ModelBinder(BinderType = typeof(ExtractYearModelBinder))]
        
        [CustomDateValidation(1900)]
        public int Year { get; set; }
        public Hobby[] Hobbies { get; set; }
    }

    //Custom validation 
    public class CustomDateValidationAttribute : ValidationAttribute
    {
        public CustomDateValidationAttribute(int minYear)
        {
            MinYear = minYear;
            this.ErrorMessage = $"Value should be between {this.MinYear} and {DateTime.UtcNow.Year} year";
        }

        public int MinYear { get; }

        public override bool IsValid(object value)
        {
            if (value is int intValue) 
            {
                if (intValue <= DateTime.UtcNow.Year
                    && intValue>=MinYear)
                {
                    return true;
                }
            
            }

            return false;
        }

    }
}
