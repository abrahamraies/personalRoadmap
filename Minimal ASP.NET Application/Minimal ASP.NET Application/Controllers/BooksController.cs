using Microsoft.AspNetCore.Mvc;
using Minimal_ASP.NET_Application.Services.Interfaces;

namespace Minimal_ASP.NET_Application.Controllers
{
    public class BooksController(IBookService bookService) : Controller
    {
        private readonly IBookService _bookService = bookService;

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult AddBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                ModelState.AddModelError("", "Title cannot be empty.");
                return View("Index", _bookService.GetAllBooks());
            }

            _bookService.AddBook(title);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBook(string title)
        {
            _bookService.RemoveBook(title);
            return RedirectToAction("Index");
        }
    }
}
