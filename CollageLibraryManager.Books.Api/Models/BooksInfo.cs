using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollageLibraryManager.Books.Api.Models
{
    public class BooksInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
    }
}
