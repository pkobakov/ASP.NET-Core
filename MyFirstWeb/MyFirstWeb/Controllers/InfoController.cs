namespace MyFirstWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [AddHeaderActionFilterAttribute]
    public class InfoController : Controller
    {
        public IActionResult Time()
        => this.Content(DateTime.Now.ToLongTimeString());


        public IActionResult Date()
        => this.Content(DateTime.Now.ToLongDateString());
    }
}
