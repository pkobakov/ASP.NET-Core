namespace MyFirstWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.Filters;
    using MyFirstWeb.ViewModels.Info;
    using System;

    //filter configuration for the current controller
    [AddHeaderActionFilterAttribute]
    public class InfoController : Controller
    {
        public IActionResult Time()
        => this.Content(DateTime.Now.ToLongTimeString());


        public IActionResult Date()
        => this.Content(DateTime.Now.ToLongDateString());

        public IActionResult Data([FromHeader(Name= "User-Agent")] string userAgent,DataInputModel model) 
        {

            if (!this.ModelState.IsValid)
            {
                return this.Json(ModelState);
            }
            return this.Json(model);
            //return this.Json(userAgent);
        
        }
    }
}
