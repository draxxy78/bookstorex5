using CollageLibraryManager.Books.Api.Manager;
using CollageLibraryManager.Books.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CollageLibraryManager.Books.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public ActionResult<List<BooksInfo>> Get([FromServices]IBooksManager booksManager)
        {
            var books = booksManager.GetBooks(null);
            return books;
        }

        [HttpGet("allbooks/{userId}")]
        public ActionResult<List<BooksInfo>> AllBooks([FromServices]IBooksManager booksManager, string userId)
        {
            var books = booksManager.GetBooks(userId, "allbooks");
            return books;
        }

        [HttpGet("mybooks/{userId}")]
        public ActionResult<List<BooksInfo>> MyBooks([FromServices]IBooksManager booksManager, string userId)
        {
            var books = booksManager.GetBooks(userId, "mybooks");
            return books;
        }

        [HttpPost("allocate")]
        public ActionResult<bool> AllocateBook([FromBody]AllocationInfo request, [FromServices]IBooksManager booksManager)
        {
            var result = booksManager.AllocateBook(request.BookId, request.UserId, request.Method);
            return result;
        }

        [HttpPost("markavailability")]
        public ActionResult<bool> MarkAvailability([FromBody]AvailabilityRequest request, [FromServices]IBooksManager booksManager)
        {
            var result = booksManager.MarkAvailability(request.BookId, request.IsAvailable);
            return result;
        }

        [HttpPost("addbook")]
        public ActionResult<bool> AddBook([FromBody]BooksInfo booksInfo, [FromServices]IBooksManager booksManager)
        {
            var result = booksManager.AddBook(booksInfo);
            return result;
        }
    }
}
