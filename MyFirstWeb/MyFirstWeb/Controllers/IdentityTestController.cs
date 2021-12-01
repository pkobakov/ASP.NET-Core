using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyFirstWeb.Controllers
{
    public class IdentityTestController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public IdentityTestController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Create() 
        {
            var user = new IdentityUser
            { 
            Email = "pkobakov@mail.bg",
            UserName = "pkobakov",
            PhoneNumber =  "0877566999",
            EmailConfirmed = true,
            };


             return this.Json(await this.userManager.CreateAsync(user, "paparazzi")); 
        }

        public async Task<IActionResult> Login() 
        {
            var result = await this.signInManager.PasswordSignInAsync("pkobakov@mail.bg", "paparazzi", true, true);
            
            return this.Json(result);
        }

        public async Task<IActionResult> Logout() 
        { 
        await this.signInManager.SignOutAsync();    

            return Redirect("/");
        
        }

        [Authorize]
        public async Task<IActionResult> WhoAmI()
        => this.Json(await this.userManager.GetUserAsync(this.User));
    }
}
