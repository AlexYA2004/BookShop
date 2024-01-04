using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookShop.Domain.Entities;
using BookShop.Models;
using BookShop.Services.Interfaces;

namespace BookShop.Controllers
{
    public class BookListController : Controller
    {
        private readonly ILogger<BookListController> _logger;

        private readonly IBookService _bookService;

        public BookListController(ILogger<BookListController> logger, IBookService bookService)
        {
            _logger = logger;

            _bookService = bookService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult BuyBook()
        {
            BuyBookViewModel model = new BuyBookViewModel();

            _bookService.SetBookInfo(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BuyBook(int id)
        {

            await _bookService.BuyBookbyId(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
