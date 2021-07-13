using Bibliotekarz.Model;
using Bibliotekarz.Model.Context;
using Bibliotekarz.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotekarz.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;

        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
