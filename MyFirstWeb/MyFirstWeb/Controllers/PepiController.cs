namespace MyFirstWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.ViewModels;
    using System;

    public class PepiController : Controller
    {

        public IActionResult Index(int id) 
        {
            var viewModel = new IndexViewModel();
            viewModel.Id = id;
            viewModel.Username = this.User.Identity.Name;
            viewModel.Age = viewModel.Year - 1974;

            return this.View(viewModel);
        
        }


    }
}
