using CollageLibraryManager.Books.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollageLibraryManager.Books.Api.Manager
{
    public interface IBooksManager
    {
        List<BooksInfo> GetBooks(string userId, string type = null);
        bool AddBook(BooksInfo book);
        bool AllocateBook(string bookId, string userId, string method);
        bool MarkAvailability(string bookId, bool isAvailable);
    }
}
