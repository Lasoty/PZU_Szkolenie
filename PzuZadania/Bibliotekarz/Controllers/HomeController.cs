using Bibliotekarz.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotekarz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.BookList = new List<Book>()
            {
                new Book() 
                {
                    Id = 1,
                    Author = "John Sharp",
                    Title = "C# programming",
                    PageCount = 654,
                    IsBorrowed = true,
                    Borrower = new Customer()
                    {
                        Id = 11,
                        FirstName = "Leszek",
                        LastName = "Lewandowski"
                    }
                },
                new Book(),
                new Book(),
            };


            return View(model);
        }
    }
}
