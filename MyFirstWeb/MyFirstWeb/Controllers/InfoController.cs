namespace MyFirstWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;
    using MyFirstWeb.Filters;
    using MyFirstWeb.ViewModels.Info;
    using System;
    using System.Threading;

    //filter configuration for the current controller
    [AddHeaderActionFilterAttribute]
    public class InfoController : Controller
    {
        private readonly ILogger logger;
        private readonly IMemoryCache cache;

        public InfoController(
            ILogger<InfoController> logger,
            IMemoryCache memoryCache)
        {
            this.logger = logger;
            this.cache = memoryCache;
        }
        public IActionResult Time()
        {
           this.logger.LogInformation(54321, "User asked for the time");

            if (!cache.TryGetValue<DateTime>("Data", out var cacheTime))
            {
                cacheTime = GetData();
                cache.Set("Data", cacheTime);
            }

            return this.Content
                (DateTime.Now.ToLongTimeString() + " - Cache: " + cacheTime);
        }


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

        private DateTime GetData() 
        {
            Thread.Sleep(5000);
            return DateTime.Now;
        }

        //Session


    }
}
