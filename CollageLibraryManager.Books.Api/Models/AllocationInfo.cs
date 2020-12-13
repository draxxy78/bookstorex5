using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollageLibraryManager.Books.Api.Models
{
    public class AllocationInfo
    {
        public string UserId { get; set; }
        public string BookId { get; set; }

        public string Method { get; set; }
    }
}
