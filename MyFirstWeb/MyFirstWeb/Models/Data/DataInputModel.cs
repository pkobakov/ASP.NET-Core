namespace MyFirstWeb.Models.Data
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.ModelBinders;
    using System;

    public class DataInputModel
    {
        public string Name  { get; set; }
        public DateTime Date { get; set; } 

        [ModelBinder(BinderType = typeof(ExtractYearModelBinder))]
        public int Year { get; set; }
        public Hobby[] Hobbies { get; set; }
    }
}
