namespace MyFirstWeb.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUser : IdentityUser
    {
        public DateTime? BirthDate { get; set; }
    }
}
