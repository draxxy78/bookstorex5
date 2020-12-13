using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollageLibraryManager.Books.Api.Models
{
    public class AvailabilityRequest
    {
        public bool IsAvailable { get; set; }
        public string BookId { get; set; }
    }
}
