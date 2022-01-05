using System;

namespace MyFirstWeb.ViewModels
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int Year { get; set; }
        public int UsersCount { get; set; }
        public bool ReadPrivacy { get; internal set; }
    }
}
