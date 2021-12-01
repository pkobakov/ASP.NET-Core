using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWeb.ViewModels.Info
{
    //Object validation
    public class Hobby : IValidatableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name.Length>10 || string.IsNullOrWhiteSpace(this.Name))
            {
                yield return new ValidationResult("Name should have less than 10 characters.");
            }

            if (this.Description == null)
            {
                yield return new ValidationResult("Description is required.");
            }
        }
    }
}