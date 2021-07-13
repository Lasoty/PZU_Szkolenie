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
            model.BookList = dbContext.Books
                //.Where(b => b.Author.Contains("Leszek"))
                .ToList();

            return View(model);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Author = model.Author,
                Title = model.Title,
                PageCount = model.PageCount,
                IsBorrowed = model.IsBorrowed
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            ViewBag.Message = "Zapisano do bazy danych";
            return RedirectToAction(nameof(Index));
        }
    }
}
