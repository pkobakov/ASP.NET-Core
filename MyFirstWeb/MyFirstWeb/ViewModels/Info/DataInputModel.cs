namespace MyFirstWeb.ViewModels.Info
{
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

        [Required]
        public Hobby[] Hobbies { get; set; }
    }
}
