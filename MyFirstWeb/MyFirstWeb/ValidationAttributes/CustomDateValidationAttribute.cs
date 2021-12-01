namespace MyFirstWeb.ViewModels.Info
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //Custom validation attribute
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
