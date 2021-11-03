using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.ViewModels
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public int Age { get; set; }
    }
}
