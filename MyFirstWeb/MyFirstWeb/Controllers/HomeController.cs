using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyFirstWeb.Models;
using MyFirstWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            this.config = config;
        }

        public IActionResult Index()
        {
            var vieModel = new IndexViewModel
            {
                Name = "Anonymous",
                ReadPrivacy = this.HttpContext.Session.Keys.Contains("ReadPrivacy"),
                Year = DateTime.UtcNow.Year
            };
            return View(vieModel);
        }

        public IActionResult Privacy()
        {
            this.HttpContext.Session.SetString("ReadPrivacy", "true");
            return View();
        }

        public IActionResult AjaxDemo() 
        {
            return this.View();
        }

        public IActionResult AjaxDemoData()
        {
            return this.Json(new[] {
            new { Name= "Marina", BirthDate="23.11.1978"},
            new { Name= "Niki", BirthDate= "05.06.2018"} 
            });
        }
        
        //[AutoValidateAntiforgeryToken]
        public IActionResult GetData(string info) 
        { 
          return this.Content(info);    
        
        }
        public IActionResult StatusCodeError(int errorCode) 
        {

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
