using CollageLibraryManager.Books.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CollageLibraryManager.Books.Api.Manager
{
    public class BooksManager : IBooksManager
    {
        public bool AllocateBook(string bookId, string userId, string method)
        {
            var allocationsJson = File.ReadAllText("Data/AllocationInfo.json");
            var allocations = JsonConvert.DeserializeObject<List<AllocationInfo>>(allocationsJson);
            if (method == "add")
            {
                if (allocations.Any(x => x.UserId == userId && x.BookId == bookId))
                {
                    return false;
                }
                allocations.Add(new AllocationInfo()
                {
                    BookId = bookId,
                    UserId = userId
                });
                MarkAvailability(bookId, false);
            }
            else
            {
                allocations = allocations.Where(x => x.BookId != bookId).ToList();
                MarkAvailability(bookId, true);
            }
            var data = JsonConvert.SerializeObject(allocations);
            File.WriteAllText("Data/AllocationInfo.json", data);
            return true;
        }

        public List<BooksInfo> GetBooks(string userId, string type = null)
        {
            var booksJson = File.ReadAllText("Data/BooksInfo.json");
            var books = JsonConvert.DeserializeObject<List<BooksInfo>>(booksJson);
            var availableBooks = books.Where(x => x.Available).ToList();
            if (userId == null)
            {
                return availableBooks;
            }
            var allocationsJson = File.ReadAllText("Data/AllocationInfo.json");
            var allocations = JsonConvert.DeserializeObject<List<AllocationInfo>>(allocationsJson);
            if (type == "mybooks")
            {
                var allocatedBooks = allocations.Where(x => x.UserId == userId).Select(x => x.BookId);
                var userBooks = new List<BooksInfo>();
                foreach (var id in allocatedBooks)
                {
                    var book = books.Where(x => x.Id == id).FirstOrDefault();
                    userBooks.Add(book);
                }
                return userBooks;
            }
            else
            {
                return availableBooks;
            }
        }

        public bool MarkAvailability(string bookId, bool isAvailable)
        {
            var booksJson = File.ReadAllText("Data/BooksInfo.json");
            var books = JsonConvert.DeserializeObject<List<BooksInfo>>(booksJson);
            books = books.Select((x) =>
            {
                if (x.Id == bookId)
                {
                    x.Available = isAvailable;
                }
                return x;
            }).ToList();
            File.WriteAllText("Data/BooksInfo.json", JsonConvert.SerializeObject(books));
            return true;
        }

        public bool AddBook(BooksInfo book)
        {
            var booksJson = File.ReadAllText("Data/BooksInfo.json");
            var books = JsonConvert.DeserializeObject<List<BooksInfo>>(booksJson);
            if (string.IsNullOrEmpty(book.Id))
            {
                book.Id = Guid.NewGuid().ToString();
                books.Add(book);
            }
            else
            {
                books = books.Select((x) =>
                {
                    if (x.Id == book.Id)
                    {
                        x.Name = book.Name;
                        x.Description = book.Description;
                        x.Author = book.Author;
                        x.Available = book.Available;
                    }
                    return x;
                }).ToList();
            }
            File.WriteAllText("Data/BooksInfo.json", JsonConvert.SerializeObject(books));
            return true;
        }
    }
}
