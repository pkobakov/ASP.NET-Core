namespace MyFirstWeb.ViewComponets
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstWeb.Data;
    using MyFirstWeb.ViewModels.ViewComponents;
    using System.Linq;
    using System.Threading.Tasks;

    public class RegisteredUsersViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public RegisteredUsersViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke(string title) 
        {
            var users = db.Users.Count();
            var viewModel = new RegisteredUsersViewComponentModel 
            { 
               Title = title,
               Users = users
            };

            return View(viewModel);
        }

    }
}
