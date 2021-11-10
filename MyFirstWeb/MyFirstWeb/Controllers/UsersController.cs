namespace MyFirstWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.ViewModels.UsersViewModels;
    using System;
    using System.Linq;


    public class UsersController : Controller
    {

        public IActionResult Index(int id) 
        {
            var usernameTokens = this.User.Identity.Name;
            var username = usernameTokens
                                    .Split('@', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            var viewModel = new IndexViewModel();
            viewModel.Id = id;
            viewModel.Username = username[0].ToUpper();
            viewModel.Age = viewModel.Year - 1974;

            return this.View(viewModel);
        
        }


    }
}
