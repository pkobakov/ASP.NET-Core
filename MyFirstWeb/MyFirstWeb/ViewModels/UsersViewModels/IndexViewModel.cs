namespace MyFirstWeb.ViewModels.UsersViewModels
{
    using System;

    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public int Age { get; set; }
    }
}
