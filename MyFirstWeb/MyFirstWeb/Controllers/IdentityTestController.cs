using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFirstWeb.Models;
using System.Threading.Tasks;

namespace MyFirstWeb.Controllers
{
    public class IdentityTestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityTestController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Create() 
        {
            var user = new ApplicationUser
            { 
            Email = "pkobakov@mail.bg",
            UserName = "pkobakov",
            PhoneNumber =  "0877566999",
            EmailConfirmed = true,
            };

            var result = await this.userManager.CreateAsync(user, "Paparazzi");
             return this.Json(result); 
        }

        [Authorize]
        public async Task<IActionResult> AddRoleToUser() 
        {

            if (!await this.roleManager.RoleExistsAsync("Admin"))
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                });
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var result = await this.userManager.AddToRoleAsync(user, "Admin");

            return this.Json(result);
        
        }
        public async Task<IActionResult> Login() 
        {
            var result = await this.signInManager.PasswordSignInAsync("pkobakov@mail.bg", "Paparazzi", true, true);
            
            return this.Json(result);
        }

        public async Task<IActionResult> Logout() 
        { 
        await this.signInManager.SignOutAsync();    

            return Redirect("/");
        
        }

        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> WhoAmI()
        => this.Json(await this.userManager.GetUserAsync(this.User));
    }
}
